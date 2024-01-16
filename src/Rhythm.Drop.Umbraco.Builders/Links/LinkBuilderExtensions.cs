namespace Rhythm.Drop.Umbraco.Web.Builders.Links;

using global::Umbraco.Cms.Core.Models.PublishedContent;
using global::Umbraco.Extensions;
using Rhythm.Drop.Builders.Links;
using Rhythm.Drop.Builders.Links.Url;

/// <summary>
/// A collection of extension methods to augment <see cref="ILinkBuilder"/>.
/// </summary>
public static class LinkBuilderExtensions
{
    /// <summary>
    /// Adds a URL from a <see cref="IPublishedContent"/> to the builder.
    /// </summary> 
    /// <param name="builder">The current link builder.</param>
    /// <param name="content">The content to use for the URL.</param>
    /// <returns>A <see cref="IUrlLinkBuilder"/>.</returns>
    public static IUrlLinkBuilder WithUrl(this ILinkBuilder builder, IPublishedContent? content)
    {
        return builder.WithUrl(content, default, UrlMode.Default);
    }

    /// <summary>
    /// Adds a URL from a <see cref="IPublishedContent"/> to the builder.
    /// </summary> 
    /// <param name="builder">The current link builder.</param>
    /// <param name="content">The content to use for the URL.</param>
    /// <param name="culture">The optional content used to get the URL.</param>
    /// <param name="mode">The optional mode used to get the URL.</param>
    /// <returns>A <see cref="IUrlLinkBuilder"/>.</returns>
    public static IUrlLinkBuilder WithUrl(this ILinkBuilder builder, IPublishedContent? content, string? culture = default, UrlMode mode = UrlMode.Default)
    {
        if (content is null)
        {
            return builder.WithUrl(default);
        }

        var url = content.Url(culture, mode);

        return builder.WithUrl(url);
    }

    /// <summary>
    /// Adds a Media URL from a <see cref="IPublishedContent"/> to the builder.
    /// </summary> 
    /// <param name="builder">The current link builder.</param>
    /// <param name="content">The content to use for the URL.</param>
    /// <param name="culture">The optional content used to get the URL.</param>
    /// <param name="mode">The optional mode used to get the URL.</param>
    /// <param name="propertyAlias">The property alias to get the URL.</param>
    /// <returns>A <see cref="IUrlLinkBuilder"/>.</returns>
    /// <remarks>This generally shouldn't be necessary. See <see cref="FriendlyPublishedContentExtensions.MediaUrl(IPublishedContent, string?, UrlMode, string)"/> for use cases.</remarks>
    public static IUrlLinkBuilder WithMediaUrl(this ILinkBuilder builder, IPublishedContent? content, string? culture = default, UrlMode mode = UrlMode.Default, string propertyAlias = global::Umbraco.Cms.Core.Constants.Conventions.Media.File)
    {
        if (content is null)
        {
            return builder.WithUrl(default);
        }

        var url = content.MediaUrl(culture, mode, propertyAlias);

        return builder.WithUrl(url);
    }
}