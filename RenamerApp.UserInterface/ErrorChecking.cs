using RenamerApp.Core.ApplicationServices;

namespace RenamerApp
{
    internal class ErrorChecking
    {
        public ErrorChecking(FileService fileInfo, WindowInputs windowInputs, ILogger logger)
        {
            FileInfo = fileInfo;
            WindowInputs = windowInputs;
            Logger = logger;
        }
        private FileService FileInfo { get; }
        private WindowInputs WindowInputs { get; }
        private ILogger Logger { get; }

        public bool DirectoryExistsOrNot()
        {
            if (FileInfo.CheckIfDirectoryExistsOrSetDefault(WindowInputs.OutputDirectory) != "N/A") return true;
            Logger.Log("Directory does not exist - Please enter a valid output path or empty for default.");
            return false;
        }

        public bool FileExistsAndCopyEnabledAndDirectoryDefault(string directory)
        {
            if (!FileInfo.CheckIfFileExistsInOutput(WindowInputs.OutputDirectory) || WindowInputs.OverwriteCheckBox != true ||
                WindowInputs.CopyCheckBox != true || WindowInputs.OutputDirectory != directory) return true;
            Logger.Log("File already exists - Can't overwrite a file already in use - Skipping file");
            WindowInputs.IncrementProgressBar();
            return false;
        }

        public bool FileExistsAndOverwriteNotChecked()
        {
            if (!FileInfo.CheckIfFileExistsInOutput(WindowInputs.OutputDirectory) || WindowInputs.OverwriteCheckBox == true) return true;
            Logger.Log("File already exists - Overwrite not checked - Skipping file");
            WindowInputs.IncrementProgressBar();
            return false;
        }

        public void FileExistsAndOverwriteChecked()
        {
            if (FileInfo.CheckIfFileExistsInOutput(WindowInputs.OutputDirectory) && WindowInputs.OverwriteCheckBox == true)
                Logger.Log("File already exists - Overwriting");
        }
    }
}