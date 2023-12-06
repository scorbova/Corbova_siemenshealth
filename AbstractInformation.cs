using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Čorbová_siemenshealth
{
    /*Abstract class meant to be inherited by other classes
     Retrieves entity name, modifies by removing extension if the entity is file*/
    public abstract class AbstractInformation
    {
        private string name;

        public AbstractInformation(string entity)
        {
            Name = entity;
        }
        public string Name 
        {   
            get => name;
            
            set
            {
                name = Path.GetFileNameWithoutExtension(value);
            }
        }
    }
}
