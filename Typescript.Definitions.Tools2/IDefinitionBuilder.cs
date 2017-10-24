using System;

namespace Typescript.Definitions.Tools2
{
    public interface IDefinitionBuilder
    {
        IDefinitionBuilder AddDefinition(Action<DefinitionOptionsBuilder> setup);
    }
}