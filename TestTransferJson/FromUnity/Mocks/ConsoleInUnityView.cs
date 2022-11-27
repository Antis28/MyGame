using System;

namespace TestTransferJson.FromUnity;

public static class ConsoleInUnityView
{
    public static void ShowError(Exception e)
    {
        Console.WriteLine($"Error: {e.Message}");
    }
}