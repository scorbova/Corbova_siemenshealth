using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Čorbová_siemenshealth
{
    public class Folder_info: AbstractInformation
    {
        //information about folder: folder name (inherit from abstract class), list of all files in folder, list of all nested files
        private string folderPath;
        //will need these variables to do try-catch and other precautions
        private string[] folderList;
        private string[] fileList;
        public Folder_info(string path) : base(path)
        {
            this.folderPath = path;
            FolderList = AllFolders();
            FileList = AllFiles();
        }
        public string[] FolderList { get; set;}
        public string[] FileList { get; set; }

        private string[] AllFolders()
        {
            return Directory.GetDirectories(folderPath, "*", SearchOption.AllDirectories).Select(f => Path.GetFileName(f)).ToArray();
        }
        private string[] AllFiles()
        {
            return Directory.GetFiles(folderPath, "*.*", SearchOption.AllDirectories).Select(f => Path.GetFileName(f)).ToArray();
        }
    }
}
