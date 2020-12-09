using System.Windows.Controls;

namespace RenamerApp.UserInterface.WPFClasses
{
    internal class EditorContextMenu : ContextMenu
    {
        public EditorContextMenu()
        {
            Items.Add(ContextItem1);
        }

        public MenuItem ContextItem1 { get; } = new MenuItem {Header = "Copy Text"};
    }
}