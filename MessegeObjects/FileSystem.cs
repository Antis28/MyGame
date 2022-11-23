using System.Collections.Generic;
using Newtonsoft.Json;

namespace MessageObjects
{
    public class FileSystem
    {
        public List<Disk> Disks { get; set; }
    }

    public class Disk : Directory
    {
        public string Label { get; set; }
    }

    public class Directory
    {
        public string Name { get; set; }
        public List<Directory> Directories { get; set; }
        public List<File> Files { get; set; }

        [JsonIgnore] public Directory Root { get; set; }
    }

    public class File
    {
        public string Name { get; set; }
    }
}
