using Newtonsoft.Json;
using System.Runtime.Serialization;

public class SerializationEventTestObject
{
    // 2222
    // This member is serialized and deserialized with no change.
    public int Member1 { get; set; }

    // The value of this field is set and reset during and 
    // after serialization.
    public string Member2 { get; set; }

    // This field is not serialized. The OnDeserializedAttribute 
    // is used to set the member value after serialization.
    [JsonIgnore]
    public string Member3 { get; set; }

    // This field is set to null, but populated after deserialization.
    public string Member4 { get; set; }

    public SerializationEventTestObject()
    {
        Member1 = 11;
        Member2 = "Hello World!";
        Member3 = "This is a nonserialized value";
        Member4 = null;
    }

    [OnSerializing]
    internal void OnSerializingMethod(StreamingContext context)
    {
        Member2 = "This value went into the data file during serialization.";
    }

    [OnSerialized]
    internal void OnSerializedMethod(StreamingContext context)
    {
        Member2 = "This value was reset after serialization.";
    }

    [OnDeserializing]
    internal void OnDeserializingMethod(StreamingContext context)
    {
        Member3 = "This value was set during deserialization";
    }

    [OnDeserialized]
    internal void OnDeserializedMethod(StreamingContext context)
    {
        Member4 = "This value was set after deserialization.";
    }
}
