using System.Collections.Generic;
using MessageObjects;
using MyGame.Sources.ServerCore.NotECS.KeyState;

namespace MyGame.Sources.ServerCore
{

    public class Navigator : IPlayerNavigator
    {
        private readonly Dictionary<string, IKeyStateCode> _commandSettings;

        public Navigator(Dictionary<string, IKeyStateCode> commandSettings)
        {
            _commandSettings = commandSettings;
        }

        public void MoveRight() => KeyEmulatorHandler.EmulateSendKey(_commandSettings["MoveRight"]);

        public void MoveRight(int count)
        {
            var command = new CommandSettings(count, _commandSettings["MoveRight"].VKey);
            KeyEmulatorHandler.EmulateSendKey(command);
        }

        public void MoveRight10() => KeyEmulatorHandler.EmulateSendKey(_commandSettings["MoveRight10"]);
        public void MoveLeft() => KeyEmulatorHandler.EmulateSendKey(_commandSettings["MoveLeft"]);

        public void MoveLeft(int count)
        {
            var command = new CommandSettings(count, _commandSettings["MoveLeft"].VKey);
            KeyEmulatorHandler.EmulateSendKey(command);
        }



        public virtual void MoveLeft10() => KeyEmulatorHandler.EmulateSendKey(_commandSettings["MoveLeft10"]);
        public virtual void Mute() => KeyEmulatorHandler.EmulateSendKey(_commandSettings["Mute"]);
        public virtual void Next() => KeyEmulatorHandler.EmulateSendKey(_commandSettings["Next"]);
        public virtual void Previous() => KeyEmulatorHandler.EmulateSendKey(_commandSettings["Previous"]);
        public virtual void PausePlay() => KeyEmulatorHandler.EmulateSendKey(_commandSettings["PausePlay"]);
        public void VolumeDown() => KeyEmulatorHandler.EmulateSendKey(_commandSettings["VolumeDown"]);
        public void VolumeUp() => KeyEmulatorHandler.EmulateSendKey(_commandSettings["VolumeUp"]);
    }
}