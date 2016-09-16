﻿using System;
using System.Collections;
using System.Collections.Generic;
using Typescript.Definitions.Tools.Tests.TestModels;
using Typescript.Definitions.Tools.TsModels;
using Xunit;

namespace Typescript.Definitions.Tools.Tests.TsModels
{
    public class TsCollectionTests
    {

        [Fact]
        public void WhenInitializedWithTypedArray_ItemsTypeIsSetToGenericParameter()
        {
            var target = new TsCollection(typeof(Address[]));

            Assert.Equal(typeof(Address), target.ItemsType.Type);
        }

        [Fact]
        public void WhenInitializedWithTypedCollection_ItemsTypeIsSetToGenericParameter()
        {
            var target = new TsCollection(typeof(List<Address>));

            Assert.Equal(typeof(Address), target.ItemsType.Type);
        }

        [Fact]
        public void WhenInitializedWithUnyypedCollection_ItemsTypeIsSetToAny()
        {
            var target = new TsCollection(typeof(IList));

            Assert.Equal(TsType.Any, target.ItemsType);
        }

        [Fact]
        public void WhenInitializedWithTypeNotImplementingIEnumerable_ArgumentExceptionIsThrown()
        {
            Assert.Throws<ArgumentException>(() => new TsCollection(typeof(Address)));
        }
    }
}