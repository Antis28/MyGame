using KeyboardEmulator.ForSendInput;

namespace MyGame.Sources.ServerCore.KeyStateCode;

// Для SendInput
internal interface IKeyStateCode
{
    int Repeat { get; }
    ScanCodeShort VKey { get; }
}

internal struct PressShift : IKeyStateCode
{
    public ScanCodeShort VKey => ScanCodeShort.SHIFT;

    public int Repeat => 1;
}

internal struct PressPageDown : IKeyStateCode
{
    public ScanCodeShort VKey => ScanCodeShort.NEXT;

    public int Repeat => 1;
}

internal struct PressPageUp : IKeyStateCode
{
    public ScanCodeShort VKey => ScanCodeShort.PRIOR;

    public int Repeat => 1;
}
