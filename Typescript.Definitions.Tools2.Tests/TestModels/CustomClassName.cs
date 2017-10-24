using Typescript.Definitions.Tools2.Attributes;

namespace Typescript.Definitions.Tools2.Tests.TestModels
{
    [TsClass(Name = "MyClass", Module = "MyModule")]
    public class CustomClassName
    {
        [TsProperty(Name = "MyProperty")]
        public int CustomPorperty { get; set; }
    }
}