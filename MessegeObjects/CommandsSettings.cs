using System.Collections.Generic;
using KeyboardEmulator.ForSendInput;
using Newtonsoft.Json;

namespace MessageObjects;

public class CommandSettings : IKeyStateCode
{
    [JsonConstructor]
    public CommandSettings(int repeat, ScanCodeShort vKey)
    {
        Repeat = repeat;
        VKey = vKey;
    }

    public CommandSettings()
    {
        Repeat = 1;
        VKey = ScanCodeShort.SPACE;
    }

    public int Repeat { get; }
    public ScanCodeShort VKey { get; }
}

public interface IKeyStateCode
{
    int Repeat { get; }
    ScanCodeShort VKey { get; }
}

public class CommandsSettings
{
    // string - для какой программы(плеера)
    // Dictionary<string, IKeyStateCode> - имя комманды + настройки для этой комманды
    public Dictionary<string, Dictionary<string, IKeyStateCode>> CommandList;
}

