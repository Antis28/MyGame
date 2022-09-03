using Entitas;
using System.Collections.Generic;
using MyGame.Sources.Services;

namespace MyGame.Sources.Systems.Logging
{
    public sealed class HandleDebugLogMessageSystem : ReactiveSystem<DebugEntity>
    {
        private readonly ILogService _logService;

        public HandleDebugLogMessageSystem(Contexts contexts) : base(contexts.debug)
        {
            // could be a UnityDebugLogService or a JsonLogService 
            _logService = contexts.meta.logService.instance;
            
        }

        // collector: Debug.Matcher.DebugLog
        protected override ICollector<DebugEntity> GetTrigger(IContext<DebugEntity> context)
        {
            return context.CreateCollector(DebugMatcher.DebugLog);
        }

        // filter: entity.hasDebugLog
        protected override bool Filter(DebugEntity entity)
        {
            return entity.hasDebugLog;
        }

        protected override void Execute(List<DebugEntity> entities)
        {
            foreach (var e in entities) {
                _logService.LogMessage(e.debugLog.message);
                e.isDestroyed = true;
            }
        }
    }
}
