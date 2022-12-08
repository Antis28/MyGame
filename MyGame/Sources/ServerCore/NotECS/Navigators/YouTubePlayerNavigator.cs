﻿using System.Collections.Generic;
using KeyboardEmulator.ForSendInput;
using MessageObjects;
using MyGame.Sources.ServerCore.NotECS.KeyState;
using Newtonsoft.Json;
using File = System.IO.File;

namespace MyGame.Sources.ServerCore;

internal class YouTubePlayerNavigator : IPlayerNavigator
{
    private readonly Dictionary<string, IKeyStateCode> _commandSettings;

    public YouTubePlayerNavigator()
    {
        // CreateFileSettings();
    }

    public YouTubePlayerNavigator(Dictionary<string, IKeyStateCode> commandSettings)
    {
        //CreateFileSettings();
        _commandSettings = commandSettings;
    }


    private static void CreateFileSettings()
    {
        var settings = new CommandsSettings
        {
            CommandList = new Dictionary<string, Dictionary<string, IKeyStateCode>>
            {
                {
                    "YouTubePlayer", new Dictionary<string, IKeyStateCode>
                    {
                        { "MoveRight", new MoveRightStruct() },
                        { "MoveRight10", new MoveRight10Struct() },
                        { "MoveLeft", new MoveLeftStruct() },
                        { "MoveLeft10", new MoveLeft10Struct() },
                        { "Next", new NextStruct() },
                        { "Prev", new PrevStruct() },
                        { "PausePlay", new PausePlayStruct() },
                        { "VolumeDown", new VolumeDownStruct() },
                        { "VolumeUp", new VolumeUpStruct() },
                    }
                }
            }
        };


        var jsonTypeNameAll = JsonConvert.SerializeObject(settings, Formatting.Indented, new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Auto
        });

        // serialize JSON to a string and then write string to a file
        File.WriteAllText(@"c:\command settings2.json", jsonTypeNameAll);
    }

    public void MoveRight() => KeyEmulator.EmulateSendKey(_commandSettings["MoveRight"] ?? new MoveRightStruct());
    public void MoveRight10() => KeyEmulator.EmulateSendKey(_commandSettings["MoveRight10"] ?? new MoveRight10Struct());
    public void MoveLeft() => KeyEmulator.EmulateSendKey(_commandSettings["MoveLeft"] ?? new MoveLeftStruct());
    public void MoveLeft10() => KeyEmulator.EmulateSendKey(_commandSettings["MoveLeft10"] ?? new MoveLeft10Struct());
    public void Mute() => KeyEmulator.EmulateSendKey(_commandSettings["Mute"] ?? new MuteStruct());
    public void Next() => KeyEmulator.EmulateSendKey(_commandSettings["Next"] ?? new NextStruct());
    public void Previous() => KeyEmulator.EmulateSendKey(_commandSettings["Previous"] ?? new PrevStruct());
    public void PausePlay() => KeyEmulator.EmulateSendKey(_commandSettings["PausePlay"] ?? new PausePlayStruct());
    public void VolumeDown() => KeyEmulator.EmulateSendKey(_commandSettings["VolumeDown"] ?? new VolumeDownStruct());
    public void VolumeUp() => KeyEmulator.EmulateSendKey(_commandSettings["VolumeUp"] ?? new VolumeUpStruct());

    #region Nested Types

    private struct MoveLeft10Struct : IKeyStateCode
    {
        public ScanCodeShort VKey => ScanCodeShort.KEY_J;
        public int Repeat => 3;
    }

    private struct MoveLeftStruct : IKeyStateCode
    {
        public ScanCodeShort VKey => ScanCodeShort.LEFT;

        public int Repeat => 1;
    }

    private struct MoveRight10Struct : IKeyStateCode
    {
        public ScanCodeShort VKey => ScanCodeShort.KEY_L;
        public int Repeat => 3;
    }

    private struct MoveRightStruct : IKeyStateCode
    {
        public ScanCodeShort VKey => ScanCodeShort.RIGHT;

        public int Repeat => 1;
    }

    private struct MuteStruct : IKeyStateCode
    {
        public ScanCodeShort VKey => ScanCodeShort.KEY_M;

        public int Repeat => 1;
    }

    private struct NextStruct : IKeyStateCode
    {
        public ScanCodeShort VKey => ScanCodeShort.KEY_N;

        public int Repeat => 1;
    }

    private struct PausePlayStruct : IKeyStateCode
    {
        public ScanCodeShort VKey => ScanCodeShort.KEY_K;

        public int Repeat => 1;
    }

    private struct PrevStruct : IKeyStateCode
    {
        public ScanCodeShort VKey => ScanCodeShort.KEY_P;

        public int Repeat => 1;
    }

    private struct ShiftStruct : IKeyStateCode
    {
        public ScanCodeShort VKey => ScanCodeShort.SHIFT;
        public int Repeat => 1;
    }

    private struct VolumeDownStruct : IKeyStateCode
    {
        public ScanCodeShort VKey => ScanCodeShort.DOWN;

        public int Repeat => 1;
    }

    private struct VolumeUpStruct : IKeyStateCode
    {
        public ScanCodeShort VKey => ScanCodeShort.UP;

        public int Repeat => 1;
    }

    #endregion
}
