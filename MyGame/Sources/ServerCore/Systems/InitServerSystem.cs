using Entitas;

namespace MyGame.Sources.Systems
{
    public sealed class InitServerSystem : IInitializeSystem
    {
        private readonly Contexts _contexts;

        public InitServerSystem(Contexts contexts)
        {
            _contexts = contexts;
        }

        public void Initialize()
        {
            var e = _contexts.game.CreateEntity();
            e.AddAddressInfo( "127.0.0.1",9595);
        }
    }
}
