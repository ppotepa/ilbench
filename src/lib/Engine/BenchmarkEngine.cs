using ILBench.Discovery;

namespace ILBench.Engine
{
    public class BenchmarkEngine
    {
        private readonly Configuration _config;
        private readonly AssemblyScanner _scanner;

        public BenchmarkEngine(Configuration config)
        {
            _config = config;
            _scanner = new AssemblyScanner(config);
        }

        public List<Models.AssemblyInfo> DiscoverAssemblies()
        {
            return _scanner.ScanForAssemblies();
        }
    }
}
