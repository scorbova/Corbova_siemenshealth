using System;
using System.IO;
using System.Text.Json.Serialization;

namespace Čorbová_siemenshealth
{
    public class File_info : AbstractInformation
    {
        /*Information about files: file name (inherits from abstract class),
         file extension - gets a file and extracts the extension*/
        private string extension;

        public File_info(string fileName) : base(fileName)
        {
            Extension = fileName;
        }

        //Another construct for deserialization
        [JsonConstructor]
        public File_info(string name, string Extension) : base(name)
        {
            this.Extension = Extension;
        }


        //String to store the required file extension
        public string Extension {
            get => extension;

            set
            {
                extension = Path.GetExtension(value);
            }
        }
    }
}
