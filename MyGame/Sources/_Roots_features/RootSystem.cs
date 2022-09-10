using MyGame.Sources.ClientProcessing.Systems;
using MyGame.Sources.Systems;

public sealed class RootSystem : Feature
{
    public RootSystem(Contexts contexts)
    {
        // Init
        Add(new GetIpAddressSystem(contexts));
        Add(new InitServerSystem(contexts));
        // Input

        // Update
        Add(new ParallelProcessingSystem(contexts));
        Add(new ReadClientSystem(contexts));
        // Views / Render

        // Events (Generated)
        Add(new ConverterMessagesSystem(contexts));

        // Cleanup
        Add(new HandleDebugLogMessageSystem(contexts));
        Add(new DestroyDebugSystem(contexts));
        Add(new DestroyGameSystem(contexts));
    }
}
