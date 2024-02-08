namespace Rhythm.Drop.Umbraco.Mapping.Modals;

using global::Umbraco.Cms.Core.Mapping;
using global::Umbraco.Cms.Core.Models.Blocks;
using global::Umbraco.Cms.Core.Models.PublishedContent;
using Rhythm.Drop.Models.Modals;

/// <summary>
/// A collection of methods to augment <see cref="IUmbracoMapper"/> to map <see cref="IModal"/> objects.
/// </summary>
public static class UmbracoMapperModalExtensions
{
    private static readonly Action<MapperContext> _defaultContextFunc = (c) => { };

    /// <summary>
    /// Maps a single block reference to a <typeparamref name="TModal"/>.
    /// </summary>
    /// <typeparam name="TModal">The type of the modal.</typeparam>
    /// <param name="mapper">The current umbraco mapper.</param>
    /// <param name="block">The block to map.</param>
    /// <param name="configureContext">The optional configure mapper context action.</param>
    /// <returns>
    /// <para>A <typeparamref name="TModal"/> if successful.</para>
    /// <para>This method will return <see langword="default" /> if <paramref name="block"/> is <see langword="null"/>.</para>
    /// </returns>
    public static TModal? MapModal<TModal>(this IUmbracoMapper mapper, IBlockReference<IPublishedElement, IPublishedElement>? block, Action<MapperContext>? configureContext = default) where TModal : class, IModal
    {
        if (block is null)
        {
            return default;
        }

        return mapper.MapModal<TModal>(block.Content, configureContext);
    }

    /// <summary>
    /// Maps a single block reference to a <see cref="IModal"/>.
    /// </summary>
    /// <param name="mapper">The current umbraco mapper.</param>
    /// <param name="block">The block to map.</param>
    /// <param name="configureContext">The optional configure mapper context action.</param>
    /// <returns>
    /// <para>A <see cref="IModal"/> if successful.</para>
    /// <para>This method will return <see langword="default" /> if <paramref name="block"/> is <see langword="null"/>.</para>
    /// </returns>
    public static IModal? MapModal(this IUmbracoMapper mapper, IBlockReference<IPublishedElement, IPublishedElement>? block, Action<MapperContext>? configureContext = default)
    {
        return mapper.MapModal<IModal>(block, configureContext);
    }

    /// <summary>
    /// Maps a <see cref="IPublishedElement"/> to a <typeparamref name="TModal"/>.
    /// </summary>
    /// <typeparam name="TModal">The type of the modal.</typeparam>
    /// <param name="mapper">The current umbraco mapper.</param>
    /// <param name="element">The element to map.</param>
    /// <param name="configureContext">The optional configure mapper context action.</param>
    /// <returns>
    /// <para>A <typeparamref name="TModal"/> if successful.</para>
    /// <para>This method will return <see langword="default" /> if <paramref name="element"/> is <see langword="null"/>.</para>
    /// </returns>
    public static TModal? MapModal<TModal>(this IUmbracoMapper mapper, IPublishedElement? element, Action<MapperContext>? configureContext = default) where TModal : class, IModal
    {
        if (element is null)
        {
            return default;
        }

        return mapper.Map<TModal?>(element, configureContext ?? _defaultContextFunc);
    }

    /// <summary>
    /// Maps a <see cref="IPublishedElement"/> to a <see cref="IModal"/>.
    /// </summary>
    /// <param name="mapper">The current umbraco mapper.</param>
    /// <param name="element">The element to map.</param>
    /// <param name="configureContext">The optional configure mapper context action.</param>
    /// <returns>
    /// <para>A <see cref="IModal"/> if successful.</para>
    /// <para>This method will return <see langword="default" /> if <paramref name="element"/> is <see langword="null"/>.</para>
    /// </returns>
    public static IModal? MapModal(this IUmbracoMapper mapper, IPublishedElement? element, Action<MapperContext>? configureContext = default)
    {
        return mapper.MapModal<IModal>(element, configureContext);
    }

    /// <summary>
    /// Maps the first item from a <see cref="BlockListModel"/> to a <typeparamref name="TModal"/>.
    /// </summary>
    /// <typeparam name="TModal">The type of the modal.</typeparam>
    /// <param name="mapper">The current umbraco mapper.</param>
    /// <param name="list">The list to map.</param>
    /// <param name="configureContext">The optional configure mapper context action.</param>
    /// <returns>
    /// <para>A <typeparamref name="TModal"/> if successful.</para>
    /// <para>This method will return <see langword="default" /> if <paramref name="list"/> or its first item are <see langword="null"/>.</para>
    /// </returns>
    public static TModal? MapModal<TModal>(this IUmbracoMapper mapper, BlockListModel? list, Action<MapperContext>? configureContext = default) where TModal : class, IModal
    {
        if (list is null)
        {
            return default;
        }

        return mapper.MapModal<TModal>(list.FirstOrDefault(), configureContext);
    }

    /// <summary>
    /// Maps the first item from a <see cref="BlockListModel"/> to a <see cref="IModal"/>.
    /// </summary>
    /// <param name="mapper">The current umbraco mapper.</param>
    /// <param name="list">The list to map.</param>
    /// <param name="configureContext">The optional configure mapper context action.</param>
    /// <returns>
    /// <para>A <see cref="IModal"/> if successful.</para>
    /// <para>This method will return <see langword="default" /> if <paramref name="list"/> or its first item are <see langword="null"/>.</para>
    /// </returns>
    public static IModal? MapModal(this IUmbracoMapper mapper, BlockListModel? list, Action<MapperContext>? configureContext = default)
    {
        return mapper.MapModal<IModal>(list, configureContext);
    }
}