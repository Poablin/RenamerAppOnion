using RenamerApp.Core.DomainServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenamerApp.Core.ApplicationServices
{
    class EditorService
    {
        private IEditorModelRepository _repository;
        public EditorService(IEditorModelRepository repository)
        {
            _repository = repository;
        }
        public void MakeNewFile()
        {

        }
    }
}
