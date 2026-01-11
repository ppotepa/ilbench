using ILBench.Engine;

namespace ILBench
{
    public class BenchmarkEngineBuilder
    {
        private readonly Configuration _config;

        public BenchmarkEngineBuilder()
        {
            _config = new Configuration();
        }

        public BenchmarkEngineBuilder AddAssemblyPath(string path)
        {
            _config.AssemblyPaths.Add(path);
            return this;
        }

        public BenchmarkEngineBuilder AddExcludePattern(string pattern)
        {
            _config.ExcludePatterns.Add(pattern);
            return this;
        }

        public BenchmarkEngine Build()
        {
            if (_config.AssemblyPaths.Count == 0)
                throw new InvalidOperationException("At least one assembly path must be configured.");

            return new BenchmarkEngine(_config);
        }
    }
}
