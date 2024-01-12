namespace Rhythm.Drop.Umbraco.Web;

using Rhythm.Drop.Infrastructure;
using Rhythm.Drop.Umbraco.Web.Helpers;

/// <summary>
/// A collection of methods that augment <see cref="IRhythmDropBuilder"/> with regards to Umbraco web functionality.
/// </summary>
public static class RhythmDropBuilderExtensions
{
    /// <summary>
    /// Adds implementations provided by Umbraco web functionality.
    /// </summary>
    /// <param name="builder">The Rhythm Drop builder.</param>
    /// <returns>A <see cref="IRhythmDropBuilder"/>.</returns>
    public static IRhythmDropBuilder AddUmbracoWeb(this IRhythmDropBuilder builder)
    {
        return builder.AddUmbracoWebHelpers();
    }
}