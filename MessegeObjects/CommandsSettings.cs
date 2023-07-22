using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;
using KeyboardEmulator.ForSendInput;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MessageObjects;

//[JsonConverter(typeof(CommandSettingsConverter))]
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

    //[JsonProperty]
    public int Repeat { get; private set; }

    [JsonConverter(typeof(StringEnumConverter))]
    public ScanCodeShort VKey { get; private set; }


    
}

public interface IKeyStateCode
{
    int Repeat { get;}

    [JsonConverter(typeof(StringEnumConverter))]
    ScanCodeShort VKey { get;}
}

public class CommandsSettings
{
    // string - для какой программы(плеера)
    // Dictionary<string, IKeyStateCode> - имя комманды + настройки для этой комманды
    public Dictionary<string, Dictionary<string, IKeyStateCode>> CommandList;
}














public class CommandSettingsConverter : JsonConverter
{
    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        CommandSettings commandsettings = (CommandSettings)value;

        writer.WriteValue(commandsettings.VKey.ToString());
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {        
        string value = (string)reader.Value;
        ScanCodeShort scanCodeShort = (ScanCodeShort)Enum.Parse(typeof(ScanCodeShort), value, true);
        CommandSettings commandsettings = new CommandSettings(1, scanCodeShort);

        return commandsettings;
    }

    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(CommandSettings);
    }
}