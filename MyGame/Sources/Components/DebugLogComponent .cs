using Entitas;

/// <summary>
/// Добавляется для вывода сообщения в журнал
/// </summary>
[Debug]
public sealed class DebugLogComponent : IComponent
{
    /// <summary>
    /// Сообщение для вывода
    /// </summary>
    public string message;
}