using Entitas;
using Entitas.CodeGeneration.Attributes;
using MyGame.Sources.Services;

[Meta, Unique]
public sealed class LogServiceComponent : IComponent
{
    public ILogService instance;
}