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
        /*functionality: 
         1. print extensions
         2. folder info serialization to JSON format
         3. save JSON to file
         4. folder info JSON deserialization
         */
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
            if (File.Exists(fPath))
            {
                if (File.ReadAllText(fPath) == "")
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
            
            //Console.WriteLine("Got here");
            PrintAllExtensions();
            SaveJSONFile();
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
        public string SaveJSONFile()
        {
            Console.WriteLine("Do you want to save to JSON?");
            string response = Console.ReadLine(); //implement precaution for different types and responses
            response = response.ToLower();

            if (response == "yes" || response == "y"){
                Console.WriteLine("Please provide the path to JSON file");
                string file = Console.ReadLine();

                if (File.Exists(file))
                {
                    //i can change this after
                    if (Path.GetExtension(file) == ".json")
                    {
                        Console.WriteLine("Saving it...");
                        File.WriteAllText(file, SerializeToJSON());
                        Console.WriteLine("Successfully saved!");
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

            else if (response == "no" || response == "n"){

            }

            else
            {
                Console.WriteLine("Wrong response, try again");
                SaveJSONFile();
            }

            return response;
        }
    }
}
