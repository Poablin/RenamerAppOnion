using System;
using System.IO;

namespace RenamerApp.Core.DomainModel
{
    public class FileModel
    {
        public FileModel(string file)
        {
            FullFile = file;
            Directory = Path.GetDirectoryName(file);
            Name = Path.GetFileNameWithoutExtension(file);
            Extension = Path.GetExtension(file);
            OldName = Path.GetFileNameWithoutExtension(file);
        }

        public string FullFile { get; }
        public string Directory { get; }
        public string Name { get; internal set; }
        public string Extension { get; }
        private string OldName { get; }
        public bool? Copy { get; set; }

        public string OutputDirectory { get; internal set; }
        public string LogStartProcessing => $"Processing: \"{OldName}{Extension}\"";

        public string LogFinishedProcessing
        {
            get
            {
                var str = string.Empty;
                if (OldName != Name) str += $"Renamed \"{OldName}{Extension}\" to \"{Name}{Extension}\" ";
                if (OutputDirectory != Directory && OutputDirectory != "")
                    str += $"{(Copy != true ? "Moved" : "Copied")} \"{Name}{Extension}\" to \"{OutputDirectory}\" ";
                if (str == string.Empty) str += "Didn't do anything with file";
                return str.Trim();
            }
        }
    }
}