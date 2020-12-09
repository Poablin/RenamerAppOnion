using System;
using System.IO;
using RenamerApp.Core.DomainModel;

namespace RenamerApp.Core.ApplicationServices
{
    public class FileService
    {
        public FileService(string file)
        {
            _fileModel = new FileModel(file);
        }

        private FileModel _fileModel { get; }

        public async void Start(string OutputDirectory, bool? copy, bool overwrite)
        {
            await _fileModel.CopyOrMoveFilesAsync(OutputDirectory, copy, overwrite);
        }

        public bool CheckIfFileExistsInOutput(string OutputDirectory)
        {
            return File.Exists($"{OutputDirectory}\\{_fileModel.Name}{_fileModel.Extension}");
        }

        public bool CheckIfOutputDirectoryExists(string OutputDirectory)
        {
            return Directory.Exists(OutputDirectory);
        }

        public string CheckIfDirectoryExistsOrSetDefault(string OutputDirectory)
        {
            OutputDirectory = OutputDirectory == "" ? _fileModel.Directory :
                Directory.Exists(OutputDirectory) ? OutputDirectory : "N/A";
            return OutputDirectory;
        }

        public string Trim()
        {
           return _fileModel.Name.Trim();
        }

        public string UpperCase(bool? isChecked)
        {
           return _fileModel.Name = isChecked == true
                ? _fileModel.Name.Substring(0, 1).ToUpper() + _fileModel.Name[1..]
                : _fileModel.Name.Substring(0, 1).ToLower() + _fileModel.Name[1..];
        }

        public void ReplaceSpecificString(string firststring, string secondstring)
        {
            _fileModel.Name = _fileModel.Name.Replace(firststring, secondstring);
        }

        public void SubstringThis(string fromIndex, string toIndex)
        {
            if (toIndex == "") _fileModel.Name = _fileModel.Name.Substring(Convert.ToInt32(fromIndex));
            else _fileModel.Name = _fileModel.Name.Substring(Convert.ToInt32(fromIndex), Convert.ToInt32(toIndex));
        }
    }
}