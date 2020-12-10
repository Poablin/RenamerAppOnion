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
            File = file;
            Repository = repository;
            FileModel = new FileModel();
            FileModel.FullFile = File;
            FileModel.Directory = Path.GetDirectoryName(File);
            FileModel.Name = Path.GetFileNameWithoutExtension(File);
            FileModel.Extension = Path.GetExtension(File);
            FileModel.OldName = Path.GetFileNameWithoutExtension(File);
        }

        private string File { get; }
        private FileModel FileModel { get; }
        private IFileRepository Repository { get; }

        public async Task<FileModel> CreateFileRepository()
        {
            await Repository.Create(FileModel);
            return FileModel;
        }

        public async Task<bool> CheckIfFileExistsInOutput(string outputDirectory)
        {
            var fileModel = await Repository.Read();
            return System.IO.File.Exists($"{outputDirectory}\\{fileModel.Name}{fileModel.Extension}");
            ;
        }

        public void CheckIfOutputDirectoryExists(string outputDirectory)
        {
            Directory.Exists(outputDirectory);
        }

        public async Task<string> CheckIfDirectoryExistsOrSetDefault(string outputDirectory)
        {
            var fileModel = await Repository.Read();
            var directory = outputDirectory == "" ? fileModel.Directory :
                Directory.Exists(outputDirectory) ? outputDirectory : "N/A";
            return directory;
        }

        public async Task<string> Trim()
        {
            var fileModel = await Repository.Read();
            return fileModel.Name.Trim();
        }

        public async Task<string> UpperCase(bool? isChecked)
        {
            var fileModel = await Repository.Read();
            return fileModel.Name = isChecked == true
                ? fileModel.Name.Substring(0, 1).ToUpper() + fileModel.Name[1..]
                : fileModel.Name.Substring(0, 1).ToLower() + fileModel.Name[1..];
        }

        public async Task<string> ReplaceSpecificString(string firststring, string secondstring)
        {
            var fileModel = await Repository.Read();
            return fileModel.Name = fileModel.Name.Replace(firststring, secondstring);
        }

        public async Task<string> SubstringThis(string fromIndex, string toIndex)
        {
            var fileModel = await Repository.Read();
            if (toIndex == "") return fileModel.Name = fileModel.Name.Substring(Convert.ToInt32(fromIndex));
            return fileModel.Name = fileModel.Name.Substring(Convert.ToInt32(fromIndex), Convert.ToInt32(toIndex));
        }
    }
}