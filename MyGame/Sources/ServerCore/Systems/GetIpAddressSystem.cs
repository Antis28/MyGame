using System.Net;
using System.Net.Sockets;
using Entitas;

namespace MyGame.Sources.Systems
{
    /// <summary>
    /// Получает локальный IP адрес и присваивает стандартный порт
    /// </summary>
    public sealed class GetIpAddressSystem : IInitializeSystem
    {
        private readonly Contexts _contexts;
        private readonly string _localhost = "127.0.0.1";
        private readonly int _port = 9595;

        public GetIpAddressSystem(Contexts contexts)
        {
            _contexts = contexts;
        }

        public void Initialize()
        {
            var hostIp = _localhost;
            var host = Dns.GetHostEntry(Dns.GetHostName());

            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork) { hostIp = ip.ToString(); }
            }

            var message = $"AddressInfo was created\nip = {hostIp}, port = {_port}";
            if (hostIp == _localhost)
            {
                message =
                    $"No network adapters with an IPv4 address in the system!\n Installed Ip = {_localhost}\nPort = {_port}";
            }

            _contexts.debug.CreateEntity().AddDebugLog(message, GetType().Name);

            var e = _contexts.game.CreateEntity();
            e.AddAddressInfo(IPAddress.Parse(hostIp), _port);
        }
    }
}
