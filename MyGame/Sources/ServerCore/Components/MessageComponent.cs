using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace MyGame.Sources.ServerCore.Components
{
    /// <summary>
    /// Сообщение для обработки сервером
    /// </summary>
    public sealed class MessageComponent : IComponent
    {
        public string value;
    }
}




