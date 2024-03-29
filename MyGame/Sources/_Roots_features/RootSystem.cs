﻿using MyGame.Sources.ClientProcessing.Systems;
using MyGame.Sources.SaveLoad;
using MyGame.Sources.Systems;

public sealed class RootSystem : Feature
{
    public RootSystem(Contexts contexts)
    {
        // Init
        Add(new GetIpAddressSystem(contexts));
        Add(new InitServerSystem(contexts));
        Add(new LoadSettingsSystem(contexts));
        // Input

        // Update
        Add(new ParallelProcessingSystem(contexts));
        Add(new ReadClientSystem(contexts));
        // Views / Render

        // Events (Generated)
        Add(new ConverterMessagesSystem(contexts));
        Add(new SaveSettingsSystem(contexts));
        // Cleanup
        Add(new ClearMessagesSystem(contexts));
        Add(new HandleDebugLogMessageSystem(contexts));
        Add(new DestroyDebugSystem(contexts));
        Add(new DestroyGameSystem(contexts));
    }
}
