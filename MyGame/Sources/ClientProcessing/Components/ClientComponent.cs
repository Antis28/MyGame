using System.Net.Sockets;
using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace MyGame.Sources.ClientProcessing.Components
{
    public sealed class ClientComponent : IComponent
    {
        public TcpClient  value;
    }
}




