using System;
using MessageObjects;
using Newtonsoft.Json;
using File = System.IO.File;

namespace MyGame.Sources.ServerCore
{
    internal class PlayerNavigator
    {
        private readonly IPlayerNavigator _potNavigator;
        private readonly IPlayerNavigator _youTubeNavigator;
        private IPlayerNavigator _navigator;
        private CommandsSettings _commandSettings;

        public PlayerNavigator()
        {
            InitSettingsFromFile();
            // _potNavigator = new PotPlayerNavigator(_commandSettings?.CommandList["PotPlayer"]);
            // _youTubenavigator = new YouTubePlayerNavigator(_commandSettings?.CommandList["YouTubePlayer"]);
            _potNavigator = new Navigator(_commandSettings?.CommandList["PotPlayer"]);
            _youTubeNavigator = new Navigator(_commandSettings?.CommandList["YouTubePlayer"]);

            _navigator = _potNavigator;
        }

        public void MoveRightClick(ArgumentAction argument)
        {
            SelectPlayer(argument);
            _navigator.MoveRight();
        }

        public void MoveRight10Click(ArgumentAction argument)
        {
            SelectPlayer(argument);
            _navigator.MoveRight10();
        }

        public void MoveLeftClick(ArgumentAction argument)
        {
            SelectPlayer(argument);
            _navigator.MoveLeft();
        }

        public void MoveLeft10Click(ArgumentAction argument)
        {
            SelectPlayer(argument);
            _navigator.MoveLeft10();
        }

        public void MuteClick(ArgumentAction argument)
        {
            SelectPlayer(argument);
            _navigator.Mute();
        }

        public void NextClick(ArgumentAction argument)
        {
            SelectPlayer(argument);
            _navigator.Next();
        }

        public void PreviousClick(ArgumentAction argument)
        {
            SelectPlayer(argument);
            _navigator.Previous();
        }

        public void PausePlayClick(ArgumentAction argument)
        {
            SelectPlayer(argument);
            _navigator.PausePlay();
        }

        public void VolumeDownClick(ArgumentAction argument)
        {
            SelectPlayer(argument);
            _navigator.VolumeDown();
        }

        public void VolumeUpClick(ArgumentAction argument)
        {
            SelectPlayer(argument);
            _navigator.VolumeUp();
        }

        private void InitSettingsFromFile()
        {
            var path = Environment.CurrentDirectory + @"\command settings.json";
            if (!File.Exists(path))
            {
                Console.WriteLine("Файл настроек комманд не существует");
                return;
            }

            // deserialize JSON directly from a file

            var text = File.ReadAllText(path);
            _commandSettings = JsonConvert.DeserializeObject<CommandsSettings>(text, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });
        }

        private void SelectPlayer(ArgumentAction argument)
        {
            var playerType = argument.Argument;
            _navigator = playerType switch
            {
                "Pot Player" => _potNavigator,
                "YouTube Player" => _youTubeNavigator,
                _ => _navigator
            };
        }
    }

    // internal class PlayerNavigator2
    // {
    //     private readonly IPlayerNavigator _navigator;
    //     public PlayerNavigator2(IPlayerNavigator navigator)
    //     {
    //         _navigator = navigator;
    //     }
    //
    //     public  void MoveRightClick(ArgumentAction _)
    //     {
    //         KeyEmulator.EmulateKeyPress(_navigator.MoveRight);
    //     }
    //
    //     public  void MoveRight10Click(ArgumentAction _)
    //     {
    //         KeyEmulator.EmulateKeyPress(_navigator.MoveRight10);
    //         // KeyEmulator.EmulateSendKey(new PressShift(), new PressPageDown() );
    //     }
    //
    //     public  void MoveLeftClick(ArgumentAction _)
    //     {
    //         KeyEmulator.EmulateKeyPress(_navigator.MoveLeft);
    //     }
    //
    //     public  void MoveLeft10Click(ArgumentAction _)
    //     {
    //         KeyEmulator.EmulateKeyPress(_navigator.MoveLeft10);
    //         // KeyEmulator.EmulateSendKey(new PressShift(), new PressPageUp());
    //     }
    //
    //     public  void MuteClick(ArgumentAction _)
    //     {
    //         KeyEmulator.EmulateKeyPress(_navigator.Mute);
    //     }
    //
    //     public  void NextClick(ArgumentAction _)
    //     {
    //         KeyEmulator.EmulateKeyPress(_navigator.Next);
    //     }
    //
    //     public  void PreviousClick(ArgumentAction _)
    //     {
    //         KeyEmulator.EmulateKeyPress(_navigator.Previous);
    //     }
    //
    //     public  void PausePlayClick(ArgumentAction _)
    //     {
    //         KeyEmulator.EmulateKeyPress(_navigator.PausePlay);
    //     }
    //
    //     public  void VolumeDownClick(ArgumentAction _)
    //     {
    //         KeyEmulator.EmulateKeyPress(_navigator.VolumeDown);
    //     }
    //
    //     public void VolumeUpClick(ArgumentAction _)
    //     {
    //         KeyEmulator.EmulateKeyPress(_navigator.VolumeUp);
    //     }
    //
    // }
}
