using Typescript.Definitions.Tools2.Attributes;

namespace Typescript.Definitions.Tools2.Tests.TestModels.Namespace2
{
    [TsClass]
    public class DifferentNamespaces_Class2
    {
        public string Property2 { get; set; }
        public string Property1 { get; set; }
    }

}

namespace Typescript.Definitions.Tools2.Tests.TestModels.Namespace1
{
    [TsClass]
    public class DifferentNamespaces_Class3
    {

    }
}

namespace Typescript.Definitions.Tools2.Tests.TestModels.Namespace2
{
    [TsClass]
    public class DifferentNamespaces_Class1
    {

    }
}
