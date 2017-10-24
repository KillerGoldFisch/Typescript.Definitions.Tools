using Typescript.Definitions.Tools2.TsModels;

namespace Typescript.Definitions.Tools2
{
    /// <summary>
    /// Formats a module name
    /// </summary>
    /// <param name="module">The module to be formatted</param>
    /// <returns>The module name after formatting.</returns>
    public delegate string TsModuleNameFormatter(TsModule module);
}