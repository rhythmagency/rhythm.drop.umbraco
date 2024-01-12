namespace Rhythm.Drop.Umbraco.Infrastructure.Builders.Links;

using global::Umbraco.Cms.Core.Strings;
using global::Umbraco.Extensions;
using Rhythm.Drop.Infrastructure.Builders.Links.Modals;

/// <summary>
/// A collection of extension methods to augment <see cref="IModalLinkBuilder"/>.
/// </summary>
public static class ModalLinkBuilderExtensions
{
    /// <summary>
    /// Adds a HTML encoded label to the builder.
    /// </summary>
    /// <param name="builder">The current modal link builder.</param>
    /// <param name="label">The label.</param>
    /// <returns>A <see cref="IModalAndLabelLinkBuilder"/>.</returns>
    public static IModalAndLabelLinkBuilder AndLabel(this IModalLinkBuilder builder, IHtmlEncodedString? label)
    {
        if (label.IsNullOrWhiteSpace())
        {
            return builder.AndLabel(default);
        }

        return builder.AndLabel(label.ToHtmlString());
    }
}