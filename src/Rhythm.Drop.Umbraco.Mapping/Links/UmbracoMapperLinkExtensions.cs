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
    private static readonly Action<MapperContext> _defaultContextFunc = (c) => { };

    /// <summary>
    /// Maps a single block reference to a <typeparamref name="TLink"/>.
    /// </summary>
    /// <typeparam name="TLink">The type of the link.</typeparam>
    /// <param name="mapper">The current umbraco mapper.</param>
    /// <param name="block">The block to map.</param>
    /// <param name="configureContext">The optional configure mapper context action.</param>
    /// <returns>
    /// <para>A <typeparamref name="TLink"/> if successful.</para>
    /// <para>This method will return <see langword="default" /> if <paramref name="block"/> is <see langword="null"/>.</para>
    /// </returns>
    public static TLink? MapLink<TLink>(this IUmbracoMapper mapper, IBlockReference<IPublishedElement, IPublishedElement>? block, Action<MapperContext>? configureContext = default) where TLink : class, ILink
    {
        if (block is null)
        {
            return default;
        }

        return mapper.Map<TLink>(block.Content, configureContext ?? _defaultContextFunc);
    }

    /// <summary>
    /// Maps a single block reference to a <see cref="ILink"/>.
    /// </summary>
    /// <param name="mapper">The current umbraco mapper.</param>
    /// <param name="block">The block to map.</param>
    /// <param name="configureContext">The optional configure mapper context action.</param>
    /// <returns>
    /// <para>A <see cref="ILink"/> if successful.</para>
    /// <para>This method will return <see langword="default" /> if <paramref name="block"/> is <see langword="null"/>.</para>
    /// </returns>
    public static ILink? MapLink(this IUmbracoMapper mapper, IBlockReference<IPublishedElement, IPublishedElement>? block, Action<MapperContext>? configureContext = default)
    {
        return mapper.MapLink<ILink>(block, configureContext);
    }

    /// <summary>
    /// Maps a <see cref="IPublishedElement"/> to a <typeparamref name="TLink"/>.
    /// </summary>
    /// <typeparam name="TLink">The type of the link.</typeparam>
    /// <param name="mapper">The current umbraco mapper.</param>
    /// <param name="element">The element to map.</param>
    /// <param name="configureContext">The optional configure mapper context action.</param>
    /// <returns>
    /// <para>A <typeparamref name="TLink"/> if successful.</para>
    /// <para>This method will return <see langword="default" /> if <paramref name="element"/> is <see langword="null"/>.</para>
    /// </returns>
    public static TLink? MapLink<TLink>(this IUmbracoMapper mapper, IPublishedElement? element, Action<MapperContext>? configureContext = default) where TLink : class, ILink
    {
        if (element is null)
        {
            return default;
        }

        return mapper.Map<TLink?>(element, configureContext ?? _defaultContextFunc);
    }

    /// <summary>
    /// Maps a <see cref="IPublishedElement"/> to a <see cref="ILink"/>.
    /// </summary>
    /// <param name="mapper">The current umbraco mapper.</param>
    /// <param name="element">The element to map.</param>
    /// <param name="configureContext">The optional configure mapper context action.</param>
    /// <returns>
    /// <para>A <see cref="ILink"/> if successful.</para>
    /// <para>This method will return <see langword="default" /> if <paramref name="element"/> is <see langword="null"/>.</para>
    /// </returns>
    public static ILink? MapLink(this IUmbracoMapper mapper, IPublishedElement? element, Action<MapperContext>? configureContext = default)
    {
        return mapper.MapLink<ILink>(element, configureContext);
    }

    /// <summary>
    /// Maps the first item from a <see cref="BlockListModel"/> to a <typeparamref name="TLink"/>.
    /// </summary>
    /// <typeparam name="TLink">The type of the link.</typeparam>
    /// <param name="mapper">The current umbraco mapper.</param>
    /// <param name="list">The list to map.</param>
    /// <param name="configureContext">The optional configure mapper context action.</param>
    /// <returns>
    /// <para>A <typeparamref name="TLink"/> if successful.</para>
    /// <para>This method will return <see langword="default" /> if <paramref name="list"/> or its first item are <see langword="null"/>.</para>
    /// </returns>
    public static TLink? MapLink<TLink>(this IUmbracoMapper mapper, BlockListModel? list, Action<MapperContext>? configureContext = default) where TLink : class, ILink
    {
        if (list is null)
        {
            return default;
        }

        return mapper.MapLink<TLink>(list.FirstOrDefault(), configureContext);
    }

    /// <summary>
    /// Maps the first item from a <see cref="BlockListModel"/> to a <see cref="ILink"/>.
    /// </summary>
    /// <param name="mapper">The current umbraco mapper.</param>
    /// <param name="list">The list to map.</param>
    /// <param name="configureContext">The optional configure mapper context action.</param>
    /// <returns>
    /// <para>A <see cref="ILink"/> if successful.</para>
    /// <para>This method will return <see langword="default" /> if <paramref name="list"/> or its first item are <see langword="null"/>.</para>
    /// </returns>
    public static ILink? MapLink(this IUmbracoMapper mapper, BlockListModel? list, Action<MapperContext>? configureContext = default)
    {
        return mapper.MapLink<ILink>(list, configureContext);
    }
}