using System.Threading.Tasks;
using RenamerApp.Core.DomainModel;

namespace RenamerApp.Core.DomainServices
{
    public interface IFileRepository
    {
        Task<bool> Create(FileModel fileModel);
        Task<FileModel> Read();
    }
}