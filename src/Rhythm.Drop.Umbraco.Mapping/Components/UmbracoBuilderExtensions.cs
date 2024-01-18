namespace Rhythm.Drop.Umbraco.Mapping.Components;

using global::Umbraco.Cms.Core.DependencyInjection;
using Rhythm.Drop.Models.Components;

/// <summary>
/// A collection of extension methods that augment <see cref="IUmbracoBuilder"/> regarding <see cref="IComponent"/> map definitions.
/// </summary>
public static class UmbracoBuilderExtensions
{
    /// <summary>
    /// Adds any map definition which maps to a <see cref="IComponent"/> or a collection of <see cref="IComponent"/>.
    /// </summary>
    /// <param name="builder">The current umbraco builder.</param>
    /// <returns>The current <see cref="IUmbracoBuilder"/>.</returns>
    public static IUmbracoBuilder AddAllRhythmDropComponentMapDefinitions(this IUmbracoBuilder builder)
    {
        return builder
            .AddRhythmDropComponentMapDefinitions()
            .AddRhythmDropComponentCollectionMapDefinitions();
    }

    /// <summary>
    /// Adds any map definition which maps to a <see cref="IComponent"/>.
    /// </summary>
    /// <param name="builder">The current umbraco builder.</param>
    /// <returns>The current <see cref="IUmbracoBuilder"/>.</returns>
    public static IUmbracoBuilder AddRhythmDropComponentMapDefinitions(this IUmbracoBuilder builder)
    {
        return builder.AddMapDefinitionsOfType<IComponentMapDefinition>();
    }

    /// <summary>
    /// Adds any map definition which maps to a collection of <see cref="IComponent"/>.
    /// </summary>
    /// <param name="builder">The current umbraco builder.</param>
    /// <returns>The current <see cref="IUmbracoBuilder"/>.</returns>
    public static IUmbracoBuilder AddRhythmDropComponentCollectionMapDefinitions(this IUmbracoBuilder builder)
    {
        return builder.AddMapDefinitionsOfType<IComponentCollectionMapDefinition>();
    }
}