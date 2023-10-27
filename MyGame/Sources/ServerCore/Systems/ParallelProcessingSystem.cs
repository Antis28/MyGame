using System;
using System.Net.Sockets;
using Entitas;
using System.Net;
using System.Threading.Tasks;
using MessageObjects;
using MyGame.Sources.Debug;
using Newtonsoft.Json;
using MyGame.Sources.ClientProcessing.Systems;

namespace MyGame.Sources.Systems
{
    //Регистрировать в классе производном от Feature
    public sealed class ParallelProcessingSystem : IExecuteSystem
    {
        private IPAddress ip;
        private int port;
        static int count = 0;
        TaskQueue _taskQueue;
        String data = String.Empty;


        private readonly IGroup<GameEntity> _entities;
        private readonly Contexts _contexts;

        public ParallelProcessingSystem(Contexts contexts)
        {
            _contexts = contexts;
            _entities = contexts.game.GetGroup(GameMatcher.Server);
            _taskQueue = new TaskQueue();
        }

        public async void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                try
                {


                    // Принимаем клиентов в бесконечном цикле.
                    var server = entity.server.instance;
                    var clientNumber = entity.server.clientNumber;

                    // Есть ли ожидающие запросы
                    if (!server.Pending())
                    {
                        // Запросов нет
                        return;
                    }

                    //Accept the pending client connection and return a TcpClient object initialized for communication.
                    // Создаем сущность клиента для дальнейшей обработки системами
                    var client = server.AcceptTcpClient();

                    //var e = _contexts.game.CreateEntity();
                    //e.AddClient(listener);
                    count++;
                    await _taskQueue.Enqueue(async () =>
                    {
                        var c = count;
                        Console.WriteLine($"Задача №{c}...");
                        await Task.Run(() => ClientQueryHandler(client));
                        Console.WriteLine($"Задача №{c} завершена.");
                    });


                    entity.ReplaceServer(server, ++clientNumber);

                    // Выводим информацию в журнал о подключении.
                    _contexts.debug.CreateEntity().AddDebugLog($"Соединение №{clientNumber}!", GetType().Name);
                }
                catch (Exception e)
                {

                    Main.Logger.ShowMessage(e.Message);

                }
            }
        }


        private void ClientQueryHandler(object obj)
        {
            TcpClient client = (TcpClient)obj;
            if (!client.Connected)
            {
                return;
            }
            try
            {
                // получит ip клиента
                IPEndPoint ipep = (IPEndPoint)client.Client.RemoteEndPoint;
                ip = ipep.Address;
                port = ipep.Port;

                // Принимаем данные от клиента в цикле пока не дойдём до конца и отправит ответ об успехе.

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
//ProcessingClient
