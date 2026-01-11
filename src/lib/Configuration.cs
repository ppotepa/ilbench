using System;
using System.Collections.Generic;

namespace ILBench
{
    public class Configuration
    {
        public List<string> AssemblyPaths { get; set; }
        public List<string> ExcludePatterns { get; set; }

        public Configuration()
        {
            AssemblyPaths = new List<string>();
            ExcludePatterns = new List<string>();
        }
    }
}
