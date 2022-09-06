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

        // Views / Render

        // Events (Generated)

        // Cleanup
        Add(new HandleDebugLogMessageSystem(contexts));
        Add(new DestroyDebugSystem(contexts));
        //Add(new ShowAllInContextSystem(contexts));
    }
}
