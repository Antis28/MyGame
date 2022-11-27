namespace MessageObjects;

public interface ICommandMessage
{
    public string Command { get; set; }
}

public class CommandMessage : ICommandMessage
{
    public string Command { get; set; }
}

public class QueryFileSystem : ICommandMessage
{
    public string Command { get; set; }
    public string Path { get; set; }
}


