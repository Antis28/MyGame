using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using CrossConsole;
using Entitas;
using MyGame.Sources.ServerCore;
using MyGame.Sources.ServerCore.Components;
using Newtonsoft.Json;

namespace MyGame.Sources.Systems
{
//Регистрировать в классе производном от Feature
    /// <summary>
    /// Когда было прочитано сообщение, обработать его
    /// </summary>
    public sealed class ConverterMessagesSystem : ReactiveSystem<GameEntity>
    {
        private readonly Contexts _contexts;
        private readonly Dictionary<string, Action> _keyCommands;
        private string _currentIp;
        private int _currentPort;

        public ConverterMessagesSystem(Contexts contexts) : base(contexts.game)
        {
            _contexts = contexts;
            _keyCommands = new Dictionary<string, Action>()
            {
                { "Right x 10", ButtonClicker.MoveRight10Click },
                { "Left x 10", ButtonClicker.MoveLeft10Click },
                { "Right", ButtonClicker.MoveRightClick },
                { "Left", ButtonClicker.MoveLeftClick },
                { "Space", ButtonClicker.PausePlayClick },
                { "Volume +", ButtonClicker.VolumeUpClick },
                { "Volume -", ButtonClicker.VolumeDownClick },
                { "Mute", ButtonClicker.MuteClick },
                { "PageDown", ButtonClicker.PageDownClick },
                { "PageUp", ButtonClicker.PageUpClick },
                { "Hibernate", SleepMode.GoHibernateMode },
                { "StandBy", SleepMode.GoStandbyMode },
                { "SaveName", CreateSettingsEntity },
                { "GetFileSystem", SendFileSystemInJson },
            };
        }

        private static void CreateSettingsEntity()
        {
            var procFinder = new KeyboardEmulator.ProcessFinder();
            var process = procFinder.GetActiveProcess();

            var saveEntity = Contexts.sharedInstance.game.CreateEntity();
            saveEntity.ReplaceSettings(process.MainWindowTitle);
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Message);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasMessage;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                if (!entity.hasMessage) { return; }

                var message = entity.message.value;
                _currentIp = entity.message.ipClient;
                _currentPort = entity.message.portClient;
                if (_keyCommands.ContainsKey(message))
                {
                    var actionCommand = _keyCommands[message];
                    actionCommand();
                }
                else { throw new ArgumentException("Сообщение от клиента не распознано"); }
            }
        }

        private async void SendFileSystemInJson()
        {
            var builder = new FileSystemBuilder();
            var fileSystem = builder.FillFileSystem();
            var jsonText = JsonConvert.SerializeObject(fileSystem);
            try
            {
                await Connect(jsonText, _currentIp).ConfigureAwait(false);
            } catch (Exception e)
            {
                ConsoleCreator.CreateForDotNetFramework().ShowMessage(e.Message);
            }
        }

        private async Task Connect(string message, string ipAddress = "192.168.1.201", int port = 9090)
        {
            // Настраиваем его на IP нашего сервера и тот же порт.
            try
            {
                // Создаём TcpClient.
                TcpClient tcpClient = new TcpClient();
                await tcpClient.ConnectAsync(ipAddress, port); // соединение
                NetworkStream networkStream = tcpClient.GetStream();
                StreamWriter writer = new StreamWriter(networkStream, Encoding.UTF8);
                StreamReader reader = new StreamReader(networkStream, Encoding.UTF8);
                writer.AutoFlush = true;

                await writer.WriteLineAsync(message);
                
                string response = await reader.ReadLineAsync();
                tcpClient.Close();
                ConsoleCreator.CreateForDotNetFramework().ShowMessage(response);
                // return response;


                // while (true)
                // {
                //     string request = await reader.ReadLineAsync();
                //     if (request != null)
                //     {
                //         Console.WriteLine("Received service request: " + request);
                //         string response = Response(request);
                //         Console.WriteLine("Computed response is: " + response + "\n");
                //         await writer.WriteLineAsync(message);
                //     }
                //     else
                //         break; // клиент закрыл соединение
                // }
                //
                // tcpClient.Close();


                // await SendToMobileServer(message, stream);
                //
                // // Закрываем всё.
                // stream.Close();
                // tcpClient.Close();
            } catch (Exception e) { ConsoleCreator.CreateForDotNetFramework().ShowMessage(e.Message); } 
        }


        private static async Task SendToMobileServer(string message, Stream stream)
        {
            // Переводим наше сообщение в UTF8, а затем в массив Byte.
            Byte[] responseData = Encoding.UTF8.GetBytes(message);

            // Отправляем сообщение нашему мобильному серверу. 
            stream.Write(responseData, 0, responseData.Length);
            await GetAnswerFromMobileAnswer(stream).ConfigureAwait(false);
        }

        private static async Task GetAnswerFromMobileAnswer(Stream stream)
        {
            // // Получаем ответ от сервера.
            // Буфер для хранения принятого массива bytes.
            Byte[] responseData = new byte[512];

            int count = 0;
            // StringBuilder для склеивания полученных данных в одну строку
            var response = new StringBuilder();

            // !!! deadlock !!!!
            // Можно читать всё сообщение. 
            while (true)
            {
                var length = responseData.Length;
                bool isContinue = stream != null &&
                                  (count = await stream.ReadAsync(responseData, 0, length)) != 0;
                if (!isContinue) break;

                // Строка для хранения полученных UTF8 данных.
                var dataStr = Encoding.UTF8.GetString(responseData, 0, count);
                response.Append(dataStr);
                SendToMobileServer("Response: Success", stream);
                if (dataStr == "Response: Success") { break; }
            }

            ConsoleCreator.CreateForDotNetFramework().ShowMessage(response.ToString());
        }
    }
}
