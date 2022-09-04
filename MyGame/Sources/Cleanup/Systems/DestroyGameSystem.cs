using Entitas;
using System.Collections.Generic;

namespace MyGame.Sources.Systems
{
//Регистрировать в классе производном от Feature
    public sealed class DestroyGameSystem : ReactiveSystem<GameEntity>
    {
        private readonly Contexts _context;

        public DestroyGameSystem(Contexts contexts) : base(contexts.game)
        {
            _context = contexts;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Destroyed);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isDestroyed;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.Destroy();
            }
        }
    }
}