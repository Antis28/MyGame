using System;
using System.IO;
using System.Threading;
using System.Windows;
using CrossConsole;
using KeyboardEmulator;
using KeyboardEmulator.ForSendInput;
using MyGame.Sources.SaveLoad;
using MyGame.Sources.ServerCore;
using Newtonsoft.Json;

namespace MyGame.Sources.Systems;

/// <summary>
/// Получает из PotPlayer информацию об адресе проигроваемого файла
/// и сохраняет адрес в файл
/// </summary>
public static class LastMovieRepository
{
    /// <summary>
    /// Получает из PotPlayer информацию об адресе проигроваемого файла
    /// и сохраняет адрес в файл
    /// </summary>
    public static void SaveFilePathFromPotPlayer(ArgumentAction _)
    {
        var emulator = new KeyEmul();
        GoToFileInfo(emulator);


                    
        GoToCopyToClipboard(emulator);
        CloseFileInfo(emulator);

        Thread.Sleep(1500);
        var filePath = GetFilePathFromClipData();

        var saveEntity = Contexts.sharedInstance.game.CreateEntity();
        if (filePath != string.Empty) { saveEntity.ReplaceSettings(filePath); }
        else
        {
            var procFinder = new KeyboardEmulator.ProcessFinder();
            var process = procFinder.GetActiveProcess();
            saveEntity.ReplaceSettings(process.MainWindowTitle);
        }
    }

    public static void LoadLastMovie(ArgumentAction _)
    {
        var sc = GetSettings();
        //FileBrowserHandler.ExecutableFile(new ArgumentAction { Argument = sc.lastFileName });

        var pot = @"C:\Program Files\DAUM\PotPlayer\PotPlayerMini64.exe";
        FileBrowserHandler.ExecutableFile(pot, sc.lastFileName);

        Thread.Sleep(1000);
        var emulator = new KeyEmul();
        emulator.SendInput(ScanCodeShort.MENU, ScanCodeShort.RETURN);

        ConsoleCreator.CreateForDotNetFramework().ShowMessage("Загружен последний видеофайл");
    }

    public static SettingsComponent GetSettings()
    {
        var path = Directory.GetCurrentDirectory() + @"\settings.json";
        if (!File.Exists(path)) return new SettingsComponent() { lastFileName = string.Empty };

        string textSettings;
        using (var sw = new StreamReader(path)) { textSettings = sw.ReadToEnd(); }

        var jsonSettings = JsonConvert.DeserializeObject<SettingsComponent>(textSettings);
        return jsonSettings;
    }

    /// <summary>
    /// Получает адрес из данных скопированных из PotPlayer
    /// </summary>
    /// <returns></returns>
    private static string GetFilePathFromClipData()
    {
        var text = GetClipText();
        var filePath = string.Empty;
        try
        {
            var sepCount = 10;
            var arr = text.Split(new[] { ':', '\r' }, sepCount);
            if (arr.Length < sepCount) { return filePath; }

            int pathIndex = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].Contains("Complete name"))
                {
                    pathIndex = i;
                    break;
                } 
            }

            filePath = (arr[pathIndex+1].Trim() + ':' + arr[pathIndex+2]).Trim();
        } catch (Exception e) { Console.WriteLine(e); }

        return filePath;
    }

    /// <summary>
    ///  Перйти на кнопку скопировать в буфер
    /// </summary>
    /// <param name="emulator"></param>
    private static void GoToCopyToClipboard(KeyEmul emulator)
    {
        emulator.SendInput(ScanCodeShort.SHIFT, ScanCodeShort.TAB);
        emulator.SendInput(ScanCodeShort.SHIFT, ScanCodeShort.TAB);
        emulator.SendInput(ScanCodeShort.SHIFT, ScanCodeShort.TAB);
        emulator.SendInput(ScanCodeShort.SHIFT, ScanCodeShort.TAB);
        emulator.SendInput(ScanCodeShort.RETURN);
    }

    /// <summary>
    /// Перйти во вкладку файл
    /// </summary>
    /// <param name="emulator"></param>
    private static void GoToFileInfo(KeyEmul emulator)
    {
        // открыть информацию о файле
        emulator.SendInput(ScanCodeShort.CONTROL, ScanCodeShort.F1);
        emulator.SendInput(ScanCodeShort.TAB);
        emulator.SendInput(ScanCodeShort.TAB);
        emulator.SendInput(ScanCodeShort.TAB);
        emulator.SendInput(ScanCodeShort.TAB);
        emulator.SendInput(ScanCodeShort.RETURN);
    }

    /// <summary>
    /// Закрыть окно информации о файле
    /// </summary>
    /// <param name="emulator"></param>
    private static void CloseFileInfo(KeyEmul emulator)
    {
        emulator.SendInput(ScanCodeShort.SHIFT, ScanCodeShort.TAB);
        emulator.SendInput(ScanCodeShort.RETURN);
    }

    // Копировать содержимое буфера обмена
    private static string GetClipText()
    {
        string res = string.Empty;
        Thread staThread = new Thread(x =>
        {
            try { res = Clipboard.GetText(); } catch (Exception ex) { res = ex.Message; }
        });
        staThread.SetApartmentState(ApartmentState.STA);
        staThread.Start();
        staThread.Join();
        return res;
    }
}
