using System.IO;
using System.Threading.Tasks;
using RenamerApp.Core.DomainModel;

namespace RenamerApp.Infrastructure
{
    internal class Operations
    {
        private async Task<bool> CopyOrMoveFilesAsync(string outputDirectory, FileModel fileInputs, bool? copy,
            bool overwrite)
        {
            if (copy == true)
                await Task.Run(() => File.Copy($"{fileInputs.FullFile}",
                    $"{(outputDirectory == "" ? fileInputs.Directory : outputDirectory)}\\{fileInputs.Name}{fileInputs.Extension}",
                    overwrite));
            else
                await Task.Run(() => File.Move($"{fileInputs.FullFile}",
                    $"{(outputDirectory == "" ? fileInputs.Directory : outputDirectory)}\\{fileInputs.Name}{fileInputs.Extension}",
                    overwrite));
            return true;
        }
    }
}