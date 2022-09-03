using Entitas;
using System.Collections.Generic;

namespace MyGame.Sources.Systems
{
//Регистрировать в классе производном от Feature
    public sealed class DestroyDebugSystem : ReactiveSystem<DebugEntity>
    {
        private readonly Contexts _contexts;

        public DestroyDebugSystem(Contexts contexts) : base(contexts.debug)
        {
            _contexts = contexts;
        }

        protected override ICollector<DebugEntity> GetTrigger(IContext<DebugEntity> context)
        {
            return context.CreateCollector(DebugMatcher.Destroyed);
        }

        protected override bool Filter(DebugEntity entity)
        {
            return entity.isDestroyed;
        }

        protected override void Execute(List<DebugEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.Destroy();
            }
        }
    }
}
