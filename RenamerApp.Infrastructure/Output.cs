using System;
using System.Threading.Tasks;

namespace RenamerApp.Infrastructure
{
    public class Output
    {
        public Output()
        {

        }
        //internal async Task<bool> CopyOrMoveFilesAsync(string outputDirectory, bool? copy, bool overwrite)
        //{
        //    if (copy == true)
        //        await Task.Run(() => File.Copy($"{FullFile}",
        //            $"{(outputDirectory == "" ? Directory : outputDirectory)}\\{Name}{Extension}",
        //            overwrite));
        //    else
        //        await Task.Run(() => File.Move($"{FullFile}",
        //            $"{(outputDirectory == "" ? Directory : outputDirectory)}\\{Name}{Extension}",
        //            overwrite));
        //    return true;
        //}
    }
}
