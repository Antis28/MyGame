﻿using System;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CrossConsole;
using MyGame.Sources.ServerCore.NotECS;
using Newtonsoft.Json;

namespace MyGame.Sources.ServerCore;

public static class FileBrowserHandler
{
    public static async void SendFileSystemInJson(ArgumentAction argument)
    {
        var builder = new FileSystemBuilder();
        var deep = int.Parse(argument.Argument);
        var fileSystem = builder.FillFileSystem(deep);
        var jsonText = JsonConvert.SerializeObject(fileSystem);
        try { await Connect(jsonText, argument.Ip).ConfigureAwait(false); } catch (Exception e)
        {
            ConsoleCreator.CreateForDotNetFramework().ShowMessage(e.Message);
        }
    }

    private static async Task Connect(string message, string ipAddress = "192.168.1.201", int port = 9090)
    {
        // Настраиваем его на IP нашего сервера и тот же порт.
        try
        {
            // Создаём TcpClient.
            TcpClient tcpClient = new TcpClient();
            await tcpClient.ConnectAsync(ipAddress, port); // соединение
            NetworkStream networkStream = tcpClient.GetStream();
            StreamWriter writer = new StreamWriter(networkStream, Encoding.UTF8);
            StreamReader reader = new StreamReader(networkStream, Encoding.UTF8);
            writer.AutoFlush = true;

            await writer.WriteLineAsync(message);

            string response = await reader.ReadLineAsync();
            tcpClient.Close();
            ConsoleCreator.CreateForDotNetFramework().ShowMessage(response);
        } catch (Exception e) { ConsoleCreator.CreateForDotNetFramework().ShowMessage(e.Message); }
    }

    public static void ExecutableFile(ArgumentAction argument)
    {
        var path = argument.Argument;
        ConsoleCreator.CreateForDotNetFramework().ShowMessage("exe -> " + path);

        if (!File.Exists(path))
        {
            ConsoleCreator.CreateForDotNetFramework().ShowMessage("Нет сохраненных видеофайлов");
            return;
        }

        var process = Process.Start(path);
        Thread.Sleep(1000);
        if (process != null) { WinAPI.SetForegroundWindow(process.MainWindowHandle); }
    }
    public static void ExecutableFile(string programPath, string filePath)
    {
        ConsoleCreator.CreateForDotNetFramework().ShowMessage("programPath -> " + filePath);

        if (!File.Exists(programPath) || !File.Exists(filePath))
        {
            ConsoleCreator.CreateForDotNetFramework().ShowMessage("Нет сохраненных видеофайлов");
            return;
        }

        var process = Process.Start(programPath, filePath);
        Thread.Sleep(1000);
        if (process != null)
        {
            WinAPI.SetForegroundWindow(process.MainWindowHandle);
        }
    }
}
