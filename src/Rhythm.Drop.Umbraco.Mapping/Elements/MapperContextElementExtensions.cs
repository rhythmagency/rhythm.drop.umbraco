namespace Rhythm.Drop.Umbraco.Mapping.Elements;

using global::Umbraco.Cms.Core.Mapping;
using global::Umbraco.Cms.Core.Models.Blocks;
using global::Umbraco.Cms.Core.Models.PublishedContent;
using Rhythm.Drop.Models.Elements;

/// <summary>
/// A collection of methods to augment <see cref="MapperContext"/> to map a <see cref="IElement"/> object.
/// </summary>
public static class MapperContextElementExtensions
{
    /// <summary>
    /// Maps a single block reference to a <typeparamref name="TElement"/>.
    /// </summary>
    /// <typeparam name="TElement">The type of the element.</typeparam>
    /// <param name="mapperContext">The current mapper context.</param>
    /// <param name="block">The block to map.</param>
    /// <returns>
    /// <para>A <typeparamref name="TElement"/> if successful.</para>
    /// <para>This method will return <see langword="default" /> if <paramref name="block"/> is <see langword="null"/>.</para>
    /// </returns>
    public static TElement? MapElement<TElement>(this MapperContext mapperContext, IBlockReference<IPublishedElement, IPublishedElement>? block) where TElement : class, IElement
    {
        if (block is null)
        {
            return default;
        }

        return mapperContext.MapElement<TElement>(block.Content);
    }

    /// <summary>
    /// Maps a single block reference to a <see cref="IElement"/>.
    /// </summary>
    /// <param name="mapperContext">The current mapper context.</param>
    /// <param name="block">The block to map.</param>
    /// <returns>
    /// <para>A <see cref="IElement"/> if successful.</para>
    /// <para>This method will return <see langword="default" /> if <paramref name="block"/> is <see langword="null"/>.</para>
    /// </returns>
    public static IElement? MapElement(this MapperContext mapperContext, IBlockReference<IPublishedElement, IPublishedElement>? block)
    {
        return mapperContext.MapElement<IElement>(block);
    }

    /// <summary>
    /// Maps a <see cref="IPublishedElement"/> to a <typeparamref name="TElement"/>.
    /// </summary>
    /// <typeparam name="TElement">The type of the element.</typeparam>
    /// <param name="mapperContext">The current mapper context.</param>
    /// <param name="element">The element to map.</param>
    /// <returns>
    /// <para>A <typeparamref name="TElement"/> if successful.</para>
    /// <para>This method will return <see langword="default" /> if <paramref name="element"/> is <see langword="null"/>.</para>
    /// </returns>
    public static TElement? MapElement<TElement>(this MapperContext mapperContext, IPublishedElement? element) where TElement : class, IElement
    {
        if (element is null)
        {
            return default;
        }

        return mapperContext.Map<TElement?>(element);
    }

    /// <summary>
    /// Maps a <see cref="IPublishedElement"/> to a <see cref="IElement"/>.
    /// </summary>
    /// <param name="mapperContext">The current mapper context.</param>
    /// <param name="element">The element to map.</param>
    /// <returns>
    /// <para>A <see cref="IElement"/> if successful.</para>
    /// <para>This method will return <see langword="default" /> if <paramref name="element"/> is <see langword="null"/>.</para>
    /// </returns>
    public static IElement? MapElement(this MapperContext mapperContext, IPublishedElement? element)
    {
        return mapperContext.MapElement<IElement>(element);
    }

    /// <summary>
    /// Maps the first item from a <see cref="BlockListModel"/> to a <typeparamref name="TElement"/>.
    /// </summary>
    /// <typeparam name="TElement">The type of the element.</typeparam>
    /// <param name="mapperContext">The current mapper context.</param>
    /// <param name="list">The list to map.</param>
    /// <returns>
    /// <para>A <typeparamref name="TElement"/> if successful.</para>
    /// <para>This method will return <see langword="default" /> if <paramref name="list"/> or its first item are <see langword="null"/>.</para>
    /// </returns>
    public static TElement? MapElement<TElement>(this MapperContext mapperContext, BlockListModel? list) where TElement : class, IElement
    {
        if (list is null)
        {
            return default;
        }

        return mapperContext.MapElement<TElement>(list.FirstOrDefault());
    }

    /// <summary>
    /// Maps the first item from a <see cref="BlockListModel"/> to a <see cref="IElement"/>.
    /// </summary>
    /// <param name="mapperContext">The current mapper context.</param>
    /// <param name="list">The list to map.</param>
    /// <returns>
    /// <para>A <see cref="IElement"/> if successful.</para>
    /// <para>This method will return <see langword="default" /> if <paramref name="list"/> or its first item are <see langword="null"/>.</para>
    /// </returns>
    public static IElement? MapElement(this MapperContext mapperContext, BlockListModel? list)
    {
        return mapperContext.MapElement<IElement>(list);
    }
}
