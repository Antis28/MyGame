namespace MyGame.Sources.Debug
{
    public static class DebugHelper
    {
        private static Contexts _contexts;

        public static void CreateEntityMessage(string message, string sourceClass)
        {
            _contexts ??= Contexts.sharedInstance;

            var debugEntity = _contexts.debug.CreateEntity();
            debugEntity.ReplaceDebugLog(message, sourceClass);
        }
        public static void CreateEntityMessage(string message)
        {
            _contexts ??= Contexts.sharedInstance;

            var debugEntity = _contexts.debug.CreateEntity();
            debugEntity.ReplaceDebugLog(message, "no");
        }
    }
}
