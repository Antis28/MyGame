using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
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
        static int count = 0;

        String data = String.Empty;
        TaskQueue _taskQueue;

        public ReadClientSystem(Contexts contexts)
        {
            _contexts = contexts;
            _entities = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Client));
            _taskQueue = new TaskQueue();
        }

        public void Execute()
        {
            try
            {
                foreach (var entity in _entities)
                {
                    TcpClient client = entity.client.value;
                    count += 1;
                    // Добавляем задачи в очередь
                    //await _taskQueue.Enqueue(async () =>
                    //{
                    //    var c = count;
                    //    Console.WriteLine($"Задача №{c}...");
                    //    await Task.Run(() => ClientQueryHandler(client));
                    //    Console.WriteLine($"Задача №{c} завершена.");
                    //});

                    //Thread clientThread = new Thread(ClientQueryHandler);
                    //clientThread.Start(client);
                    //ClientQueryHandler(client);
                    entity.isDestroyed = true;
                }
            }
            catch (Exception e)
            {

                Main.Logger.ShowError(e);
            }

        }

       
    }
}
