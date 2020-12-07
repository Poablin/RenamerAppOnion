using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using RenamerApp.WPFClasses;

namespace RenamerApp
{
    internal class Operations
    {
        private readonly EditorWindow _window;

        public Operations(EditorWindow window, ILogger logger)
        {
            Logger = logger;
            _window = window;
            _window.StartButton.Click += StartOperation;
            _window.SelectFilesButton.Click += SelectFiles;
            _window.SelectOutputButton.Click += SelectOutputFolder;
            _window.ContextItem1.Click += ContextItem1_Click;
            _window.ResetUiButton.Click += ResetUi;
            _window.HelpButton.Click += ShowHelpText;
        }

        private ILogger Logger { get; }
        private WindowInputs WindowInputs { get; set; }
        private string[] FilePaths { get; set; }
        private int OpenHelpNum { get; set; }






    }
}