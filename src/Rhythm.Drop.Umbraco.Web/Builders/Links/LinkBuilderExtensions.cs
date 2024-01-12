namespace Rhythm.Drop.Umbraco.Web.Builders.Links;

using global::Umbraco.Cms.Core.Models.PublishedContent;
using global::Umbraco.Cms.Core.Strings;
using global::Umbraco.Extensions;
using Rhythm.Drop.Infrastructure.Builders.Links;
using Rhythm.Drop.Infrastructure.Builders.Links.Common;
using Rhythm.Drop.Infrastructure.Builders.Links.Url;

/// <summary>
/// A collection of extension methods to augment <see cref="ILinkBuilder"/>.
/// </summary>
public static class LinkBuilderExtensions
{
    /// <summary>
    /// Adds a HTML encoded label to the builder.
    /// </summary>
    /// <param name="builder">The current link builder.</param>
    /// <param name="label">The label.</param>
    /// <returns>A <see cref="IUrlLinkBuilder"/>.</returns>
    public static ILabelLinkBuilder WithLabel(this ILinkBuilder builder, IHtmlEncodedString? label)
    {
        if (label.IsNullOrWhiteSpace())
        {
            return builder.WithLabel(default);
        }

        return builder.WithLabel(label.ToHtmlString());
    }

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
}