using System.Net.Sockets;
using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace MyGame.Sources.ServerCore.Components
{
    [Game][Unique]
    public sealed class ServerComponent : IComponent
    {
        public TcpListener instance;
        public int clientNumber;
    }
}




