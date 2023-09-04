using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MessageObjects;
using NUnit.Framework;
using Directory = MessageObjects.Directory;
using File = MessageObjects.File;

namespace MyGame.Sources;

public class FileSystemBuilder
{
    private FileSystem _fileSystem;
    private List<string> _exceptPath;

    public FileSystem FillFileSystem(int deep)
    {
        _exceptPath = ReadDirFromFile();
        _fileSystem = new FileSystem()
        {
            Disks = new List<Disk>()
        };
        var allDrives = System.IO.DriveInfo.GetDrives();
        var disks =
            from driveInfo in allDrives
            where driveInfo.DriveType.ToString() == "Fixed"
            select new Disk
            {
                Name = driveInfo.Name,
                Label = driveInfo.VolumeLabel,
                Directories = new List<Directory>(),
                Files = new List<File>(),
            };
        _fileSystem.Disks.AddRange(disks);
        FillDirectories(deep);
        return _fileSystem;
    }

    private void FillDirectories(int deep)
    {
        foreach (var disk in _fileSystem.Disks)
        {
            var dirs = System.IO.Directory.GetDirectories(disk.Name);
            var files = FillFiles(disk.Name);
            var dirList = FillSubDir(dirs, deep);
            disk.Directories.AddRange(dirList);
            disk.Files.AddRange(files);
        }
    }

    private List<Directory> FillSubDir(IEnumerable<string> dirs, int deep)
    {
        if (deep == 0) return null;
        var dirList = new List<Directory>();

        foreach (var dir in dirs)
        {
            var dirPathArray = TryGetDirPathArray(dir);
            if (dirPathArray == null) { continue; }

            var localDeep = deep;
            dirList.Add(
                new Directory
                {
                    Name = dir,
                    Directories = FillSubDir(dirPathArray, --localDeep),
                    Files = FillFiles(dir)
                }
            );
        }

        return dirList;
    }

    

    private List<File> FillFiles(string path)
    {
        var files = TryGetFilesPathArray(path);

        return files?.Select(file => new File() { Name = file }).ToList();
    }
    private IEnumerable<string> TryGetDirPathArray(string path)
    {
        if (_exceptPath.Contains(path))
        {
            return null;
        }
        IEnumerable<string> dirPathArray = null;
        try { dirPathArray = System.IO.Directory.GetDirectories(path); } catch (Exception e)
        {
            // TODO: Выделить в нормальный логер
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(e);
            Console.ResetColor();
            WriteDirToFile(path);
        }

        return dirPathArray;
    }


    private IEnumerable<string> TryGetFilesPathArray(string path)
    {
        
        IEnumerable<string> files = null;
        try { files = System.IO.Directory.GetFiles(path); } catch (Exception e)
        {
            // TODO: Выделить в нормальный логер
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(e);
            Console.ResetColor();
            WriteFilePathToFile(path);
        }

        return files;
    }

    private static void WriteFilePathToFile(string path)
    {
        var pathExept = "exceptFiles.txt";
        // добавление в файл
        using (var writer = new StreamWriter(pathExept, true)) { writer.WriteLine(path); }
    }
    
    private static void WriteDirToFile(string dir)
    {
        var path = "exceptDir.txt";
        // добавление в файл
        using (var writer = new StreamWriter(path, true)) { writer.WriteLine(dir); }
    }

    private static List<string> ReadDirFromFile()
    {
        var path = "exceptDir.txt";
        var dirString = new List<string>();
        
        // асинхронное чтение
        using (var reader = new StreamReader(path))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                dirString.Add(line);
            }
        }

        return dirString;
    }
}
