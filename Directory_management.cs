using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace Čorbová_siemenshealth
{
    //This class provides functionalities related to managing directories
    public class Directory_management : IManageable
    {
        private string fPath;
        private Folder_info _folder;
        private File_info _file;
        private List<string> allExtenstions;
        public Directory_management(string path)
        {
            this.fPath = path;
            this._file = new File_info(path);
            this.allExtenstions = new List<string>();
        }

        /*Implements all functionalities, other methods from this class are called here
        There is also a warning about an empty path and errors handled*/
        public void ImplementAll()
        {
            try
            {
                if (File.Exists(this.fPath) && Path.GetExtension(Path.GetFileName(this.fPath)) == ".json")
                {
                    if ((string.IsNullOrWhiteSpace(File.ReadAllText(this.fPath))))
                    {
                        Console.WriteLine("Empty file path provided");
                        return;
                    }

                    _folder = DeserializeJSON();
                }

                else
                {
                    _folder = new Folder_info(this.fPath);
                }

                PrintAllExtensions();
                SaveJSONFile();
            }

            catch (Exception ex)
            {
                Console.WriteLine("Unexpected error: " + ex.Message);
            }
        }

        //Prints all file extensions found in the folder
        public void PrintAllExtensions()
        {
            allExtenstions = _folder.FileList.Select(file => file.Extension).Distinct().ToList();
           
            Console.WriteLine("Extensions found in folder: " + string.Join(", ", allExtenstions));
        }

        //Serializes Folder_info object to JSON string, error handling is in method WriteJsonFile
        public string SerializeToJSON()
        {
            if (File.Exists(this.fPath))
            {
                return JsonSerializer.Serialize(_folder);
            }

            _folder = new Folder_info(this.fPath);
            return JsonSerializer.Serialize(_folder);
        }

        //Deserializes JSON string to Folder_info object
        public Folder_info DeserializeJSON()
        {
            try
            {
                string jsonString = File.ReadAllText(this.fPath);                
                return JsonSerializer.Deserialize<Folder_info>(jsonString);
            }

            catch (JsonException ex)
            {
                Console.WriteLine("Error during deserialization: " + ex.Message);
                return null;
            }
        }

        //Writes JSON data to file
        private void WriteJsonFile(string file)
        {
            try
            {
                Console.WriteLine("Saving it...");
                File.WriteAllText(file, SerializeToJSON());
                Console.WriteLine("Successfully saved!");
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error saving JSON file: " + ex.Message);
            }
        }

        //Handles JSON file operations, makes sure user gave a valid JSON file
        private void HandleJSONFile()
        {
            Console.WriteLine("Please provide the path to JSON file");
            string file = Console.ReadLine();

            if (File.Exists(file))
            {
                if (Path.GetExtension(file) == ".json")
                {
                    WriteJsonFile(file);
                }

                else
                {
                    Console.WriteLine("The file provided is not a JSON file");
                }
            }

            else
            {
                Console.WriteLine("The file provided doesn't exist");
            }
        }

        //Saves JSON data to a file, user can decide if he wants to save the folder data
        public string SaveJSONFile()
        {
            Console.WriteLine("Do you want to save to JSON?");
            string response = Console.ReadLine().ToLower();

            if (response == "yes" || response == "y"){
                HandleJSONFile();
            }

            else if (response == "no" || response == "n"){}

            else
            {
                Console.WriteLine("Invalid response. Please enter 'yes' or 'no'");
                SaveJSONFile();
            }

            return response;
        }
    }
}
