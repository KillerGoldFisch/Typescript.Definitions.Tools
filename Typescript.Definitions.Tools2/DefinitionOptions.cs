using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Typescript.Definitions.Tools2.TsModels;

namespace Typescript.Definitions.Tools2
{
    public class DefinitionOptions
    {
        public Dictionary<Type, TsTypeFormatter> TypeFormatters { get; } = new Dictionary<Type, TsTypeFormatter>();

        public Dictionary<Type, TypeConverter> TypeConverters { get; } = new Dictionary<Type, TypeConverter>();

        public char IndentationChar { get; set; } = ' ';

        public TsMemberIdentifierFormatter MemberFormatter { get; set; }

        public TsMemberTypeFormatter MemberTypeFormatter { get; set; }

        public TsModuleNameFormatter ModuleNameFormatter { get; set; }

        public TsTypeVisibilityFormatter TypeVisibilityFormatter { get; set; }

        public List<string> References { get; } = new List<string>();

        public bool GenerateConstEnums { get; set; } = true;

        public string DefinitionFileName { get; set; } = "index";

        public string ConstFileName { get; set; } = "constants";

        public string OutDir { get; set; }

        public DefinitionOptions()
        {
            MemberFormatter = DefaultMemberFormatter;
            MemberTypeFormatter = DefaultMemberTypeFormatter;
            ModuleNameFormatter = DefaultModuleNameFormatter;
            TypeVisibilityFormatter = DefaultTypeVisibilityFormatter;
        }

        public bool DefaultTypeVisibilityFormatter(TsClass tsClass, string typeName)
        {
            return false;
        }

        public string DefaultModuleNameFormatter(TsModule module)
        {
            return module.Name;
        }

        public string DefaultMemberFormatter(TsProperty identifier)
        {
            return identifier.Name;
        }

        public string DefaultMemberTypeFormatter(TsProperty tsProperty, string memberTypeName)
        {
            var asCollection = tsProperty.PropertyType as TsCollection;
            var isCollection = asCollection != null;

            return memberTypeName + (isCollection ? string.Concat(Enumerable.Repeat("[]", asCollection.Dimension)) : "");
        }

    }
}