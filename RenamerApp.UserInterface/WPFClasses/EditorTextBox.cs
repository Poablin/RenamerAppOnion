using System.Windows;
using System.Windows.Controls;

namespace RenamerApp.UserInterface.WPFClasses
{
    internal class EditorTextBox : TextBox
    {
        public EditorTextBox(int maxLength, int width, int marginLeft, int marginTop)
        {
            MaxLength = maxLength;
            Width = width;
            HorizontalAlignment = HorizontalAlignment.Left;
            VerticalAlignment = VerticalAlignment.Top;
            Margin = new Thickness(marginLeft, marginTop, 0, 0);
        }
    }
}