using KeyboardEmulator.ForSendInput;
using MessageObjects;

namespace MyGame.Sources.ServerCore;

public struct CommandStruct : IKeyStateCode
{
    public ScanCodeShort VKey => ScanCodeShort.KEY_M;

    public int Repeat => 1;
}
