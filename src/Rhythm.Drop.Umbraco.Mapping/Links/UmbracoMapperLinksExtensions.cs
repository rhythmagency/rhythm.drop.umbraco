namespace Rhythm.Drop.Umbraco.Mapping.Links;

using global::Umbraco.Cms.Core.Mapping;
using global::Umbraco.Cms.Core.Models.Blocks;
using Rhythm.Drop.Models.Links;

/// <summary>
/// A collection of methods to augment <see cref="IUmbracoMapper"/> to collections of <see cref="ILink"/> objects.
/// </summary>
public static class UmbracoMapperLinksExtensions
{
    /// <summary>
    /// Maps a <see cref="BlockListModel"/> to a collection of <typeparamref name="TLink"/>.
    /// </summary>
    /// <typeparam name="TLink">The type of the link.</typeparam>
    /// <param name="mapper">The current umbraco mapper.</param>
    /// <param name="list">The list to map.</param>
    /// <returns>An array of <typeparamref name="TLink"/>.</returns>
    public static TLink[] MapLinks<TLink>(this IUmbracoMapper mapper, BlockListModel list) where TLink : class, ILink
    {
        var links = new List<TLink>();
        foreach (var block in list)
        {
            var link = mapper.MapLink<TLink>(block.Content);
            if (link is null)
            {
                continue;
            }

            links.Add(link);
        }

        return [.. links];
    }

    /// <summary>
    /// Maps a <see cref="BlockListModel"/> to a collection of <see cref="ILink"/>.
    /// </summary>
    /// <param name="mapper">The current umbraco mapper.</param>
    /// <param name="list">The list to map.</param>
    /// <returns>An array of <see cref="ILink"/>.</returns>
    public static ILink[] MapLinks(this IUmbracoMapper mapper, BlockListModel list)
    {
        return mapper.MapLinks<ILink>(list);
    }
}