using KeyboardEmulator.ForSendInput;
using MessageObjects;

namespace MyGame.Sources.ServerCore.KeyStateCode;

// Для SendInput

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
