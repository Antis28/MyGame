using System;
using KeyboardEmulator.ForPostMessage;
using KeyboardEmulator.ForSendInput;
using MyGame.Sources.ServerCore.KeyState;
using MyGame.Sources.ServerCore.KeyStateCode;
using MyGame.Sources.ServerCore.NotECS.KeyState;

namespace MyGame.Sources.ServerCore;

internal class PotPlayerNavigator : IPlayerNavigator
{
    public void MoveRight() =>  KeyEmulator.EmulateSendKey(new MoveRightStruct());
    public void MoveRight10() => KeyEmulator.EmulateSendKey(new MoveRight10Struct()); 
    public void MoveLeft() => KeyEmulator.EmulateSendKey(new MoveLeftStruct()); 
    public void MoveLeft10() => KeyEmulator.EmulateSendKey(new MoveLeft10Struct()); 
    public void Mute() => KeyEmulator.EmulateSendKey(new MuteStruct()); 
    public void Next() => KeyEmulator.EmulateSendKey(new NextStruct()); 
    public void Previous() => KeyEmulator.EmulateSendKey(new PrevStruct()); 
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
        public ScanCodeShort VKey => ScanCodeShort.LEFT;
        public int Repeat => 10;
    }

    private struct MoveRightStruct : IKeyStateCode
    {
        public ScanCodeShort VKey => ScanCodeShort.RIGHT;

        public int Repeat => 1;
    }

    private struct MoveRight10Struct : IKeyStateCode
    {
        public ScanCodeShort VKey => ScanCodeShort.RIGHT;
        public int Repeat => 10;
    }

    private struct MuteStruct : IKeyStateCode
    {
        public ScanCodeShort VKey => ScanCodeShort.KEY_M;

        public int Repeat => 1;
    }

    private struct PrevStruct : IKeyStateCode
    {
        public ScanCodeShort VKey => ScanCodeShort.PRIOR;

        public int Repeat => 1;
    }

    private struct NextStruct : IKeyStateCode
    {
        public ScanCodeShort VKey => ScanCodeShort.NEXT;

        public int Repeat => 1;
    }

    private struct PausePlayStruct : IKeyStateCode
    {
        public ScanCodeShort VKey => ScanCodeShort.SPACE;

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
