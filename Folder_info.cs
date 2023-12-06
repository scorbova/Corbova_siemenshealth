using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.IO;

namespace Čorbová_siemenshealth
{
    public class Folder_info: AbstractInformation
    {
        //information about folder: folder name (inherit from abstract class), list of all files in folder, list of all nested files
        public string[] FolderList { get; set; }
        public File_info[] FileList { get; set; }

        public Folder_info(string path) : base(path)
        {
            FolderList = AllFolders(path);
            FileList = AllFiles(path);
        }

        [JsonConstructor]
        public Folder_info(string name, string[] FolderList, File_info[] FileList) : base(name)
        {
            this.FolderList = FolderList;
            this.FileList = FileList;
            this.Name = name;
        }
        private string[] AllFolders(string path)
        {
            return Directory.GetDirectories(path, "*", SearchOption.AllDirectories).Select(f => Path.GetFileName(f)).ToArray();
        }

        private File_info[] AllFiles(string path)
        {
            string[] files = Directory.GetFiles(path, "*", SearchOption.AllDirectories);
            File_info[] filesInfo = files.Select(f => new File_info(f)).ToArray();

            return filesInfo;
        }
    }
}
