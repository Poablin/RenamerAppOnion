using System;
using RenamerApp.UserInterface.WPFClasses;

namespace RenamerApp.UserInterface
{
    internal static class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            var app = new EditorApplication();
            var logger = new Logger(app.Window.InformationList.Items);
            var operations = new Operations(app.Window, logger);
            app.Run(app.Window);
        }
    }
}