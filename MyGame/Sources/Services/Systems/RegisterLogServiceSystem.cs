// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using Entitas;

namespace MyGame.Sources.Services
{
    public class RegisterLogServiceSystem : IInitializeSystem
    {
        private readonly MetaContext _metaContext;
        private readonly ILogService _logService;

        public RegisterLogServiceSystem(Contexts contexts, ILogService logService)
        {
            _metaContext = contexts.meta;
            _logService = logService;
        }

        public void Initialize()
        {
            _metaContext.ReplaceLogService(_logService);
        }
    }
}
