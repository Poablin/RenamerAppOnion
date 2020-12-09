using System;
using System.IO;
using System.Threading.Tasks;
using RenamerApp.Core.DomainModel;
using RenamerApp.Core.DomainServices;

namespace RenamerApp.Core.ApplicationServices
{
    public class FileService
    {
        public FileService(string file, IFileRepository repository)
        {
            _file = file;
            _repository = repository;
        }

        private string _file { get; }
        private IFileRepository _repository { get; }

        private async Task<FileModel> StartFile()
        {
            var fileModel = new FileModel();
            fileModel.FullFile = _file;
            fileModel.Directory = Path.GetDirectoryName(_file);
            fileModel.Name = Path.GetFileNameWithoutExtension(_file);
            fileModel.Extension = Path.GetExtension(_file);
            fileModel.OldName = Path.GetFileNameWithoutExtension(_file);
            await _repository.Create(fileModel);
            return fileModel;
        }
        public async Task<bool> CheckIfFileExistsInOutput(string OutputDirectory)
        {
            var fileModel = await _repository.Read();
            return File.Exists($"{OutputDirectory}\\{fileModel.Name}{fileModel.Extension}"); ;
        }

        public void CheckIfOutputDirectoryExists(string OutputDirectory)
        {
            Directory.Exists(OutputDirectory);
        }

        public async Task<string> CheckIfDirectoryExistsOrSetDefault(string OutputDirectory)
        {
            var fileModel = await _repository.Read();
            var directory = OutputDirectory == "" ? fileModel.Directory :
                 Directory.Exists(OutputDirectory) ? OutputDirectory : "N/A";
            return directory;
        }

        public async Task<string> Trim()
        {
            var fileModel = await _repository.Read();
            return fileModel.Name.Trim();
        }

        public async Task<string> UpperCase(bool? isChecked)
        {
            var fileModel = await _repository.Read();
            return fileModel.Name = isChecked == true
                ? fileModel.Name.Substring(0, 1).ToUpper() + fileModel.Name[1..]
                : fileModel.Name.Substring(0, 1).ToLower() + fileModel.Name[1..];
        }

        public async Task<string> ReplaceSpecificString(string firststring, string secondstring)
        {
            var fileModel = await _repository.Read();
            return fileModel.Name = fileModel.Name.Replace(firststring, secondstring);
        }

        public async Task<string> SubstringThis(string fromIndex, string toIndex)
        {
            var fileModel = await _repository.Read();
            if (toIndex == "") return fileModel.Name = fileModel.Name.Substring(Convert.ToInt32(fromIndex));
            else return fileModel.Name = fileModel.Name.Substring(Convert.ToInt32(fromIndex), Convert.ToInt32(toIndex));
        }
    }
}