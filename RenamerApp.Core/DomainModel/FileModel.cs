using System;
using System.IO;
using System.Threading.Tasks;

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

        private string FullFile { get; }
        internal string Directory { get; }
        internal string Name { get; set; }
        internal string Extension { get; }
        internal string OldName { get; }
        internal bool? Copy { get; set; }

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

        internal async Task<bool> CopyOrMoveFilesAsync(string outputDirectory, bool? copy, bool overwrite)
        {
            if (copy == true)
                await Task.Run(() => File.Copy($"{FullFile}",
                    $"{(outputDirectory == "" ? Directory : outputDirectory)}\\{Name}{Extension}",
                    overwrite));
            else
                await Task.Run(() => File.Move($"{FullFile}",
                    $"{(outputDirectory == "" ? Directory : outputDirectory)}\\{Name}{Extension}",
                    overwrite));
            return true;
        }
    }
}