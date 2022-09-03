using Entitas;
using Entitas.CodeGeneration.Attributes;
using MyGame.Sources.Services;

[Meta, Unique]
public sealed class LogServiceComponent : IComponent
{
    /// <summary>
    /// Для вывода сообщения в журнал(консоль или файл)
    /// </summary>
    public ILogService instance;
}