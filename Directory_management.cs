using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Čorbová_siemenshealth
{
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

        public void ImplementAll()
        {
            try
            {
                if (File.Exists(fPath))
                {
                    if ((string.IsNullOrWhiteSpace(File.ReadAllText(fPath))))
                    {
                        Console.WriteLine("Empty file path provided.");
                        return;
                    }

                    _folder = DeserializeJSON();
                }

                else
                {
                    _folder = new Folder_info(fPath);
                }

                PrintAllExtensions();
                SaveJSONFile();
            }

            catch (Exception ex)
            {
                Console.WriteLine("Unexpected error: " + ex.Message);
            }
        }
        public void PrintAllExtensions()
        {
            allExtenstions = _folder.FileList.Select(file => file.Extension).Distinct().ToList();
           
            Console.WriteLine("Extensions found in folder: " + string.Join(", ", allExtenstions));
        }

        public string SerializeToJSON()
        {
            if (File.Exists(fPath))
            {
                return JsonSerializer.Serialize(_folder);
            }

            _folder = new Folder_info(fPath);
            return JsonSerializer.Serialize(_folder);
        }
        public Folder_info DeserializeJSON()
        {

            try
            {
                string jsonString = File.ReadAllText(fPath);                
                return JsonSerializer.Deserialize<Folder_info>(jsonString);
            }

            catch (JsonException ex)
            {
                Console.WriteLine("Error during deserialization: " + ex.Message);
                return null;
            }
        }

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
                Console.WriteLine("Invalid response. Please enter 'yes' or 'no'.");
                SaveJSONFile();
            }

            return response;
        }
    }
}
