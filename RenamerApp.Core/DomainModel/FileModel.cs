namespace RenamerApp.Core.DomainModel
{
    public class FileModel
    {
        public string FullFile { get; set; }
        public string Directory { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
        public string OldName { get; set; }
        private bool? Copy { get; set; }

        private string OutputDirectory { get; set; }
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