namespace MyGame.Sources
{
    public static class Utils
    {
       
        public static void Show()
        {
            var _contexts = Contexts.sharedInstance;
            
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
            ConsoleForNet.ConsoleView.ShowMessage($"componentPools: ");
            foreach (var components in _contexts.game.componentPools)
            {
                if (components != null)
                {
                    foreach (var component in components)
                    {
                        ConsoleForNet.ConsoleView.ShowMessage(component.ToString());
                    }
                }
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
