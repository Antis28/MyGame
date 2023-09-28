using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Entitas;
using MessageObjects;
using MyGame.Sources.Debug;
using Newtonsoft.Json;

namespace MyGame.Sources.ClientProcessing.Systems
{
    //Регистрировать в классе производном от Feature
    public sealed class ReadClientSystem : IExecuteSystem
    {
        private Contexts _contexts;
        private readonly IGroup<GameEntity> _entities;
        private IPAddress ip;
        private int port;

        String data = String.Empty;


        public ReadClientSystem(Contexts contexts)
        {
            _contexts = contexts;
            _entities = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Client));
        }

        public void Execute()
        {
            try
            {
                foreach (var entity in _entities)
                {
                    TcpClient client = entity.client.value;

                    Thread clientThread = new Thread(ClientQueryHandler);
                    clientThread.Start(client);
                    //ClientQueryHandler();
                    entity.isDestroyed = true;
                }
            }
            catch (Exception e)
            {

                Main.Logger.ShowError(e);
            }

        }

        private void ClientQueryHandler(object obj)
        {
            TcpClient client = (TcpClient)obj;

            // получит ip клиента
            var ipep = (IPEndPoint)client.Client.RemoteEndPoint;
            ip = ipep.Address;
            port = ipep.Port;

            // Принимаем данные от клиента в цикле пока не дойдём до конца и отправит ответ об успехе.
            try
            {
                ReadAndSendSuccessAnswer(client);
            }
            catch (Exception e)
            {
                // TODO: Переделать в логер ECS(DI)
                Main.Logger.ShowError(e);
            }
            finally
            {
                // Закрываем соединение.
                client.Close(); 
            }
         }

        private void ReadAndSendSuccessAnswer(TcpClient client)
        {
            // Получаем информацию от клиента
            var stream = client.GetStream();
            // Буфер для принимаемых данных.
            byte[] buffer = new byte[1024];

            int bytesRead;
            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) != 0)
            {
                // Преобразуем данные в UTF8 string.
                data = System.Text.Encoding.UTF8.GetString(buffer, 0, bytesRead);

                // Преобразуем полученную строку в массив Байт.
                var msg = System.Text.Encoding.UTF8.GetBytes("Response: Success");

                // Отправляем данные обратно клиенту (ответ).
                stream.Write(msg, 0, msg.Length);

                // Выводим в журнал полученное сообщение
                DebugHelper.CreateEntityMessage(data, GetType().Name);

                // сохраняем полученное сообщение
                var messageEntity = Contexts.sharedInstance.game.CreateEntity();

                CommandMessage deserializedMessage;
                try { deserializedMessage = JsonConvert.DeserializeObject<CommandMessage>(data); }
                catch (Exception e)
                {
                    // TODO: Переделать в логер ECS(DI), когда будет признак ошибки
                    var message = e.Message;
                    // _contexts.debug.CreateEntity().AddDebugLog(message, GetType().Name);
                    Main.Logger.ShowError(e);
                    return;
                }
                messageEntity.AddMessage(deserializedMessage, ip.ToString(), port);
            }
        }
    }
}
