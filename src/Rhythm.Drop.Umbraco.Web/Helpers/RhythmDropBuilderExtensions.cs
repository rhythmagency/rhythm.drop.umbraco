namespace Rhythm.Drop.Umbraco.Web.Helpers;

using Rhythm.Drop.Infrastructure;
using Rhythm.Drop.Web.Infrastructure.Helpers;

/// <summary>
/// A collection of extension methods that augment <see cref="IRhythmDropBuilder"/> regarding Umbraco Web Helpers.
/// </summary>
public static class RhythmDropBuilderExtensions
{
    /// <summary>
    /// Registers Umbraco web helper dependencies for Rhythm Drop.
    /// </summary>
    /// <param name="builder">The current <see cref="IRhythmDropBuilder"/>.</param>
    /// <remarks>Returns the current <see cref="IRhythmDropBuilder"/>.</remarks>
    public static IRhythmDropBuilder AddUmbracoWebHelpers(this IRhythmDropBuilder builder)
    {
        builder.SetModalPersistenceHelper<UmbracoModalPersistenceHelper>();

        return builder;
    }
}
