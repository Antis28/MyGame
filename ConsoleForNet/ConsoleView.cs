using System;
using System.Text;

namespace ConsoleForNet
{
    public static class ConsoleView
    {
        /// <summary>
        /// Первичная настройка консоли
        /// </summary>
        public static void Init()
        {
            // Регистрируем кодировки для core проекта
            // EncodingProvider inst = CodePagesEncodingProvider.Instance;
            // Encoding.RegisterProvider(inst);

            // Применяем кодировку
            Console.OutputEncoding = Encoding.GetEncoding(866);
        }
        public static void ShowConfigServer(string localAddr, string port, string maxThreadsCount)
        {
            Console.WriteLine("Конфигурация многопоточного сервера:");
            Console.WriteLine($"  IP-адрес  : {localAddr}");
            Console.WriteLine($"  Порт      : {port}");
            Console.WriteLine($"  Потоки    : {maxThreadsCount}");
            Console.WriteLine("\nСервер запущен\n");
        }
        public static void ShowWaitServer()
        {
            Console.Write("\nОжидание соединения... ");
        }

        public static void ShowNumberConection(string counter)
        {
            Console.Write($"\nСоединение №{counter}!");
        }

        public static void ShowSend(string message)
        {
            Console.WriteLine($"Отправлено: {message}");
        }

        public static void ShowMessage(string message)
        {
            Console.WriteLine($"\nСообщение: {message}");
        }

        public static void ShowError(Exception e)
        {
            Console.WriteLine("SocketException: {0}", e);
        }
        public static void WaitUserInput()
        {
            Console.WriteLine("\nНажмите Enter...");
            Console.Read();
        }

        public static void ShowConnect(string localAddr, string message)
        {
            Console.WriteLine($"Адрес:{localAddr}\tсообщение:{message}");
        }

        public static void ShowReceived(string message)
        {
            Console.WriteLine($"Получено: {message}");
        }
    }
}
