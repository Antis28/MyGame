using MyGame.Sources.ServerCore.KeyState;
using MyGame.Sources.ServerCore.KeyStateCode;
using MyGame.Sources.ServerCore.NotECS.KeyState;

namespace MyGame.Sources.ServerCore
{
    internal class PotPlayerNavigator : IPlayerNavigator
    {
        public  void MoveRightClick(ArgumentAction _)
        {
            KeyEmulator.EmulateKeyPress(new MoveRight());
        }

        public  void MoveRight10Click(ArgumentAction _)
        {
            KeyEmulator.EmulateSendKey(new PressShift(), new PressPageDown() );
        }

        public  void MoveLeftClick(ArgumentAction _)
        {
            KeyEmulator.EmulateKeyPress(new MoveLeft());
        }

        public  void MoveLeft10Click(ArgumentAction _)
        {
            KeyEmulator.EmulateSendKey(new PressShift(), new PressPageUp());
        }

        public  void MuteClick(ArgumentAction _)
        {
            KeyEmulator.EmulateKeyPress(new Mute());
        }

        public  void NextClick(ArgumentAction _)
        {
            KeyEmulator.EmulateKeyPress(new PageDown());
        }

        public  void PreviousClick(ArgumentAction _)
        {
            KeyEmulator.EmulateKeyPress(new PageUp());
        }

        public  void PausePlayClick(ArgumentAction _)
        {
            KeyEmulator.EmulateKeyPress(new PausePlay());
        }

        public  void VolumeDownClick(ArgumentAction _)
        {
            KeyEmulator.EmulateKeyPress(new VolumeDown());
        }

        public  void VolumeUpClick(ArgumentAction _)
        {
            KeyEmulator.EmulateKeyPress(new VolumeUp());
        }
    }
}
