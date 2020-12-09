
using System.Threading.Tasks;

namespace RenamerApp.Core.DomainModel
{
    public class FileModel
    {
        internal string FullFile { get; set; }
        internal string Directory { get; set; }
        internal string Name { get; set; }
        internal string Extension { get; set; }
        internal string OldName { get; set; }
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
    }
}