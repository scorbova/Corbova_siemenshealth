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
        private string folderPath;
        private Folder_info _folder;
        private File_info _file;
        private HashSet<string> allExtenstions;
        public Directory_management(string path)
        {
            this.folderPath = path;
            _folder = new Folder_info(path);
            _file = new File_info(path);
            this.allExtenstions = new HashSet<string>();
        }

        public void DeserializeJSON()
        {
            //_folder = JsonSerializer.Deserialize<Folder_info>(jsonString);
        }

        public void PrintAllExtensions()
        {
            //if (folderPath)
            foreach (string file in _folder.FileList)
            {
                File_info _file = new File_info(file);
                _file.Extension = file;
                this.allExtenstions.Add(_file.Extension);
            }

            Console.WriteLine("Extensions found in folder: " + string.Join(", ", allExtenstions));
        }

        public string SaveJSONFile()
        {
            Console.WriteLine("Do you want to save to JSON?");
            string response = Console.ReadLine(); //implement precaution for different types and responses
            response = response.ToLower();

            if (response == "yes" || response == "y"){
                Console.WriteLine("Please provide the path to JSON file");
                string file = Console.ReadLine();

                Console.WriteLine("file path: " + file);
                
                if (File.Exists(file))
                {
                    Console.WriteLine("file extension: " + Path.GetExtension(file));
                    //i can change this after
                    if (Path.GetExtension(file) == ".json")
                    {
                        File.WriteAllText(file, SerializeToJSON());
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
                //File.WriteAllText(path, path);
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

        public string SerializeToJSON()
        {
            
            return JsonSerializer.Serialize(_folder);
            //string jsonString = JsonSerializer.Serialize(_folder);

            //Console.WriteLine(jsonString);
        }
    }
}
