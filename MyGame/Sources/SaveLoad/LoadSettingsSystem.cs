using System.Collections.Generic;
using System.IO;
using Entitas;
using MyGame.Sources.Systems;
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
        var settings = LastMovieRepository.GetSettings();
        
        var entity = entities.SingleEntity();
        entity.isDestroyed = true;
        
        _contexts.debug.CreateEntity().AddDebugLog(settings?.lastFileName, GetType().Name);
    }

    
}
