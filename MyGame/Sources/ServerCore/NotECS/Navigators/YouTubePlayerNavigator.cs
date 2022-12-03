using KeyboardEmulator.ForPostMessage;
using MyGame.Sources.ServerCore.KeyState;
using MyGame.Sources.ServerCore.NotECS.KeyState;
using System;
using KeyboardEmulator.ForSendInput;
using MyGame.Sources.ServerCore.KeyStateCode;

namespace MyGame.Sources.ServerCore;

internal class YouTubePlayerNavigator : IPlayerNavigator
{
    public void MoveRight() =>  KeyEmulator.EmulateSendKey(new MoveRightStruct());
    public void MoveRight10() => KeyEmulator.EmulateSendKey(new MoveRight10Struct()); 
    public void MoveLeft() => KeyEmulator.EmulateSendKey(new MoveLeftStruct()); 
    public void MoveLeft10() => KeyEmulator.EmulateSendKey(new MoveLeft10Struct()); 
    public void Mute() => KeyEmulator.EmulateSendKey(new MuteStruct()); 
    public void Next() => KeyEmulator.EmulateSendKey(new ShiftStruct(),new NextStruct()); 
    public void Previous() => KeyEmulator.EmulateSendKey(new ShiftStruct(), new PrevStruct()); 
    public void PausePlay() => KeyEmulator.EmulateSendKey(new PausePlayStruct()); 
    public void VolumeDown ()=> KeyEmulator.EmulateSendKey(new VolumeDownStruct()); 
    public void VolumeUp() => KeyEmulator.EmulateSendKey(new VolumeUpStruct());

    #region Nested Types

    private struct MoveLeftStruct : IKeyStateCode
    {
        public ScanCodeShort VKey => ScanCodeShort.LEFT;

        public int Repeat => 1;
    }

    private struct MoveLeft10Struct : IKeyStateCode
    {
        public ScanCodeShort VKey => ScanCodeShort.KEY_J;
        public int Repeat => 3;
    }

    private struct MoveRightStruct : IKeyStateCode
    {
        public ScanCodeShort VKey => ScanCodeShort.RIGHT;

        public int Repeat => 1;
    }

    private struct MoveRight10Struct : IKeyStateCode
    {
        public ScanCodeShort VKey => ScanCodeShort.KEY_L;
        public int Repeat => 3;
    }

    private struct MuteStruct : IKeyStateCode
    {
        public ScanCodeShort VKey => ScanCodeShort.KEY_M;

        public int Repeat => 1;
    }

    private struct PrevStruct : IKeyStateCode
    {
        public ScanCodeShort VKey => ScanCodeShort.KEY_P;

        public int Repeat => 1;
    }

    private struct NextStruct : IKeyStateCode
    {
        public ScanCodeShort VKey => ScanCodeShort.KEY_N;

        public int Repeat => 1;
    }

    private struct PausePlayStruct : IKeyStateCode
    {
        public ScanCodeShort VKey => ScanCodeShort.KEY_K;

        public int Repeat => 1;
    }

    private struct VolumeDownStruct : IKeyStateCode
    {
        public ScanCodeShort VKey => ScanCodeShort.DOWN;

        public int Repeat => 1;
    }

    private struct VolumeUpStruct : IKeyStateCode
    {
        public ScanCodeShort VKey => ScanCodeShort.UP;

        public int Repeat => 1;
    }
    
    private struct ShiftStruct : IKeyStateCode
    {
        public ScanCodeShort VKey => ScanCodeShort.SHIFT;
        public int Repeat => 1;
    }

    #endregion
}