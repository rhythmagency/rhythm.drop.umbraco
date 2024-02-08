# rhythm.drop.umbraco [![Publish to NuGet](https://github.com/rhythmagency/rhythm.drop.umbraco/actions/workflows/Publish-to-NuGet.yml/badge.svg)](https://github.com/rhythmagency/rhythm.drop.umbraco/actions/workflows/Publish-to-NuGet.yml) [![NuGet](https://img.shields.io/nuget/v/Rhythm.Drop.Umbraco?logo=nuget)](https://www.nuget.org/packages/Rhythm.Drop.Umbraco)

Rhythm.Drop functionality for Umbraco CMS.

Rhythm.Drop.Umbraco is meant to work along side Rhythm.Drop so be sure to read the [Rhythm.Drop readme](https://github.com/rhythmagency/rhythm.drop) and [wiki](https://github.com/rhythmagency/rhythm.drop/wiki) for more information on how the core package works.

Rhythm.Drop.Umbraco also has its own [wiki](https://github.com/rhythmagency/rhythm.drop.umbraco/wiki) which is tailored towards Umbraco functionality. 

## Startup

To get started with Rhythm Drop you will be the following;

 - Umbraco 13 web project
 - Install the Rhythm.Drop.Umbraco NuGet package

Once installed add the following to your Program.cs before the `UmbracoBuilder` calls `Build()`.

```csharp
builder
    .CreateUmbracoBuilder()
    .AddBackOffice()
    .AddWebsite()
    .AddDeliveryApi()
    .AddComposers()
    .AddRhythmDrop()
    .Build();
```

`AddRhythmDrop()` can also be included in an `IComposer` if you would prefer.

**Note:** _Rhythm.Drop_ can be added directly to the `WebApplicationBuilder` or `ServiceCollection` however this will not automatically install Umbraco specific functionality.

## Custom startup

For modifications there is an overload which supports a `Action<IRhythmDropBuilder>` for configuring web and infrastructure dependencies. The defaults for these features will always be added first time `AddRhythmDrop` is called then followed by your override functionality.

```csharp
builder
    .AddRhythmDrop((dropBuilder) =>
    {
        dropBuilder.SetComponentMetaDataFactory<MyCustomComponentMetaDataFactory>()
                   .SetDropImageTagHelperRenderer<MyCustomDropImageTagHelperRenderer>();
    });
```
