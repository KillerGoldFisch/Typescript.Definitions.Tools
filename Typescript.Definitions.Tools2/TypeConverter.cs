﻿namespace Typescript.Definitions.Tools2
{
    /// <summary>
    /// Defines a method used to convert specific Type to the string representation.
    /// </summary>
    /// <param name="type">The type to convert.</param>
    /// <returns>The string representation of the type.</returns>
    public delegate string TypeConverter(object type);
}