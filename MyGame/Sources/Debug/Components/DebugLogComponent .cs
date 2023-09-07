using Entitas;

/// <summary>
/// Добавляется для вывода сообщения в журнал
/// </summary>
[Debug]
public sealed class DebugLogComponent : IComponent
{
    //ToDo Добавить признак: сообщение, ошибка, предупреждение, подсказка. 
    /// <summary>
    /// Сообщение для вывода
    /// </summary>
    public string message;

    public string sourceName;
}
