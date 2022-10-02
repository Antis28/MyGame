using System.Collections.Generic;
using System.IO;
using Entitas;
using Newtonsoft.Json;

namespace MyGame.Sources.SaveLoad;

//Регистрировать в классе производном от Feature
public sealed class LoadSettingsSystem : ReactiveSystem<GameEntity>
{
    private readonly Contexts _contexts;

    public LoadSettingsSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.LoadSettings));
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isLoadSettings;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        string textSettings;
        using (var sw = new StreamReader(Directory.GetCurrentDirectory() + @"\settings.json"))
        {
            textSettings = sw.ReadToEnd();
        }

        var entity = entities.SingleEntity();
        entity.isDestroyed = true;

        var settings = JsonConvert.DeserializeObject<SettingsComponent>(textSettings);
        _contexts.debug.CreateEntity().AddDebugLog(settings?.lastFileName, nameof(this.GetType));
    }
}
