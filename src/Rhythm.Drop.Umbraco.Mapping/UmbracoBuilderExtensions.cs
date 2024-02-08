namespace Rhythm.Drop.Umbraco.Mapping;

using global::Umbraco.Cms.Core.Composing;
using global::Umbraco.Cms.Core.DependencyInjection;
using global::Umbraco.Cms.Core.Mapping;
using Rhythm.Drop.Umbraco.Mapping.Components;
using Rhythm.Drop.Umbraco.Mapping.Elements;
using Rhythm.Drop.Umbraco.Mapping.Images;
using Rhythm.Drop.Umbraco.Mapping.Links;

/// <summary>
/// A collection of extension methods that augment <see cref="IUmbracoBuilder"/> regarding mapping.
/// </summary>
public static class UmbracoBuilderExtensions
{
    /// <summary>
    /// Adds all Rhythm Drop Umbraco map definitions for support types.
    /// </summary>
    /// <param name="builder">The current umbraco builder.</param>
    /// <returns>The current <see cref="IUmbracoBuilder"/>.</returns>
    public static IUmbracoBuilder AddAllRhythmDropMapDefinitions(this IUmbracoBuilder builder)
    {
        return builder
            .AddAllRhythmDropComponentMapDefinitions()
            .AddRhythmDropElementMapDefinitions()
            .AddRhythmDropImageMapDefinitions()
            .AddRhythmDropLinkMapDefinitions();
    }

    internal static IUmbracoBuilder AddMapDefinitionsOfType<TMapDefinition>(this IUmbracoBuilder builder) where TMapDefinition : class, IMapDefinition, IDiscoverable
    {
        builder.MapDefinitions().Add(builder.TypeLoader.GetTypes<TMapDefinition>());

        return builder;
    }
}
