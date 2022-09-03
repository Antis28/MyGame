// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using MyGame.Sources.Interfaces;

namespace MyGame.Sources.Services
{
    public class JsonLogService : ILogService
    {
        string filepath;
        string filename;

        bool prettyPrint;

        // etc...
        public void LogMessage(string message)
        {
            // open file
            // parse contents
            // write new contents
            // close file
        }
    }
}

