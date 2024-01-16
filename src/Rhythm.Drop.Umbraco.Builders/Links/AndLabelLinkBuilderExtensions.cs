namespace Rhythm.Drop.Umbraco.Builders.Links;

using global::Umbraco.Cms.Core.Strings;
using global::Umbraco.Extensions;
using Rhythm.Drop.Builders.Links;

/// <summary>
/// A collection of extension methods to augment <see cref="IAndLabelLinkBuilder{TBuilder}"/>.
/// </summary>
public static class AndLabelLinkBuilderExtensions
{
    /// <summary>
    /// Adds a HTML encoded label to the builder.
    /// </summary>
    /// <param name="builder">The current link builder.</param>
    /// <param name="label">The label.</param>
    /// <returns>A  <typeparamref name="TBuilder"/>.</returns>
    public static TBuilder AndLabel<TBuilder>(this IAndLabelLinkBuilder<TBuilder> builder, IHtmlEncodedString? label)
    {
        if (label.IsNullOrWhiteSpace())
        {
            return builder.AndLabel(default);
        }

        return builder.AndLabel(label.ToHtmlString());
    }
}