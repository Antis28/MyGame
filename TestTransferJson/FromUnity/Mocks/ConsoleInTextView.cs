

using System;

namespace ConsoleForUnity
{
    public static class ConsoleInTextView
    {
       
        static ConsoleInTextView()
        {
            
        }

        public static void LogInText(string msg)
        {
           Console.WriteLine(msg);
        }

        public static void LogInText(string src, string msg)
        {
            Console.WriteLine($"{src} -> {msg}");
        }


        public static void ShowSend(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            LogInText(message);
            Console.ResetColor();
        }

        public static void ShowMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            LogInText(message);
            Console.ResetColor();
        }

        public static void ShowError(Exception p0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            LogInText(p0.Message);
            Console.ResetColor();
        }
    }
}
