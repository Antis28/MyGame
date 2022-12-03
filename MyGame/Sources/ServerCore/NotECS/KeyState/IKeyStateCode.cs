using KeyboardEmulator.ForSendInput;

namespace MyGame.Sources.ServerCore.KeyStateCode;

internal interface IKeyStateCode
{
    int Repeat { get; }
    ScanCodeShort VKey { get; }
}
