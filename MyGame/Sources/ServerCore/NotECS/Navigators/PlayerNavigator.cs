using System;
using KeyboardEmulator.ForPostMessage;
using MyGame.Sources.ServerCore.KeyState;
using MyGame.Sources.ServerCore.KeyStateCode;
using MyGame.Sources.ServerCore.NotECS.KeyState;

namespace MyGame.Sources.ServerCore
{
    internal class PlayerNavigator
    {
        private readonly IPlayerNavigator _navigator;
        public PlayerNavigator(IPlayerNavigator navigator)
        {
            _navigator = navigator;
        }

        public  void MoveRightClick(ArgumentAction _)
        {
            _navigator.MoveRight();
        }

        public  void MoveRight10Click(ArgumentAction _)
        {
            _navigator.MoveRight10();
        }

        public  void MoveLeftClick(ArgumentAction _)
        {
            _navigator.MoveLeft();
        }

        public  void MoveLeft10Click(ArgumentAction _)
        {
            _navigator.MoveLeft10();
        }

        public  void MuteClick(ArgumentAction _)
        {
            _navigator.Mute();
        }

        public  void NextClick(ArgumentAction _)
        {
            _navigator.Next();
        }

        public  void PreviousClick(ArgumentAction _)
        {
            _navigator.Previous();
        }

        public  void PausePlayClick(ArgumentAction _)
        {
            _navigator.PausePlay();
        }

        public  void VolumeDownClick(ArgumentAction _)
        {
            _navigator.VolumeDown();
        }

        public void VolumeUpClick(ArgumentAction _)
        {
            _navigator.VolumeUp();
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
