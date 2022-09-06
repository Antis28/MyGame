
using System;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using Entitas;
using MyGame.Sources.ServerCore;

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

        public void  Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                // Принимаем клиентов в бесконечном цикле.
                var server = entity.server.instance;
                var clientNumber = entity.server.clientNumber;
                
                if (!server.Pending())
                {
                    // var debugEntity = _contexts.debug.CreateEntity();
                    // debugEntity.ReplaceDebugLog($"Sorry, no connection requests have arrived", nameof(ParallelProcessingSystem));
                }
                else
                {
                    //Accept the pending client connection and return a TcpClient object initialized for communication.
                    // TcpClient tcpClient = server.AcceptTcpClient();
                    ThreadPool.QueueUserWorkItem(ProcessingRecivedData, server.AcceptTcpClient());
                    entity.ReplaceServer(server,++clientNumber);
                
                    // Выводим информацию о подключении.
                    var debugEntity = _contexts.debug.CreateEntity();
                    debugEntity.ReplaceDebugLog($"Соединение №{clientNumber}!", nameof(ParallelProcessingSystem));
                }
            }
        }
        private static void ProcessingRecivedData(object client_obj)
        {
            if (client_obj == null)
            {
                throw new ArgumentNullException();
            }


            ServerReader? reader = new ServerReader(client_obj as TcpClient);
            string response = reader.Read("Success");

            
            KeyProvider prov = new KeyProvider(response);
            prov.PostClick();            
        }
    }
}
//ProcessingClient