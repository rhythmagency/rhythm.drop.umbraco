namespace Rhythm.Drop.Umbraco.Mapping.Modals;

using global::Umbraco.Cms.Core.DependencyInjection;
using Rhythm.Drop.Models.Modals;

/// <summary>
/// A collection of extension methods that augment <see cref="IUmbracoBuilder"/> regarding <see cref="IModal"/> map definitions.
/// </summary>
public static class UmbracoBuilderExtensions
{
    /// <summary>
    /// Adds any map definition which maps to a <see cref="IModal"/>.
    /// </summary>
    /// <param name="builder">The current umbraco builder.</param>
    /// <returns>The current <see cref="IUmbracoBuilder"/>.</returns>
    public static IUmbracoBuilder AddRhythmDropModalMapDefinitions(this IUmbracoBuilder builder)
    {
        return builder.AddMapDefinitionsOfType<IModalMapDefinition>();
    }
}