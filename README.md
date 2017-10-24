# Typescript.Definitions.Tools2

A helper library to generate typescript definition files and typescript files from c# code specifically .NET Core 2.0 Web applications.

This is a fork from [this](https://github.com/originalmoose/Typescript.Definitions.Tools) project, originally developed by [originalmoose](https://github.com/originalmoose).
Updated from .NET Core 1.0 to .NET Core 2.0.

This project took much of its inspiration from TypeLITE and the EntityFramework Core Tools project.

[TypeLITE](http://type.litesolutions.net/)

[EntityFrameworkCore](https://github.com/aspnet/EntityFramework)

# Installation

After creating a new .Net core 2.0 application add the following to dependecies and tools in `.csproj`
    
    <PackageReference Include="Typescript.Definitions.Tools2" Version="2.0.0" />

and

    <DotNetCliToolReference Include="Typescript.Definitions.Tools2" Version="2.0.0" />

After modifying the `.csproj` file, execute the command `dotnet restore`

Create a new class and have it implement `ITypedef`, example below.

    public class Typedef : ITypedef
    {
        public void Configure(IDefinitionBuilder definitionBuilder)
        {
        	/* Configure definitions here. */
        }
    }

# Definition Configuration

Inside the ConfigureDefinitions method you can create any number of definiton files. There is only a single method on IDefinitionBuilder `AddDefinition` you can use it like so.

    definitionBuilder.AddDefinition(
        def => def.For<ExampleClass>(optionalConfig => optionalConfig.Named("OverrideTypeName"))
                  .For(typeof(OtherClass))
                  .For(someAssemblyToScan)
                  //Use the following method to change the name of the definition and constants files that are generated.
                  .Filename(definitionFilename: "differentDefinitionName", constantsFilename: "differentConstantsName") 
                  //Use the following method to change the outdir of the definition files, NOT YET IMPLEMENTED/TESTED MAY NOT WORK
                  .OutDir("C:\\SomeOtherDir")
        )

Most of the methods are exactly the same as you would use in TypeLite. The only difference is the filename method, outdir method, and an optional parameter on the `For` methods that allows you to configure the type. Typelite had you chaining off the `For` to modify the type you just added it but I found the syntax for that to be confusing to read.

Assembly scanning works off of attributes, they are exactly the same (and should work the same) as TypeLite.

Once your project startup file is configured you can have the tool generate the definition files in one of two ways.

Manually execute the following from a cmd line in the Project Directory.
    
    dotnet tsd2

Add the following to the `Target` section of `.csproj` (this should regenerate the definitions after each successful build)

        <Target Name="PostBuild" AfterTargets="PostBuildEvent">
            <Exec Command="dotnet tsd2 --no-build" />
        </Target>
