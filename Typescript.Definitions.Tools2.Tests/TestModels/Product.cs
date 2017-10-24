using Typescript.Definitions.Tools2.Attributes;

namespace Typescript.Definitions.Tools2.Tests.TestModels
{
    [TsClass]
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }

        [TsIgnore]
        public double Ignored { get; set; }
    }
}