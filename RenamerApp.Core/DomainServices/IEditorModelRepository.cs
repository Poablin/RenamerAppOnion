using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenamerApp.Core.DomainServices
{
    interface IEditorModelRepository
    {
        Task<bool> Create(EditorModel editormodel);
    }
}
