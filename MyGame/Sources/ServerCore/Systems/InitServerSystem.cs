﻿using Entitas;
using System.Collections.Generic;
using System.IO.Ports;
using System.Net.Sockets;

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
           var addressInfo =  entities.SingleEntity().addressInfo;
           // Запускаем TcpListener и начинаем слушать клиентов.
           var server = new TcpListener(addressInfo.ip, addressInfo.port);
           server.Start();
          
           
           var serverEntity = _contexts.game.CreateEntity();
           serverEntity.AddServer(server, 0);


           
        }
    }
}
