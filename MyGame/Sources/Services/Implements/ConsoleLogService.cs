using CrossConsole;

namespace MyGame.Sources.Services
{
    public class ConsoleLogService : ILogService
    {
        private readonly IConsole console;

        public ConsoleLogService()
        {
            console = ConsoleCreator.CreateForDotNetFramework();
        }

        public void LogMessage(string message)
        {
            console.ShowMessage(message);
        }

        public void LogMessage(string message, string sourceName)
        {
            console.ShowMessage(sourceName, message);
        }
    }
}
