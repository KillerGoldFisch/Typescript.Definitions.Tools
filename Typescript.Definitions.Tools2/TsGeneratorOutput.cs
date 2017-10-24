﻿using System;

namespace Typescript.Definitions.Tools2
{
    /// <summary>
    /// Defines output of the generator
    /// </summary>
    [Flags]
    public enum TsGeneratorOutput
    {
        Properties = 1,
        Enums = 2,
        Fields = 4,
        Constants = 8
    }
}