using Furion;
using System.Reflection;

namespace TTShang.Web.Entry;

public class SingleFilePublish : ISingleFilePublish
{
    public Assembly[] IncludeAssemblies()
    {
        return Array.Empty<Assembly>();
    }

    public string[] IncludeAssemblyNames()
    {
        return new[]
        {
            "TTShang.Application",
            "TTShang.Core",
            "TTShang.Web.Core"
        };
    }
}