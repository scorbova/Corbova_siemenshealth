using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Čorbová_siemenshealth
{
    public interface IManageable
    {
        /*Functionality to inherit for more classes if needed
         1. Print extensions
         2. Folder info serialization to JSON format
         3. Save JSON to file
         4. Folder info JSON deserialization
         5. Implement all functionalities
         */

        public void PrintAllExtensions();
        public string SerializeToJSON();
        public string SaveJSONFile();
        public Folder_info DeserializeJSON();
        public void ImplementAll();
    }
}
