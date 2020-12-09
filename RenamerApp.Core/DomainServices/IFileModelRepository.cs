using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RenamerApp.Core.DomainModel;

namespace RenamerApp.Core.DomainServices
{
    interface IFileModelRepository
    {
        Task<bool> Create(FileModel filemodel);
    }
}
