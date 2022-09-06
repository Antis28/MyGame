using System.Net;
using Entitas;

public sealed class AddressInfoComponent : IComponent
{
    public IPAddress ip;
    public int port;
}
