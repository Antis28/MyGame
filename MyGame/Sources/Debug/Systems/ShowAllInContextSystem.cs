
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
            var console = Main.Logger;
            //var console = ConsoleCreator.CreateForDotNetFramework();

            console.ShowMessage(new string('-', 80));
            console.ShowMessage($"Context = game");
            console.ShowMessage($"Count E = {_contexts.game.count}");
            console.ShowMessage($"totalComponents = {_contexts.game.totalComponents}");
            console.ShowMessage($"reusableEntitiesCount = {_contexts.game.reusableEntitiesCount}");
            console.ShowMessage($"retainedEntitiesCount = {_contexts.game.retainedEntitiesCount}");
            console.ShowMessage($"Length  componentPools= {_contexts.game.componentPools.Length}");
            foreach (var componentName in _contexts.game.contextInfo.componentNames)
            {
                console.ShowMessage(componentName);
            }

            console.ShowMessage(new string('-', 40));
            console.ShowMessage($"Context = debug");
            console.ShowMessage($"Count E = {_contexts.debug.count}");
            console.ShowMessage($"totalComponents = {_contexts.debug.totalComponents}");
            console.ShowMessage($"reusableEntitiesCount = {_contexts.debug.reusableEntitiesCount}");
            console.ShowMessage($"retainedEntitiesCount = {_contexts.debug.retainedEntitiesCount}");
            console.ShowMessage($"Length  componentPools= {_contexts.debug.componentPools.Length}");
            foreach (var componentName in _contexts.debug.contextInfo.componentNames)
            {
                console.ShowMessage(componentName);
            }

            console.ShowMessage(new string('-', 80));
        }
    }
}
