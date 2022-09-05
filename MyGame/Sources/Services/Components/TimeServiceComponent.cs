using Entitas;
using Entitas.CodeGeneration.Attributes;
using MyGame.Sources.Services;

[Meta, Unique]
public sealed class TimeServiceComponent : IComponent
{
    public ITimeService instance;
}
