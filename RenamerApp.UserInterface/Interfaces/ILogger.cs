using System;

namespace RenamerApp.UserInterface.Interfaces
{
    internal interface ILogger
    {
        void Clear()
        {
        }

        void Log(string text)
        {
        }

        void Log(Exception ex)
        {
        }
    }
}