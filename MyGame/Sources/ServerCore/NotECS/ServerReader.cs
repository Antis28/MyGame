using System;
using System.Net.Sockets;
using consoleV = ConsoleForNet.ConsoleView;

namespace MyGame.Sources.ServerCore
{
    internal class ServerReader
    {
        // Буфер для принимаемых данных.
        Byte[] bytes = new Byte[256];
        String data = String.Empty;
        TcpClient client;
        // Получаем информацию от клиента
        NetworkStream stream;
        public ServerReader(TcpClient client)
        {
            this.client = client;
        }

        public String Read(string backMessage)
        {
            // Получаем информацию от клиента
            stream = client.GetStream();

            int i;
            // Принимаем данные от клиента в цикле пока не дойдём до конца.
            while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
            {
                // Преобразуем данные в UTF8 string.
                data = System.Text.Encoding.UTF8.GetString(bytes, 0, i);
                consoleV.ShowMessage(data);

                // Преобразуем полученную строку в массив Байт.
                byte[] msg = System.Text.Encoding.UTF8.GetBytes(backMessage);
                
                // Отправляем данные обратно клиенту (ответ).
                stream.Write(msg, 0, msg.Length);
            }
            // Закрываем соединение.
            client.Close();
            return data;
        }
    }
}
