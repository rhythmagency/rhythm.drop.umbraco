namespace Rhythm.Drop.Umbraco.Mapping.Links;

using global::Umbraco.Cms.Core.Mapping;
using global::Umbraco.Cms.Core.Models.Blocks;
using global::Umbraco.Cms.Core.Models.PublishedContent;
using Rhythm.Drop.Models.Links;

/// <summary>
/// A collection of methods to augment <see cref="IUmbracoMapper"/> to map <see cref="ILink"/> objects.
/// </summary>
public static class UmbracoMapperLinkExtensions
{
    /// <summary>
    /// Maps a single block reference to a <typeparamref name="TLink"/>.
    /// </summary>
    /// <typeparam name="TLink">The type of the link.</typeparam>
    /// <param name="mapper">The current umbraco mapper.</param>
    /// <param name="block">The block to map.</param>
    /// <returns>A <typeparamref name="TLink"/> if successful.</returns>
    public static TLink? MapLink<TLink>(this IUmbracoMapper mapper, IBlockReference<IPublishedElement, IPublishedElement>? block) where TLink : class, ILink
    {
        if (block is null)
        {
            return default;
        }

        return mapper.MapLink<TLink>(block.Content);
    }

    /// <summary>
    /// Maps a single block reference to a <see cref="ILink"/>.
    /// </summary>
    /// <param name="mapper">The current umbraco mapper.</param>
    /// <param name="block">The block to map.</param>
    /// <returns>A <see cref="ILink"/> if successful.</returns>
    public static ILink? MapLink(this IUmbracoMapper mapper, IBlockReference<IPublishedElement, IPublishedElement>? block)
    {
        return mapper.MapLink<ILink>(block);
    }

    /// <summary>
    /// Maps a <see cref="IPublishedElement"/> to a <typeparamref name="TLink"/>.
    /// </summary>
    /// <typeparam name="TLink">The type of the link.</typeparam>
    /// <param name="mapper">The current umbraco mapper.</param>
    /// <param name="element">The element to map.</param>
    /// <returns>A <typeparamref name="TLink"/> if successful.</returns>
    public static TLink? MapLink<TLink>(this IUmbracoMapper mapper, IPublishedElement? element) where TLink : class, ILink
    {
        if (element is null)
        {
            return default;
        }

        return mapper.Map<TLink?>(element);
    }

    /// <summary>
    /// Maps a <see cref="IPublishedElement"/> to a <see cref="ILink"/>.
    /// </summary>
    /// <param name="mapper">The current umbraco mapper.</param>
    /// <param name="element">The element to map.</param>
    /// <returns>A <see cref="ILink"/> if successful.</returns>
    public static ILink? MapLink(this IUmbracoMapper mapper, IPublishedElement? element)
    {
        return mapper.MapLink<ILink>(element);
    }

    /// <summary>
    /// Maps the first item from a <see cref="BlockListModel"/> to a <typeparamref name="TLink"/>.
    /// </summary>
    /// <typeparam name="TLink">The type of the link.</typeparam>
    /// <param name="mapper">The current umbraco mapper.</param>
    /// <param name="list">The list to map.</param>
    /// <returns>A <typeparamref name="TLink"/> if successful.</returns>
    public static TLink? MapLink<TLink>(this IUmbracoMapper mapper, BlockListModel list) where TLink : class, ILink
    {
        return mapper.MapLink<TLink>(list.FirstOrDefault());
    }

    /// <summary>
    /// Maps the first item from a <see cref="BlockListModel"/> to a <see cref="ILink"/>.
    /// </summary>
    /// <param name="mapper">The current umbraco mapper.</param>
    /// <param name="list">The list to map.</param>
    /// <returns>A <see cref="ILink"/> if successful.</returns>
    public static ILink? MapLink(this IUmbracoMapper mapper, BlockListModel list)
    {
        return mapper.MapLink<ILink>(list);
    }
}