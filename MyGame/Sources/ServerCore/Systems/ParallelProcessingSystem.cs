using System;
using System.Net.Sockets;
using System.Threading;
using Entitas;

namespace MyGame.Sources.Systems
{
//Регистрировать в классе производном от Feature
    public sealed class ParallelProcessingSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly Contexts _contexts;

        public ParallelProcessingSystem(Contexts contexts)
        {
            _contexts = contexts;
            _entities = contexts.game.GetGroup(GameMatcher.Server);
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
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
                var listener = server.AcceptTcpClient();
                var e = _contexts.game.CreateEntity();
                e.AddClient(listener);

                entity.ReplaceServer(server, ++clientNumber);

                // Выводим информацию в журнал о подключении.
                _contexts.debug.CreateEntity().AddDebugLog($"Соединение №{clientNumber}!", GetType().Name);
            }
        }
    }
}
//ProcessingClient
