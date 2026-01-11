PROJECT ilbench
  TYPE library + demo
  TARGET net8.0
  LANG csharp
  NAMESPACE_STYLE old-style-braces
  
  # HOW TO DEVELOP THIS FILE:
  # - Each FEATURE must map to actual classes/methods in the codebase
  # - Format: FEATURE [name] -> file:Class.method_signature
  # - Update STATE whenever new features are added or modified
  # - Keep COMPONENTS list in sync with filesystem
  # - Indent nested structures with 2 spaces
  # - Use file: prefix for file paths, Class.method for code references
  
  STRUCTURE
    src/lib
      TYPE classlib
      NAME ILBench
      EXPORTED true
      DEPS []
      COMPONENTS
        Engine/
          - BenchmarkEngine.cs
          - BenchmarkEngineBuilder.cs
        Discovery/
          - AssemblyScanner.cs
        Models/
          - AssemblyInfo.cs
        Configuration.cs
    
    src/demo
      TYPE console
      NAME ILBench.Demo
      EXPORTED false
      DEPS [ILBench]

  STATUS phase_1_core_engine_complete
  
  FEATURES
    FEATURE assembly_info_model
      FILE src/lib/Models/AssemblyInfo.cs
      CLASS AssemblyInfo
      METHODS
        - new(name:string, path:string, version:Version)
        - ToString() -> string
      PROPS
        - Name:string
        - Path:string
        - Version:Version
    
    FEATURE configuration_system
      FILE src/lib/Configuration.cs
      CLASS Configuration
      METHODS
        - new()
      PROPS
        - AssemblyPaths:List<string>
        - ExcludePatterns:List<string>
    
    FEATURE assembly_scanner_discovery
      FILE src/lib/Discovery/AssemblyScanner.cs
      CLASS AssemblyScanner
      METHODS
        - new(config:Configuration)
        - ScanForAssemblies() -> List<AssemblyInfo>
        - ShouldExclude(filePath:string) -> bool
      LOGIC
        - Scans directory paths for *.dll files
        - Applies exclusion patterns
        - Reads assembly metadata
        - Returns sorted list by name
    
    FEATURE benchmark_engine
      FILE src/lib/Engine/BenchmarkEngine.cs
      CLASS BenchmarkEngine
      METHODS
        - new(config:Configuration)
        - DiscoverAssemblies() -> List<AssemblyInfo>
      LOGIC
        - Orchestrates discovery via AssemblyScanner
        - Centralizes engine operations
    
    FEATURE benchmark_engine_builder_fluent
      FILE src/lib/Engine/BenchmarkEngineBuilder.cs
      CLASS BenchmarkEngineBuilder
      METHODS
        - new()
        - AddAssemblyPath(path:string) -> BenchmarkEngineBuilder
        - AddExcludePattern(pattern:string) -> BenchmarkEngineBuilder
        - Build() -> BenchmarkEngine
      LOGIC
        - Fluent builder pattern
        - Validates at least one path configured
        - Returns configured BenchmarkEngine
    
    FEATURE demo_console_discovery
      FILE src/demo/Program.cs
      CLASS Program
      METHODS
        - Main(args:string[]) -> void
      LOGIC
        - Creates builder instance
        - Configures current directory as scan path
        - Builds engine
        - Discovers and displays all assemblies


