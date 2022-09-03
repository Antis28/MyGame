using MyGame.Sources.Systems;
using MyGame.Sources.Systems.Logging;

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
        Add(new HandleDebugLogMessageSystem(contexts));
        Add(new DestroyDebugSystem(contexts));
    }
}
