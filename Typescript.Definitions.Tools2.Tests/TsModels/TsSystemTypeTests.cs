﻿using System;
using Typescript.Definitions.Tools2.Tests.TestModels;
using Typescript.Definitions.Tools2.TsModels;
using Xunit;

namespace Typescript.Definitions.Tools2.Tests.TsModels
{
    public class TsSystemTypeTests
    {

        [Fact]
        public void WhenInitializedWithBool_KindIsSetToBool()
        {
            var target = new TsSystemType(typeof(bool));

            Assert.Equal(SystemTypeKind.Bool, target.Kind);
        }

        [Fact]
        public void WhenInitializedWithInt_KindIsSetToNumber()
        {
            var target = new TsSystemType(typeof(int));

            Assert.Equal(SystemTypeKind.Number, target.Kind);
        }

        [Fact]
        public void WhenInitializedWithDouble_KindIsSetToNumber()
        {
            var target = new TsSystemType(typeof(double));

            Assert.Equal(SystemTypeKind.Number, target.Kind);
        }

        [Fact]
        public void WhenInitializedWithDecimal_KindIsSetToNumber()
        {
            var target = new TsSystemType(typeof(decimal));

            Assert.Equal(SystemTypeKind.Number, target.Kind);
        }

        [Fact]
        public void WhenInitializedWithString_KindIsSetToString()
        {
            var target = new TsSystemType(typeof(string));

            Assert.Equal(SystemTypeKind.String, target.Kind);
        }

        [Fact]
        public void WhenInitializedWithDateTime_KindIsSetToDate()
        {
            var target = new TsSystemType(typeof(DateTime));

            Assert.Equal(SystemTypeKind.Date, target.Kind);
        }

        [Fact]
        public void WhenInitializedWithNullableType_KindIsSetAccordingToUnderlayingType()
        {
            var target = new TsSystemType(typeof(int?));

            Assert.Equal(SystemTypeKind.Number, target.Kind);
        }

        [Fact]
        public void WhenInitializedWithUnsupportedType_ExceptionIsThrown()
        {
            Assert.Throws<ArgumentException>(() => new TsSystemType(typeof(Address)));
        }
    }
}