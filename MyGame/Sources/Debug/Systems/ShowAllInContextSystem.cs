using System.Linq;
using Entitas;

namespace MyGame.Sources.Systems
{
//Регистрировать в классе производном от Feature
    public sealed class ShowAllInContextSystem : IExecuteSystem
    {
        private readonly Contexts _contexts;

        public ShowAllInContextSystem(Contexts contexts)
        {
            _contexts = contexts;
        }

        public void Execute()
        {
            ConsoleForNet.ConsoleView.ShowMessage(new string('-', 80));
            ConsoleForNet.ConsoleView.ShowMessage($"Context = game");
            ConsoleForNet.ConsoleView.ShowMessage($"Count E = {_contexts.game.count}");
            ConsoleForNet.ConsoleView.ShowMessage($"totalComponents = {_contexts.game.totalComponents}");
            ConsoleForNet.ConsoleView.ShowMessage($"reusableEntitiesCount = {_contexts.game.reusableEntitiesCount}");
            ConsoleForNet.ConsoleView.ShowMessage($"retainedEntitiesCount = {_contexts.game.retainedEntitiesCount}");
            ConsoleForNet.ConsoleView.ShowMessage($"Length  componentPools= {_contexts.game.componentPools.Length}");
            foreach (var componentName in _contexts.game.contextInfo.componentNames)
            {
                ConsoleForNet.ConsoleView.ShowMessage(componentName);
            }
            ConsoleForNet.ConsoleView.ShowMessage(new string('-', 40));
            ConsoleForNet.ConsoleView.ShowMessage($"Context = debug");
            ConsoleForNet.ConsoleView.ShowMessage($"Count E = {_contexts.debug.count}");
            ConsoleForNet.ConsoleView.ShowMessage($"totalComponents = {_contexts.debug.totalComponents}");
            ConsoleForNet.ConsoleView.ShowMessage($"reusableEntitiesCount = {_contexts.debug.reusableEntitiesCount}");
            ConsoleForNet.ConsoleView.ShowMessage($"retainedEntitiesCount = {_contexts.debug.retainedEntitiesCount}");
            ConsoleForNet.ConsoleView.ShowMessage($"Length  componentPools= {_contexts.debug.componentPools.Length}");
            foreach (var componentName in _contexts.debug.contextInfo.componentNames)
            {
                ConsoleForNet.ConsoleView.ShowMessage(componentName);
            }
            ConsoleForNet.ConsoleView.ShowMessage(new string('-', 80));
        }
    }
}
