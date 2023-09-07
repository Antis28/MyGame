using System;
using System.Collections.Generic;
using MessageObjects;
using Newtonsoft.Json;
using File = System.IO.File;

namespace MyGame.Sources.ServerCore
{
    internal class PlayerNavigator
    {
        private readonly Dictionary<string, IPlayerNavigator> _navigatorList;

        private IPlayerNavigator _navigator;
        private CommandsSettings _commandSettings;

        public PlayerNavigator()
        {
            InitSettingsFromFile();

            _navigatorList = new Dictionary<string, IPlayerNavigator>
            {
                { "Pot Player", new Navigator(_commandSettings?.CommandList["PotPlayer"]) },
                { "YouTubePlayer", new Navigator(_commandSettings?.CommandList["YouTubePlayer"]) },
                { "AnilibriaPlayer", new Navigator(_commandSettings?.CommandList["AnilibriaPlayer"]) },
            };
            _navigator = _navigatorList["Pot Player"];
        }

        public void MoveRightClick(ArgumentAction argument)
        {
            var (playerType, stepCount) = ArgumentParser(argument.Argument);
            SelectPlayer(playerType);
            _navigator.MoveRight(stepCount);
        }

        public void MoveRight10Click(ArgumentAction argument)
        {
            var (playerType, stepCount) = ArgumentParser(argument.Argument);
            SelectPlayer(playerType);
            _navigator.MoveRight(stepCount);
        }

        public void MoveLeftClick(ArgumentAction argument)
        {
            var (playerType, stepCount) = ArgumentParser(argument.Argument);
            SelectPlayer(playerType);
            _navigator.MoveLeft(stepCount);
        }

        public void MoveLeft10Click(ArgumentAction argument)
        {
            var (playerType, stepCount) = ArgumentParser(argument.Argument);

            SelectPlayer(playerType);
            _navigator.MoveLeft(stepCount);
        }

        public void MuteClick(ArgumentAction argument)
        {
            SelectPlayer(argument.Argument);
            _navigator.Mute();
        }

        public void NextClick(ArgumentAction argument)
        {
            SelectPlayer(argument.Argument);
            _navigator.Next();
        }

        public void PreviousClick(ArgumentAction argument)
        {
            SelectPlayer(argument.Argument);
            _navigator.Previous();
        }

        public void PausePlayClick(ArgumentAction argument)
        {
            SelectPlayer(argument.Argument);
            _navigator.PausePlay();
        }

        public void VolumeDownClick(ArgumentAction argument)
        {
            SelectPlayer(argument.Argument);
            _navigator.VolumeDown();
        }

        public void VolumeUpClick(ArgumentAction argument)
        {
            SelectPlayer(argument.Argument);
            _navigator.VolumeUp();
        }

        private void InitSettingsFromFile()
        {
            var path = Environment.CurrentDirectory + @"\command settings.json";
            if (!File.Exists(path))
            {
                // TODO: Переделать в логер ECS(DI)
                var message = "Файл настроек комманд не существует - command settings.json";
                Main.Logger.ShowMessage(message);
                return;
            }

            // deserialize JSON directly from a file

            var text = File.ReadAllText(path);
            _commandSettings = JsonConvert.DeserializeObject<CommandsSettings>(text, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });

            //var lastFileName = JsonConvert.SerializeObject(entity.settings);
            //entity.isDestroyed = true;

            //using (var sw = new StreamWriter(Directory.GetCurrentDirectory() + @"\settings.json"))
            //{
            //    sw.Write(lastFileName);
            //}
        }

        private void SelectPlayer(string playerType)
        {
            _navigator = _navigatorList[playerType];
        }

        private (string playerType, int stepCount) ArgumentParser(string argument)
        {
            var args = argument.Split('&');
            var count = 1;
            if (args.Length > 1)
                int.TryParse(args[1], out count);
            return (args[0], count);
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
