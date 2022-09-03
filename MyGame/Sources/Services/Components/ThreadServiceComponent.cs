using Entitas;
using Entitas.CodeGeneration.Attributes;
using MyGame.Sources.Services;

[Meta, Unique]
public sealed class ThreadServiceComponent : IComponent
{
    public IMultiThreadService value;
}