namespace Rhythm.Drop.Umbraco.Mapping.Links;

using global::Umbraco.Cms.Core.DependencyInjection;
using Rhythm.Drop.Models.Links;

/// <summary>
/// A collection of extension methods that augment <see cref="IUmbracoBuilder"/> regarding <see cref="ILink"/> map definitions.
/// </summary>
public static class UmbracoBuilderExtensions
{
    /// <summary>
    /// Adds any map definition which maps to a <see cref="ILink"/>.
    /// </summary>
    /// <param name="builder">The current umbraco builder.</param>
    /// <returns>The current <see cref="IUmbracoBuilder"/>.</returns>
    public static IUmbracoBuilder AddRhythmDropLinkMapDefinitions(this IUmbracoBuilder builder)
    {
        return builder.AddMapDefinitionsOfType<ILinkMapDefinition>();
    }
}