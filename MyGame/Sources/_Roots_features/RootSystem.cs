using MyGame.Sources.Systems;

public sealed class RootSystem : Feature
{
    public RootSystem(Contexts contexts)
    {
        // Init
        Add(new InitServerSystem(contexts));
        // Input

        // Update

        // Views / Render

        // Events (Generated)

        // Cleanup
        Add(new LogAddressInfoSystem(contexts));
        Add(new HandleDebugLogMessageSystem(contexts));
        Add(new DestroyDebugSystem(contexts));
    }
}
