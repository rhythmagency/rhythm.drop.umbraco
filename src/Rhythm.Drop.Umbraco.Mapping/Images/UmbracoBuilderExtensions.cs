namespace Rhythm.Drop.Umbraco.Mapping.Images;

using global::Umbraco.Cms.Core.DependencyInjection;
using Rhythm.Drop.Models.Images;

/// <summary>
/// A collection of extension methods that augment <see cref="IUmbracoBuilder"/> regarding <see cref="IImage"/> map definitions.
/// </summary>
public static class UmbracoBuilderExtensions
{
    /// <summary>
    /// Adds any map definition which maps to a <see cref="IImage"/>.
    /// </summary>
    /// <param name="builder">The current umbraco builder.</param>
    /// <returns>The current <see cref="IUmbracoBuilder"/>.</returns>
    public static IUmbracoBuilder AddRhythmDropImageMapDefinitions(this IUmbracoBuilder builder)
    {
        return builder.AddMapDefinitionsOfType<IImageMapDefinition>();
    }
}