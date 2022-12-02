using Entitas;
using Entitas.CodeGeneration.Attributes;
using MessageObjects;

namespace MyGame.Sources.ServerCore.Components
{
    /// <summary>
    /// Сообщение для обработки сервером
    /// </summary>
    public sealed class MessageComponent : IComponent
    {
        public ICommandMessage value;
        public string ipClient;
        public int portClient;
    }
}




