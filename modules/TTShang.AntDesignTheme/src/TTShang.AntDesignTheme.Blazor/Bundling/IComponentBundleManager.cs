using System.Collections.Generic;
using System.Threading.Tasks;

namespace TTShang.AntDesignTheme.Blazor.Bundling;

public interface IComponentBundleManager
{
    Task<IReadOnlyList<string>> GetStyleBundleFilesAsync(string bundleName);

    Task<IReadOnlyList<string>> GetScriptBundleFilesAsync(string bundleName);
}
