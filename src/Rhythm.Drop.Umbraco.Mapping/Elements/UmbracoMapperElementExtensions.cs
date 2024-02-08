namespace Rhythm.Drop.Umbraco.Mapping.Elements;

using global::Umbraco.Cms.Core.Mapping;
using global::Umbraco.Cms.Core.Models.Blocks;
using global::Umbraco.Cms.Core.Models.PublishedContent;
using Rhythm.Drop.Models.Elements;

/// <summary>
/// A collection of methods to augment <see cref="IUmbracoMapper"/> to map <see cref="IElement"/> objects.
/// </summary>
public static class UmbracoMapperElementExtensions
{
    private static readonly Action<MapperContext> _defaultContextFunc = (c) => { };

    /// <summary>
    /// Maps a single block reference to a <typeparamref name="TElement"/>.
    /// </summary>
    /// <typeparam name="TElement">The type of the element.</typeparam>
    /// <param name="mapper">The current umbraco mapper.</param>
    /// <param name="block">The block to map.</param>
    /// <param name="configureContext">The optional configure mapper context action.</param>
    /// <returns>
    /// <para>A <typeparamref name="TElement"/> if successful.</para>
    /// <para>This method will return <see langword="default" /> if <paramref name="block"/> is <see langword="null"/>.</para>
    /// </returns>
    public static TElement? MapElement<TElement>(this IUmbracoMapper mapper, IBlockReference<IPublishedElement, IPublishedElement>? block, Action<MapperContext>? configureContext = default) where TElement : class, IElement
    {
        if (block is null)
        {
            return default;
        }

        return mapper.MapElement<TElement>(block.Content, configureContext);
    }

    /// <summary>
    /// Maps a single block reference to a <see cref="IElement"/>.
    /// </summary>
    /// <param name="mapper">The current umbraco mapper.</param>
    /// <param name="block">The block to map.</param>
    /// <param name="configureContext">The optional configure mapper context action.</param>
    /// <returns>
    /// <para>A <see cref="IElement"/> if successful.</para>
    /// <para>This method will return <see langword="default" /> if <paramref name="block"/> is <see langword="null"/>.</para>
    /// </returns>
    public static IElement? MapElement(this IUmbracoMapper mapper, IBlockReference<IPublishedElement, IPublishedElement>? block, Action<MapperContext>? configureContext = default)
    {
        return mapper.MapElement<IElement>(block, configureContext);
    }

    /// <summary>
    /// Maps a <see cref="IPublishedElement"/> to a <typeparamref name="TElement"/>.
    /// </summary>
    /// <typeparam name="TElement">The type of the element.</typeparam>
    /// <param name="mapper">The current umbraco mapper.</param>
    /// <param name="element">The element to map.</param>
    /// <param name="configureContext">The optional configure mapper context action.</param>
    /// <returns>
    /// <para>A <typeparamref name="TElement"/> if successful.</para>
    /// <para>This method will return <see langword="default" /> if <paramref name="element"/> is <see langword="null"/>.</para>
    /// </returns>
    public static TElement? MapElement<TElement>(this IUmbracoMapper mapper, IPublishedElement? element, Action<MapperContext>? configureContext = default) where TElement : class, IElement
    {
        if (element is null)
        {
            return default;
        }

        return mapper.Map<TElement?>(element, configureContext ?? _defaultContextFunc);
    }

    /// <summary>
    /// Maps a <see cref="IPublishedElement"/> to a <see cref="IElement"/>.
    /// </summary>
    /// <param name="mapper">The current umbraco mapper.</param>
    /// <param name="element">The element to map.</param>
    /// <param name="configureContext">The optional configure mapper context action.</param>
    /// <returns>
    /// <para>A <see cref="IElement"/> if successful.</para>
    /// <para>This method will return <see langword="default" /> if <paramref name="element"/> is <see langword="null"/>.</para>
    /// </returns>
    public static IElement? MapElement(this IUmbracoMapper mapper, IPublishedElement? element, Action<MapperContext>? configureContext = default)
    {
        return mapper.MapElement<IElement>(element, configureContext);
    }

    /// <summary>
    /// Maps the first item from a <see cref="BlockListModel"/> to a <typeparamref name="TElement"/>.
    /// </summary>
    /// <typeparam name="TElement">The type of the element.</typeparam>
    /// <param name="mapper">The current umbraco mapper.</param>
    /// <param name="list">The list to map.</param>
    /// <param name="configureContext">The optional configure mapper context action.</param>
    /// <returns>
    /// <para>A <typeparamref name="TElement"/> if successful.</para>
    /// <para>This method will return <see langword="default" /> if <paramref name="list"/> or its first item are <see langword="null"/>.</para>
    /// </returns>
    public static TElement? MapElement<TElement>(this IUmbracoMapper mapper, BlockListModel? list, Action<MapperContext>? configureContext = default) where TElement : class, IElement
    {
        if (list is null)
        {
            return default;
        }

        return mapper.MapElement<TElement>(list.FirstOrDefault(), configureContext);
    }

    /// <summary>
    /// Maps the first item from a <see cref="BlockListModel"/> to a <see cref="IElement"/>.
    /// </summary>
    /// <param name="mapper">The current umbraco mapper.</param>
    /// <param name="list">The list to map.</param>
    /// <param name="configureContext">The optional configure mapper context action.</param>
    /// <returns>
    /// <para>A <see cref="IElement"/> if successful.</para>
    /// <para>This method will return <see langword="default" /> if <paramref name="list"/> or its first item are <see langword="null"/>.</para>
    /// </returns>
    public static IElement? MapElement(this IUmbracoMapper mapper, BlockListModel? list, Action<MapperContext>? configureContext = default)
    {
        return mapper.MapElement<IElement>(list, configureContext);
    }
}