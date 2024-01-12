namespace Rhythm.Drop.Umbraco.Infrastructure.Builders.Links;

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
}