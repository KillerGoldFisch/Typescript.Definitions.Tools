using System;

namespace Typescript.Definitions.Tools2.Attributes
{
    /// <summary>
    /// Configures property to be ignored by the script generator.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class TsIgnoreAttribute : Attribute
    {
    }
}