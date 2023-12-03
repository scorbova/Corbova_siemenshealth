using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        private HashSet<string> allExtenstions;
        public Directory_management(string path)
        {
            this.folderPath = path;
            this.allExtenstions = new HashSet<string>();
        }
        public void DeserializeJSON()
        {
            throw new NotImplementedException();
        }

        public void PrintAllExtensions()
        {
            Folder_info _folder = new Folder_info(this.folderPath);

            foreach (string file in _folder.FileList)
            {
                File_info _file = new File_info(file);
                _file.Extension = file;
                this.allExtenstions.Add(_file.Extension);
            }

            Console.WriteLine("Extensions found in folder: " + string.Join(", ", allExtenstions));
        }

        public void SaveJSONFile(string path)
        {
            throw new NotImplementedException();
        }

        public void SerializeToJSON()
        {
            throw new NotImplementedException();
        }
    }
}
