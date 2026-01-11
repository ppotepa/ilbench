using System;

namespace ILBench.Models
{
    public class AssemblyInfo
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public Version Version { get; set; }

        public AssemblyInfo(string name, string path, Version version)
        {
            Name = name;
            Path = path;
            Version = version;
        }

        public override string ToString()
        {
            return $"{Name} v{Version} ({Path})";
        }
    }
}
