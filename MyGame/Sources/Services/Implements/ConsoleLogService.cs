﻿using ConsoleForNet;

namespace MyGame.Sources.Services
{
    public class ConsoleLogService : ILogService
    {
        public ConsoleLogService()
        {
            ConsoleView.Init();
        }

        public void LogMessage(string message)
        {
            ConsoleView.ShowMessage(message);
        }
    }
}