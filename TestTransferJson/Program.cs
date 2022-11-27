using System;
using TestTransferJson.FromUnity;
using TestTransferJson.FromUnity.Mocks;

namespace TestTransferJson
{
    internal class Program
    {
       
        
        public static void Main(string[] args)
        {
            var client = new Client();
            client.StartClientAndServer();
            Console.ReadKey();
        }
    }
}
