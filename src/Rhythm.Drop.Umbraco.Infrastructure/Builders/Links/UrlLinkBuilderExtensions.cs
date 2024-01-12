namespace Rhythm.Drop.Umbraco.Infrastructure.Builders.Links;

using global::Umbraco.Cms.Core.Strings;
using global::Umbraco.Extensions;
using Rhythm.Drop.Infrastructure.Builders.Links.Url;

/// <summary>
/// A collection of extension methods to augment <see cref="IUrlLinkBuilder"/>.
/// </summary>
public static class UrlLinkBuilderExtensions
{
    /// <summary>
    /// Adds a HTML encoded label to the builder.
    /// </summary>
    /// <param name="builder">The current url link builder.</param>
    /// <param name="label">The label.</param>
    /// <returns>A <see cref="IUrlAndLabelLinkBuilder"/>.</returns>
    public static IUrlAndLabelLinkBuilder AndLabel(this IUrlLinkBuilder builder, IHtmlEncodedString? label)
    {
        if (label.IsNullOrWhiteSpace())
        {
            return builder.AndLabel(default);
        }

        return builder.AndLabel(label.ToHtmlString());
    }
}