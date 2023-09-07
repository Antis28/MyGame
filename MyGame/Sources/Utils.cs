using ApiCrossConsole;
using CrossConsole;

namespace MyGame.Sources
{
    public static class Utils
    {
        private static readonly IConsole _console = ConsoleCreator.CreateForDotNetFramework();

        public static void Show()
        {
            var _contexts = Contexts.sharedInstance;

            _console.ShowMessage(new string('-', 80));
            _console.ShowMessage($"Context = game");
            _console.ShowMessage($"Count E = {_contexts.game.count}");
            _console.ShowMessage($"totalComponents = {_contexts.game.totalComponents}");
            _console.ShowMessage($"reusableEntitiesCount = {_contexts.game.reusableEntitiesCount}");
            _console.ShowMessage($"retainedEntitiesCount = {_contexts.game.retainedEntitiesCount}");
            _console.ShowMessage($"Length  componentPools= {_contexts.game.componentPools.Length}");
            foreach (var componentName in _contexts.game.contextInfo.componentNames)
            {
                _console.ShowMessage(componentName);
            }

            _console.ShowMessage($"componentPools: ");
            foreach (var components in _contexts.game.componentPools)
            {
                if (components != null)
                {
                    foreach (var component in components) { _console.ShowMessage(component.ToString()); }
                }
            }

            _console.ShowMessage(new string('-', 40));
            _console.ShowMessage($"Context = debug");
            _console.ShowMessage($"Count E = {_contexts.debug.count}");
            _console.ShowMessage($"totalComponents = {_contexts.debug.totalComponents}");
            _console.ShowMessage($"reusableEntitiesCount = {_contexts.debug.reusableEntitiesCount}");
            _console.ShowMessage($"retainedEntitiesCount = {_contexts.debug.retainedEntitiesCount}");
            _console.ShowMessage($"Length  componentPools= {_contexts.debug.componentPools.Length}");
            foreach (var componentName in _contexts.debug.contextInfo.componentNames)
            {
                _console.ShowMessage(componentName);
            }

            _console.ShowMessage(new string('-', 80));
        }
    }
}
