using System.Threading.Tasks;
using RenamerApp.Core.DomainModel;
using RenamerApp.Core.DomainServices;

namespace RenamerApp.Infrastructure
{
    public class InMemoryRepository : IFileRepository
    {
        private FileModel _fileModel;

        public Task<bool> Create(FileModel fileModel)
        {
            _fileModel = fileModel;
            return Task.FromResult(true);
        }

        public Task<FileModel> Read()
        {
            return Task.FromResult(_fileModel);
        }
    }
}