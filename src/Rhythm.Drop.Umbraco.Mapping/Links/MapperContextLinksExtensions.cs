namespace Rhythm.Drop.Umbraco.Mapping.Links;

using global::Umbraco.Cms.Core.Mapping;
using global::Umbraco.Cms.Core.Models.Blocks;
using Rhythm.Drop.Models.Links;

/// <summary>
/// A collection of methods to augment <see cref="MapperContext"/> to map to collections of <see cref="ILink"/> objects.
/// </summary>
public static class MapperContextLinksExtensions
{
    /// <summary>
    /// Maps a <see cref="BlockListModel"/> to a collection of <typeparamref name="TLink"/>.
    /// </summary>
    /// <typeparam name="TLink">The type of the link.</typeparam>
    /// <param name="mapperContext">The current mapper context.</param>
    /// <param name="list">The list to map.</param>
    /// <returns>An array of <typeparamref name="TLink"/>.</returns>
    public static TLink[] MapLinks<TLink>(this MapperContext mapperContext, BlockListModel list) where TLink : class, ILink
    {
        var links = new List<TLink>();
        foreach (var block in list)
        {
            var link = mapperContext.MapLink<TLink>(block.Content);
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
    /// <param name="mapperContext">The current mapper context.</param>
    /// <param name="list">The list to map.</param>
    /// <returns>An array of <see cref="ILink"/>.</returns>
    public static ILink[] MapLinks(this MapperContext mapperContext, BlockListModel list)
    {
        return mapperContext.MapLinks<ILink>(list);
    }
}