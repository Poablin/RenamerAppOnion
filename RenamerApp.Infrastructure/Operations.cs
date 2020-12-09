using System.IO;
using System.Threading.Tasks;

namespace RenamerApp
{
    internal class Operations
    {
        private async Task<bool> CopyOrMoveFilesAsync(string outputDirectory, EditorModel fileInputs, bool? copy,
            bool overwrite)
        {
            if (copy == true)
                await Task.Run(() => File.Copy($"{fileInputs.FullFile}",
                    $"{(outputDirectory == "" ? fileInputs.Dire : outputDirectory)}\\{fileInputs.Name}{fileInputs.Exte}",
                    overwrite));
            else
                await Task.Run(() => File.Move($"{fileInputs.FullFile}",
                    $"{(outputDirectory == "" ? fileInputs.Dire : outputDirectory)}\\{fileInputs.Name}{fileInputs.Exte}",
                    overwrite));
            return true;
        }
    }
}