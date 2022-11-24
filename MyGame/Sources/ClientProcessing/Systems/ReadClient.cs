using System;
using System.Net;
using System.Net.Sockets;
using Entitas;
using MyGame.Sources.Debug;

namespace MyGame.Sources.ClientProcessing.Systems
{
//Регистрировать в классе производном от Feature
    public sealed class ReadClientSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;

        // Буфер для принимаемых данных.
        readonly Byte[] bytes = new Byte[1024];
        String data = String.Empty;


        public ReadClientSystem(Contexts contexts)
        {
            _entities = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Client));
        }

        public void Execute()
        {
            foreach (var entity in _entities)
            {
                var client = entity.client.value;
                
                // получит ip клиента
                IPEndPoint ipep = (IPEndPoint)client.Client.RemoteEndPoint;
                var ip = ipep.Address;
                var port = ipep.Port;
                
                // Принимаем данные от клиента в цикле пока не дойдём до конца и отправит ответ об успехе.
                ReadAndSendSuccessAnswer(client);
                
                entity.isDestroyed = true;

                // Выводим в журнал полученное сообщение
                DebugHelper.CreateEntityMessage(data, GetType().Name);

                // сохраняем полученное сообщение
                var messageEntity = Contexts.sharedInstance.game.CreateEntity();
                messageEntity.AddMessage(data, ip.ToString(), port);
            }
        }

        private void ReadAndSendSuccessAnswer(TcpClient client)
        {
            try
            {
                // Получаем информацию от клиента
                var stream = client.GetStream();
                int count;
                while ((count = stream.Read(bytes, 0, bytes.Length)) != 0)
                {
                    // Преобразуем данные в UTF8 string.
                    data = System.Text.Encoding.UTF8.GetString(bytes, 0, count);

                    // Преобразуем полученную строку в массив Байт.
                    var msg = System.Text.Encoding.UTF8.GetBytes("Response: Success");

                    // Отправляем данные обратно клиенту (ответ).
                    stream.Write(msg, 0, msg.Length);
                }
            } catch (Exception e) { Console.WriteLine(e); } finally
            {
                // Закрываем соединение.
                client.Close();
            }
        }
    }
}
