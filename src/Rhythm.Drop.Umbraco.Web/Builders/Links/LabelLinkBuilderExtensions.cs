namespace Rhythm.Drop.Umbraco.Web.Builders.Links;

using global::Umbraco.Cms.Core.Models.PublishedContent;
using global::Umbraco.Extensions;
using Rhythm.Drop.Infrastructure.Builders.Links.Common;
using Rhythm.Drop.Infrastructure.Builders.Links.Url;

/// <summary>
/// A collection of extension methods to augment <see cref="ILabelLinkBuilder"/> for <see cref="IPublishedContent"/> links.
/// </summary>
public static class LabelLinkBuilderExtensions
{
    /// <summary>
    /// Adds a URL from a <see cref="IPublishedContent"/> to the builder.
    /// </summary> 
    /// <param name="builder">The current label link builder.</param>
    /// <param name="content">The content to use for the URL.</param>
    /// <returns>A <see cref="IUrlAndLabelLinkBuilder"/>.</returns>
    public static IUrlAndLabelLinkBuilder AndUrl(this ILabelLinkBuilder builder, IPublishedContent? content)
    {
        return builder.AndUrl(content, default, UrlMode.Default);
    }

    /// <summary>
    /// Adds a URL from a <see cref="IPublishedContent"/> to the builder.
    /// </summary> 
    /// <param name="builder">The current label link builder.</param>
    /// <param name="content">The content to use for the URL.</param>
    /// <param name="culture">The optional content used to get the URL.</param>
    /// <param name="urlMode">The optional url mode used to get the URL.</param>
    /// <returns>A <see cref="IUrlAndLabelLinkBuilder"/>.</returns>
    public static IUrlAndLabelLinkBuilder AndUrl(this ILabelLinkBuilder builder, IPublishedContent? content, string? culture = default, UrlMode urlMode = UrlMode.Default)
    {
        if (content is null)
        {
            return builder.AndUrl(default);
        }

        var url = content.Url(culture: culture, mode: urlMode);

        return builder.AndUrl(url);
    }
}