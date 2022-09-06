using System.Net.Sockets;
using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace MyGame.Sources.ServerCore.Components
{
    [Game]
    public sealed class ServerComponent : IComponent
    {
        public TcpListener instance;
        public int clientNumber;
    }
}




