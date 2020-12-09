using RenamerApp.Core.DomainServices;
using System;
using System.Threading.Tasks;
using RenamerApp.Core.DomainModel;
using System.IO;

namespace RenamerApp.Core.ApplicationServices
{
    class FIleService
    {
        private IFileModelRepository _repository;
        private FileModel _fileModel;
        private string OutputDirectory;
        public FIleService(IFileModelRepository repository)
        {
            _repository = repository;
        }
        public async Task<FileModel> MakeNewFileName()
        {
            string filePath = string.Empty;
            var fileModel = new FileModel(filePath);
            await _repository.Create(fileModel);
            _fileModel = fileModel;
            return fileModel;
        }

        public bool CheckIfFileExistsInOutput()
        {
            return File.Exists($"{OutputDirectory}\\{_fileModel.Name}{_fileModel.Extension}");
        }

        public bool CheckIfOutputDirectoryExists()
        {
            return Directory.Exists(OutputDirectory);
        }

        public string CheckIfDirectoryExistsOrSetDefault()
        {
            OutputDirectory = OutputDirectory == "" ? _fileModel.Directory :
                Directory.Exists(OutputDirectory) ? OutputDirectory : "N/A";
            return OutputDirectory;
        }

        public void Trim()
        {
            _fileModel.Name.Trim();
        }

        public void UpperCase(bool? isChecked)
        {
            _fileModel.Name = isChecked == true
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
