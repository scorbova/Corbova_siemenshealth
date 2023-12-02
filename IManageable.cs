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
         */

        public string PrintAllExtensions();
        public void SerializeToJSON();
        public void SaveJSONFile(string path);
        public void DeserializeJSON();
    }
}
