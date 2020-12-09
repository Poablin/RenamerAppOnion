using System;
using System.IO;

namespace RenamerApp
{
    public class EditorModel
    {
        public EditorModel(string file)
        {
            FullFile = file;
            Dire = Path.GetDirectoryName(file);
            Name = Path.GetFileNameWithoutExtension(file);
            Exte = Path.GetExtension(file);
            Oldn = Path.GetFileNameWithoutExtension(file);
        }

        public string FullFile { get; }
        public string Dire { get; }
        public string Name { get; internal set; }
        public string Exte { get; }
        private string Oldn { get; }
        public bool? Copy { get; set; }

        public string OutputDirectory { get; internal set; }
        public string LogStartProcessing => $"Processing: \"{Oldn}{Exte}\"";

        public string LogFinishedProcessing
        {
            get
            {
                var str = string.Empty;
                if (Oldn != Name) str += $"Renamed \"{Oldn}{Exte}\" to \"{Name}{Exte}\" ";
                if (OutputDirectory != Dire && OutputDirectory != "")
                    str += $"{(Copy != true ? "Moved" : "Copied")} \"{Name}{Exte}\" to \"{OutputDirectory}\" ";
                if (str == string.Empty) str += "Didn't do anything with file";
                return str.Trim();
            }
        }

        public bool CheckIfFileExistsInOutput()
        {
            return File.Exists($"{OutputDirectory}\\{Name}{Exte}");
        }

        public bool CheckIfOutputDirectoryExists()
        {
            return Directory.Exists(OutputDirectory);
        }

        public string CheckIfDirectoryExistsOrSetDefault()
        {
            OutputDirectory = OutputDirectory == "" ? Dire :
                Directory.Exists(OutputDirectory) ? OutputDirectory : "N/A";
            return OutputDirectory;
        }

        public void Trim()
        {
            Name.Trim();
        }

        public void UpperCase(bool? isChecked)
        {
            Name = isChecked == true
                ? Name.Substring(0, 1).ToUpper() + Name[1..]
                : Name.Substring(0, 1).ToLower() + Name[1..];
        }

        public void ReplaceSpecificString(string firststring, string secondstring)
        {
            Name = Name.Replace(firststring, secondstring);
        }

        public void SubstringThis(string fromIndex, string toIndex)
        {
            if (toIndex == "") Name = Name.Substring(Convert.ToInt32(fromIndex));
            else Name = Name.Substring(Convert.ToInt32(fromIndex), Convert.ToInt32(toIndex));
        }
    }
}