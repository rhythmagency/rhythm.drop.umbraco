namespace Rhythm.Drop.Umbraco.Mapping.Links;

using global::Umbraco.Cms.Core.Mapping;
using global::Umbraco.Cms.Core.Models.Blocks;
using global::Umbraco.Cms.Core.Models.PublishedContent;
using Rhythm.Drop.Models.Links;

/// <summary>
/// A collection of methods to augment <see cref="MapperContext"/> to map a <see cref="ILink"/> object.
/// </summary>
public static class MapperContextLinkExtensions
{
    /// <summary>
    /// Maps a single block reference to a <typeparamref name="TLink"/>.
    /// </summary>
    /// <typeparam name="TLink">The type of the link.</typeparam>
    /// <param name="mapperContext">The current mapper context.</param>
    /// <param name="block">The block to map.</param>
    /// <returns>A <typeparamref name="TLink"/> if successful.</returns>
    public static TLink? MapLink<TLink>(this MapperContext mapperContext, IBlockReference<IPublishedElement, IPublishedElement>? block) where TLink : class, ILink
    {
        if (block is null)
        {
            return default;
        }

        return mapperContext.MapLink<TLink>(block.Content);
    }

    /// <summary>
    /// Maps a single block reference to a <see cref="ILink"/>.
    /// </summary>
    /// <param name="mapperContext">The current mapper context.</param>
    /// <param name="block">The block to map.</param>
    /// <returns>A <see cref="ILink"/> if successful.</returns>
    public static ILink? MapLink(this MapperContext mapperContext, IBlockReference<IPublishedElement, IPublishedElement>? block)
    {
        return mapperContext.MapLink<ILink>(block);
    }

    /// <summary>
    /// Maps a <see cref="IPublishedElement"/> to a <typeparamref name="TLink"/>.
    /// </summary>
    /// <typeparam name="TLink">The type of the link.</typeparam>
    /// <param name="mapperContext">The current mapper context.</param>
    /// <param name="element">The element to map.</param>
    /// <returns>A <typeparamref name="TLink"/> if successful.</returns>
    public static TLink? MapLink<TLink>(this MapperContext mapperContext, IPublishedElement? element) where TLink : class, ILink
    {
        if (element is null)
        {
            return default;
        }

        return mapperContext.Map<TLink?>(element);
    }

    /// <summary>
    /// Maps a <see cref="IPublishedElement"/> to a <see cref="ILink"/>.
    /// </summary>
    /// <param name="mapperContext">The current mapper context.</param>
    /// <param name="element">The element to map.</param>
    /// <returns>A <see cref="ILink"/> if successful.</returns>
    public static ILink? MapLink(this MapperContext mapperContext, IPublishedElement? element)
    {
        return mapperContext.MapLink<ILink>(element);
    }

    /// <summary>
    /// Maps the first item from a <see cref="BlockListModel"/> to a <typeparamref name="TLink"/>.
    /// </summary>
    /// <typeparam name="TLink">The type of the link.</typeparam>
    /// <param name="mapperContext">The current mapper context.</param>
    /// <param name="list">The list to map.</param>
    /// <returns>A <typeparamref name="TLink"/> if successful.</returns>
    public static TLink? MapLink<TLink>(this MapperContext mapperContext, BlockListModel list) where TLink : class, ILink
    {
        return mapperContext.MapLink<TLink>(list.FirstOrDefault());
    }

    /// <summary>
    /// Maps the first item from a <see cref="BlockListModel"/> to a <see cref="ILink"/>.
    /// </summary>
    /// <param name="mapperContext">The current mapper context.</param>
    /// <param name="list">The list to map.</param>
    /// <returns>A <see cref="ILink"/> if successful.</returns>
    public static ILink? MapLink(this MapperContext mapperContext, BlockListModel list)
    {
        return mapperContext.MapLink<ILink>(list);
    }
}
