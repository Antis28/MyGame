// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com
using ConsoleForNet;
namespace MyGame.Sources.Services
{
    public class ConsoleLogService: ILogService
    {
        
        public ConsoleLogService()
        {
            ConsoleView.Init();
        }
        
        public void LogMessage(string message) {
            ConsoleView.ShowMessage(message);
        }
    }
}
