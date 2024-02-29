namespace Rhythm.Drop.Umbraco.Mapping.Links;

using global::Umbraco.Cms.Core.Mapping;
using global::Umbraco.Cms.Core.Models.Blocks;
using Rhythm.Drop.Models.Links;

/// <summary>
/// A collection of methods to augment <see cref="IUmbracoMapper"/> to collections of <see cref="ILink"/> objects.
/// </summary>
public static class UmbracoMapperLinksExtensions
{
    private static readonly Action<MapperContext> _defaultContextFunc = (c) => { };

    /// <summary>
    /// Maps a <see cref="BlockListModel"/> to a collection of <typeparamref name="TLink"/>.
    /// </summary>
    /// <typeparam name="TLink">The type of the link.</typeparam>
    /// <param name="mapper">The current umbraco mapper.</param>
    /// <param name="list">The list to map.</param>
    /// <param name="configureContext">The optional configure mapper context action.</param>
    /// <returns>
    /// <para>An array of <typeparamref name="TLink"/>.</para>
    /// <para>This method will return an empty collection if <paramref name="list"/> is <see langword="null"/>.</para>
    /// </returns>
    public static TLink[] MapLinks<TLink>(this IUmbracoMapper mapper, BlockListModel? list, Action<MapperContext>? configureContext = default) where TLink : class, ILink
    {
        if (list is null)
        {
            return [];
        }

        var links = new List<TLink>();
        foreach (var block in list)
        {
            var link = mapper.MapLink<TLink>(block, configureContext);
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
    /// <param name="configureContext">The optional configure mapper context action.</param>
    /// <returns>
    /// <para>An array of <see cref="ILink"/>.</para>
    /// <para>This method will return an empty collection if <paramref name="list"/> is <see langword="null"/>.</para>
    /// </returns>
    public static ILink[] MapLinks(this IUmbracoMapper mapper, BlockListModel? list, Action<MapperContext>? configureContext = default)
    {
        return mapper.MapLinks<ILink>(list, configureContext);
    }
}