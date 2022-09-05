using Entitas;

namespace MyGame.Sources.Services
{
//Регистрировать в классе производном от Feature
    public sealed class RegisterMultiThreadServiceSystem : IInitializeSystem
    {
        private readonly MetaContext _metaContext;
        private readonly IMultiThreadService _multiThreadService;

        public RegisterMultiThreadServiceSystem(Contexts contexts, IMultiThreadService multiThreadService)
        {
            _metaContext = contexts.meta;
            _multiThreadService = multiThreadService;
        }

        public void Initialize()
        {
            _metaContext.ReplaceThreadService(_multiThreadService);
        }
    }
}
