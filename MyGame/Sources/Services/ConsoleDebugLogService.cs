// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using MyGame.Sources.Interfaces;

namespace MyGame.Sources.Services
{
    public class ConsoleDebugLogService: ILogService
    {
        public void LogMessage(string message) {
            System.Console.WriteLine(message);
        }
    }
}
