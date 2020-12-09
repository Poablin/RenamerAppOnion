using System.Threading.Tasks;
using RenamerApp.Core.ApplicationServices;
using RenamerApp.UserInterface.Interfaces;

namespace RenamerApp.UserInterface
{
    internal class ErrorChecking
    {
        public ErrorChecking(FileService fileInfo, WindowInputs windowInputs, string originalDirectory, ILogger logger)
        {
            FileInfo = fileInfo;
            WindowInputs = windowInputs;
            OriginalDirectory = originalDirectory;
            Logger = logger;
        }

        private FileService FileInfo { get; }
        private WindowInputs WindowInputs { get; }
        private string OriginalDirectory { get; }
        private ILogger Logger { get; }

        public async Task<bool> DirectoryExistsOrNotAsync()
        {
            if (await FileInfo.CheckIfDirectoryExistsOrSetDefault(WindowInputs.OutputDirectory) != "N/A") return true;
            Logger.Log("Directory does not exist - Please enter a valid output path or empty for default.");
            return false;
        }

        public async Task<bool> FileExistsAndCopyEnabledAndDirectoryDefaultAsync()
        {
            if (!await FileInfo.CheckIfFileExistsInOutput(WindowInputs.OutputDirectory) ||
                WindowInputs.OverwriteCheckBox != true ||
                WindowInputs.CopyCheckBox != true || WindowInputs.OutputDirectory != OriginalDirectory) return true;
            Logger.Log("File already exists - Can't overwrite a file already in use - Skipping file");
            WindowInputs.IncrementProgressBar();
            return false;
        }

        public async Task<bool> FileExistsAndOverwriteNotCheckedAsync()
        {
            if (!await FileInfo.CheckIfFileExistsInOutput(WindowInputs.OutputDirectory) ||
                WindowInputs.OverwriteCheckBox == true) return true;
            Logger.Log("File already exists - Overwrite not checked - Skipping file");
            WindowInputs.IncrementProgressBar();
            return false;
        }

        public async Task FileExistsAndOverwriteCheckedAsync()
        {
            if (await FileInfo.CheckIfFileExistsInOutput(WindowInputs.OutputDirectory) &&
                WindowInputs.OverwriteCheckBox == true)
                Logger.Log("File already exists - Overwriting");
        }
    }
}