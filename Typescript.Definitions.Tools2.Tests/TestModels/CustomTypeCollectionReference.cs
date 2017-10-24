using System.Collections.Generic;
using Microsoft.DotNet.Cli.Utils;

namespace Typescript.Definitions.Tools2.Tests.TestModels
{
    public class CustomTypeCollectionReference
    {
        public Product[] Products { get; set; }
        public IEnumerable<Person> People { get; set; }
    }
}