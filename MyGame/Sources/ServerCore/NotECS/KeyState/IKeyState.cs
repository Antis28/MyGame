using System;

namespace MyGame.Sources.ServerCore.KeyState;

internal interface IKeyState
{
    int Repeat { get; }
    Int32 VKey { get; }
}
