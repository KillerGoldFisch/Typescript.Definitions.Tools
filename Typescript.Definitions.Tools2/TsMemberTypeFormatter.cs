using Typescript.Definitions.Tools2.TsModels;

namespace Typescript.Definitions.Tools2
{
    /// <summary>
    /// Defines a method used to format class member types.
    /// </summary>
    /// <param name="tsProperty">The typescript property</param>
    /// <returns>The formatted type.</returns>
    public delegate string TsMemberTypeFormatter(TsProperty tsProperty, string memberTypeName);
}