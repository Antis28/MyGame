using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
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

        private void SendFileSystemInJson()
        {
            var builder = new FileSystemBuilder();
            var fileSystem = builder.FillFileSystem();
            var jsonText = JsonConvert.SerializeObject(fileSystem);
            Connect(jsonText,_currentIp);
        }

        private async void Connect(string message, string ipAddress = "192.168.1.201", int port = 9090)
        {
            // Настраиваем его на IP нашего сервера и тот же порт.

            try
            {
                // Создаём TcpClient.
                TcpClient client = new TcpClient();
                await client.ConnectAsync(ipAddress, port);

                // Переводим наше сообщение в UTF8, а затем в массив Byte.
                Byte[] responseData = System.Text.Encoding.UTF8.GetBytes(message);
                
                // Получаем поток для чтения и записи данных.
                NetworkStream stream = client.GetStream();
               
                // Отправляем сообщение нашему серверу. 
                await stream.WriteAsync(responseData, 0, responseData.Length);

                // Получаем ответ от сервера.
                // Буфер для хранения принятого массива bytes.
                // responseData = new byte[512];
                //
                // int count;
                // // StringBuilder для склеивания полученных данных в одну строку
                // var response = new StringBuilder();
                // // Можно читать всё сообщение.
                // while ((count = stream.Read(responseData, 0, responseData.Length)) != 0)
                // {
                //     // Строка для хранения полученных UTF8 данных.
                //     String dataStr = System.Text.Encoding.UTF8.GetString(responseData, 0, count);
                //     response.Append(dataStr);
                // }
                //
                // ConsoleCreator.CreateForDotNetFramework().ShowMessage(response.ToString());

                // Закрываем всё.
                stream.Close();
                client.Close();
            } catch (ArgumentNullException
                     e) { ConsoleCreator.CreateForDotNetFramework().ShowMessage(e.Message); } catch (SocketException e)
            {
                ConsoleCreator.CreateForDotNetFramework().ShowMessage(e.Message);
            }
        }
    }
}
