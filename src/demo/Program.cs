using System;
using ILBench;
using ILBench.Engine;

namespace ILBench.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== ILBench Demo ===\n");

            try
            {
                // Get the directory where the demo executable is located
                string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;

                // Build the engine with the current directory as the scan path
                var engine = new BenchmarkEngineBuilder()
                    .AddAssemblyPath(currentDirectory)
                    .AddExcludePattern("api-ms-win")
                    .Build();

                // Discover assemblies
                var assemblies = engine.DiscoverAssemblies();

                Console.WriteLine($"Found {assemblies.Count} assemblies:\n");

                foreach (var assembly in assemblies)
                {
                    Console.WriteLine($"  • {assembly}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
