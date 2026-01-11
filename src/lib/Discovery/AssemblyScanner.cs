using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using ILBench.Models;

namespace ILBench.Discovery
{
    public class AssemblyScanner
    {
        private readonly Configuration _config;

        public AssemblyScanner(Configuration config)
        {
            _config = config;
        }

        public List<AssemblyInfo> ScanForAssemblies()
        {
            var results = new List<AssemblyInfo>();

            foreach (var path in _config.AssemblyPaths)
            {
                if (!Directory.Exists(path))
                    continue;

                var dllFiles = Directory.GetFiles(path, "*.dll", SearchOption.AllDirectories);

                foreach (var dllFile in dllFiles)
                {
                    if (ShouldExclude(dllFile))
                        continue;

                    try
                    {
                        var assemblyName = AssemblyName.GetAssemblyName(dllFile);
                        var info = new AssemblyInfo(
                            assemblyName.Name ?? Path.GetFileNameWithoutExtension(dllFile),
                            dllFile,
                            assemblyName.Version ?? new Version(0, 0, 0, 0)
                        );
                        results.Add(info);
                    }
                    catch
                    {
                        // Skip assemblies that cannot be read
                    }
                }
            }

            return results.OrderBy(a => a.Name).ToList();
        }

        private bool ShouldExclude(string filePath)
        {
            foreach (var pattern in _config.ExcludePatterns)
            {
                if (filePath.Contains(pattern))
                    return true;
            }
            return false;
        }
    }
}
