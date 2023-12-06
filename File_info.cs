using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Net.WebRequestMethods;
using System.Text.Json.Serialization;

namespace Čorbová_siemenshealth
{
    public class File_info : AbstractInformation
    {
        //information about files: file name (inherit from abstract class), file extension
        private string extension;
        public File_info(string fileName) : base(fileName)
        {
            Extension = fileName;
        }

        [JsonConstructor]
        public File_info(string name, string Extension) : base(name)
        {
            this.Extension = Extension;
        }
        public string Extension {
            get => extension;

            set
            {
                extension = Path.GetExtension(value);
            }
        }
    }
}
