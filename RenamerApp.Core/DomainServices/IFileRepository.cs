using RenamerApp.Core.DomainModel;
using System.Threading.Tasks;

namespace RenamerApp.Core.DomainServices
{
    public interface IFileRepository
    {
        Task<bool> Create(FileModel fileModel);
        Task<FileModel> Read();
    }
}
