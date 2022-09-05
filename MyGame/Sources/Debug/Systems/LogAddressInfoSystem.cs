using System.Collections.Generic;
using Entitas;

namespace MyGame.Sources.Systems
{
    /// <summary>
    /// Создает сущность с сообщением об изменении IP или порта
    /// </summary>
    public sealed class LogAddressInfoSystem : ReactiveSystem<GameEntity>
    {
        private readonly Contexts _contexts;

        public LogAddressInfoSystem(Contexts contexts) : base(contexts.game)
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
            foreach (var entity in entities)
            {
                var debugEntity = _contexts.debug.CreateEntity();
                debugEntity.ReplaceDebugLog("AddressInfo was created\n" +
                                            $"ip = {entity.addressInfo.ip}, port = {entity.addressInfo.port}");
            }
        }
    }
}
