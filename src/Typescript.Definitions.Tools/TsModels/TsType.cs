﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Typescript.Definitions.Tools.Extensions;

namespace Typescript.Definitions.Tools.TsModels
{
    public class TsType
    {
        /// <summary>
        /// Gets the CLR type represented by this instance of the TsType.
        /// </summary>
        public Type Type { get; }

        private TypeInfo _typeinfo;
        public TypeInfo TypeInfo => _typeinfo ?? (_typeinfo = Type.GetTypeInfo());

        /// <summary>
        /// Initializes a new instance of the TsType class with the specific CLR type.
        /// </summary>
        /// <param name="type">The CLR type represented by this instance of the TsType.</param>
        public TsType(Type type)
        {
            if (type.IsNullable())
            {
                type = type.GetNullableValueType();
            }

            Type = type;
        }

        /// <summary>
        /// Represents the TsType for the object CLR type.
        /// </summary>
        public static readonly TsType Any = new TsType(typeof(object));


        /// <summary>
        /// Returns true if this property is collection
        /// </summary>
        /// <returns></returns>
        public bool IsCollection()
        {
            return GetTypeFamily(Type) == TsTypeFamily.Collection;
        }



        /// <summary>
        /// Gets TsTypeFamily of the CLR type.
        /// </summary>
        /// <param name="type">The CLR type to get TsTypeFamily of</param>
        /// <returns>TsTypeFamily of the CLR type</returns>
        internal static TsTypeFamily GetTypeFamily(Type type)
        {
            if (type.IsNullable())
            {
                return GetTypeFamily(type.GetNullableValueType());
            }

            var isString = (type == typeof(string));
            var isEnumerable = typeof(IEnumerable).IsAssignableFrom(type);

            // surprisingly  Decimal isn't a primitive type
            if (isString || type.GetTypeInfo().IsPrimitive || type.FullName == "System.Decimal" || type.FullName == "System.DateTime" || type.FullName == "System.DateTimeOffset" || type.FullName == "System.SByte")
            {
                return TsTypeFamily.System;
            }
            else if (isEnumerable)
            {
                return TsTypeFamily.Collection;
            }

            if (type.GetTypeInfo().IsEnum)
            {
                return TsTypeFamily.Enum;
            }

            if ((type.GetTypeInfo().IsClass && type.FullName != "System.Object") || type.GetTypeInfo().IsValueType /* structures */ || type.GetTypeInfo().IsInterface)
            {
                return TsTypeFamily.Class;
            }

            return TsTypeFamily.Type;
        }

        /// <summary>
        /// Factory method so that the correct TsType can be created for a given CLR type.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        internal static TsType Create(Type type)
        {
            var family = GetTypeFamily(type);
            switch (family)
            {
                case TsTypeFamily.System:
                    return new TsSystemType(type);
                case TsTypeFamily.Collection:
                    return new TsCollection(type);
                case TsTypeFamily.Class:
                    return new TsClass(type);
                case TsTypeFamily.Enum:
                    return new TsEnum(type);
                default:
                    return new TsType(type);
            }
        }

        /// <summary>
        /// Gets type of items in generic version of IEnumerable.
        /// </summary>
        /// <param name="type">The IEnumerable type to get items type from</param>
        /// <returns>The type of items in the generic IEnumerable or null if the type doesn't implement the generic version of IEnumerable.</returns>
        internal static Type GetEnumerableType(Type type)
        {
            if (type.GetTypeInfo().IsGenericType && type.GetGenericTypeDefinition() == typeof(IEnumerable<>))
            {
                return type.GetGenericArguments()[0];
            }

            foreach (Type intType in type.GetInterfaces())
            {
                if (intType.GetTypeInfo().IsGenericType && intType.GetGenericTypeDefinition() == typeof(IEnumerable<>))
                {
                    return intType.GetGenericArguments()[0];
                }
            }
            return null;
        }
    }
}
