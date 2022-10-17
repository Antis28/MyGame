using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading;
using Entitas;

namespace MyGame.Sources.Systems
{
//Регистрировать в классе производном от Feature
    public sealed class InitServerSystem : ReactiveSystem<GameEntity>
    {
        private readonly Contexts _contexts;

        public InitServerSystem(Contexts contexts) : base(contexts.game)
        {
            _contexts = contexts;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.AddressInfo);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasAddressInfo;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            var addressInfo = entities.SingleEntity().addressInfo;
            // Запускаем TcpListener и начинаем слушать клиентов.
            var server = new TcpListener(addressInfo.ip, addressInfo.port);
            try { server.Start(); } catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("Возможно уже запущен экземпляр на этом сокете");
                throw;
            }

            var serverEntity = _contexts.game.CreateEntity();
            serverEntity.AddServer(server, 0);

            _contexts.debug.CreateEntity().AddDebugLog("Ожидание соединения... ", GetType().Name);


            int MaxThreadsCount = Environment.ProcessorCount * 4;
            // Установим максимальное количество рабочих потоков
            ThreadPool.SetMaxThreads(MaxThreadsCount, MaxThreadsCount);
            // Установим минимальное количество рабочих потоков
            ThreadPool.SetMinThreads(2, 2);
        }
    }
}
