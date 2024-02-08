namespace Rhythm.Drop.Umbraco.Mapping.Elements;

using global::Umbraco.Cms.Core.DependencyInjection;
using Rhythm.Drop.Models.Elements;

/// <summary>
/// A collection of extension methods that augment <see cref="IUmbracoBuilder"/> regarding <see cref="IElement"/> map definitions.
/// </summary>
public static class UmbracoBuilderExtensions
{
    /// <summary>
    /// Adds any map definition which maps to a <see cref="IElement"/>.
    /// </summary>
    /// <param name="builder">The current umbraco builder.</param>
    /// <returns>The current <see cref="IUmbracoBuilder"/>.</returns>
    public static IUmbracoBuilder AddRhythmDropElementMapDefinitions(this IUmbracoBuilder builder)
    {
        return builder.AddMapDefinitionsOfType<IElementMapDefinition>();
    }
}