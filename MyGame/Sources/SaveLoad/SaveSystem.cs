using System.Collections.Generic;
using System.IO;
using Entitas;
using Newtonsoft.Json;

namespace MyGame.Sources.SaveLoad;

//Регистрировать в классе производном от Feature
public sealed class SaveSystem : ReactiveSystem<GameEntity>
{
    private readonly Contexts _contexts;

    public SaveSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Settings);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasSettings;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        var entity = entities.SingleEntity();
        var lastFileName = JsonConvert.SerializeObject(entity.settings);
        entity.isDestroyed = true;

        using (var sw = new StreamWriter(Directory.GetCurrentDirectory() + @"\settings.json"))
        {
            sw.Write(lastFileName);
        }
    }
}
