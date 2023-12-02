using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Čorbová_siemenshealth
{
    public class Folder_info: AbstractInformation
    {
        //information about folder: folder name (inherit from abstrac class), list of all files in folder, list of all nested files
        private string folderPath;
        private List<string> folderList;
        private List<string> fileList;
        public Folder_info(string path) : base(path)
        {
            this.folderPath = path;
            this.folderList = new List<string>();
            this.fileList = new List<string>();
        }

        public string FolderPath { get; set; }
        public List<string> FolderList { get; set; }
        public List<string> FileList { get; set; }

        private void AddToList(string[] entity, List<string> list)
        {
            foreach (string ent in entity)
            {
                list.Add(ent);
            }
        }
        public void AllFolders()
        {
            string[] allfolders = Directory.GetDirectories(folderPath, "*", SearchOption.AllDirectories);

            AddToList(allfolders, folderList);
        }
        public void AllFiles()
        {
            string[] allfiles = Directory.GetFiles(folderPath, "*.*", SearchOption.AllDirectories);

            AddToList(allfiles,fileList);
        }
    }
}
