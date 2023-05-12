using System.Collections.Generic;
using MessageObjects;
using MyGame.Sources.ServerCore.NotECS.KeyState;

namespace MyGame.Sources.ServerCore;

class Navigator : IPlayerNavigator
{
    private readonly Dictionary<string, IKeyStateCode> _commandSettings;

    public Navigator(Dictionary<string, IKeyStateCode> commandSettings)
    {
        _commandSettings = commandSettings;
    }

    public void MoveRight() => KeyEmulator.EmulateSendKey(_commandSettings["MoveRight"]);

    public void MoveRight(int count)
    {
        var command = new CommandSettings(count, _commandSettings["MoveRight"].VKey);
        KeyEmulator.EmulateSendKey(command);
    }

    public void MoveRight10() => KeyEmulator.EmulateSendKey(_commandSettings["MoveRight10"]);
    public void MoveLeft() => KeyEmulator.EmulateSendKey(_commandSettings["MoveLeft"]);

    public void MoveLeft(int count)
    {
        var command = new CommandSettings(count, _commandSettings["MoveLeft"].VKey);
        KeyEmulator.EmulateSendKey(command);
    }

    public void MoveLeft10() => KeyEmulator.EmulateSendKey(_commandSettings["MoveLeft10"]);
    public void Mute() => KeyEmulator.EmulateSendKey(_commandSettings["Mute"]);
    public void Next() => KeyEmulator.EmulateSendKey(_commandSettings["Next"]);
    public void Previous() => KeyEmulator.EmulateSendKey(_commandSettings["Previous"]);
    public void PausePlay() => KeyEmulator.EmulateSendKey(_commandSettings["PausePlay"]);
    public void VolumeDown() => KeyEmulator.EmulateSendKey(_commandSettings["VolumeDown"]);
    public void VolumeUp() => KeyEmulator.EmulateSendKey(_commandSettings["VolumeUp"]);
}
