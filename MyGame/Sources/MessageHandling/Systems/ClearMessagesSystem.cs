using Entitas;

namespace MyGame.Sources.Systems;

//Регистрировать в классе производном от Feature
public sealed class ClearMessagesSystem : IExecuteSystem
{
    private readonly Contexts _contexts;

    public ClearMessagesSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Execute()
    {
        var entities = _contexts.game.GetGroup(GameMatcher.Message);
        foreach (var entity in entities)
        {
            //if (entities.count > 1)
                //entity.isDestroyed = true;
        }
    }
}
