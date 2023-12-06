using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Čorbová_siemenshealth
{
    public interface IManageable
    {
        /*functionality to inherit for more classes if needed
         1. print extensions
         2. folder info serialization to JSON format
         3. save JSON to file
         4. folder info JSON deserialization
         5. implement all functionalities
         */

        public void PrintAllExtensions();
        public string SerializeToJSON();
        public string SaveJSONFile();
        public Folder_info DeserializeJSON();
        public void ImplementAll();
    }
}
