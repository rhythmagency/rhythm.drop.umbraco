namespace Rhythm.Drop.Umbraco;

using global::Umbraco.Cms.Core.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Rhythm.Drop.Infrastructure;
using Rhythm.Drop.Umbraco.Web;

/// <summary>
/// A collection of extension methods that augment implementations of <see cref="IUmbracoBuilder"/> regarding Rhythm Drop.
/// </summary>
public static class UmbracoBuilderExtensions
{
    /// <summary>
    /// Adds Rhythm Drop with default dependencies and Umbraco specific dependencies to the current <see cref="IUmbracoBuilder"/>.
    /// </summary>
    /// <param name="builder">The current Umbraco builder.</param>
    /// <returns>A <see cref="IUmbracoBuilder"/>.</returns>
    /// <remarks>For custom functionality use <see cref="AddRhythmDrop(IUmbracoBuilder, Action{IRhythmDropBuilder})"/>.</remarks>
    public static IUmbracoBuilder AddRhythmDrop(this IUmbracoBuilder builder)
    {
        builder.AddRhythmDrop((dropBuilder) => {});

        return builder;
    }

    /// <summary>
    /// Adds Rhythm Drop with default dependencies and Umbraco specific dependencies to the current <see cref="IUmbracoBuilder"/> plus additional overrides.
    /// </summary>
    /// <param name="builder">The current Umbraco builder.</param>
    /// <param name="configure">The configuration action.</param>
    /// <returns>A <see cref="IUmbracoBuilder"/>.</returns>
    /// <remarks>Default settings (e.g. Infrastructure and Web) are add the first time this method is called.</remarks>
    public static IUmbracoBuilder AddRhythmDrop(this IUmbracoBuilder builder, Action<IRhythmDropBuilder> configure)
    {
        builder.Services.AddRhythmDrop((dropBuilder) =>
        {
            if (builder.Services.HasRhythmDropUmbracoDefaultsAddedMarker() is false)
            {
                dropBuilder.AddUmbracoWeb();
                builder.Services.AddRhythmDropUmbracoDefaultsAddedMarker();
            }

            configure(dropBuilder);
        });

        return builder;
    }

    /// <summary>
    /// Checks if the <see cref="RhythmDropUmbracoDefaultsAddedMarker"/> exists in the current <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The current services.</param>
    /// <returns>A <see cref="bool"/> which represents whether it was found or not.</returns>
    private static bool HasRhythmDropUmbracoDefaultsAddedMarker(this IServiceCollection services)
    {
        return services.Any(x => x.ServiceType == typeof(RhythmDropUmbracoDefaultsAddedMarker));
    }

    /// <summary>
    /// Adds the <see cref="RhythmDropUmbracoDefaultsAddedMarker"/> to the current <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The current services.</param>
    /// <returns>A <see cref="IServiceCollection"/>.</returns>
    private static IServiceCollection AddRhythmDropUmbracoDefaultsAddedMarker(this IServiceCollection services)
    {
        services.AddSingleton<RhythmDropUmbracoDefaultsAddedMarker>();
        return services;
    }

}
