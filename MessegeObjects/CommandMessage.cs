namespace MessageObjects;

public interface ICommandMessage
{
    public string Command { get; set; }
    public string Argument { get; set; }
}

public class CommandMessage : ICommandMessage
{
    public string Command { get; set; }
    public string Argument { get; set; }
}


