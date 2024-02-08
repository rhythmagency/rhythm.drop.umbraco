namespace Rhythm.Drop.Umbraco.Mapping.Modals;

using global::Umbraco.Cms.Core.Mapping;
using global::Umbraco.Cms.Core.Models.Blocks;
using global::Umbraco.Cms.Core.Models.PublishedContent;
using Rhythm.Drop.Models.Modals;

/// <summary>
/// A collection of methods to augment <see cref="MapperContext"/> to map a <see cref="IModal"/> object.
/// </summary>
public static class MapperContextModalExtensions
{
    /// <summary>
    /// Maps a single block reference to a <typeparamref name="TModal"/>.
    /// </summary>
    /// <typeparam name="TModal">The type of the modal.</typeparam>
    /// <param name="mapperContext">The current mapper context.</param>
    /// <param name="block">The block to map.</param>
    /// <returns>
    /// <para>A <typeparamref name="TModal"/> if successful.</para>
    /// <para>This method will return <see langword="default" /> if <paramref name="block"/> is <see langword="null"/>.</para>
    /// </returns>
    public static TModal? MapModal<TModal>(this MapperContext mapperContext, IBlockReference<IPublishedElement, IPublishedElement>? block) where TModal : class, IModal
    {
        if (block is null)
        {
            return default;
        }

        return mapperContext.MapModal<TModal>(block.Content);
    }

    /// <summary>
    /// Maps a single block reference to a <see cref="IModal"/>.
    /// </summary>
    /// <param name="mapperContext">The current mapper context.</param>
    /// <param name="block">The block to map.</param>
    /// <returns>
    /// <para>A <see cref="IModal"/> if successful.</para>
    /// <para>This method will return <see langword="default" /> if <paramref name="block"/> is <see langword="null"/>.</para>
    /// </returns>
    public static IModal? MapModal(this MapperContext mapperContext, IBlockReference<IPublishedElement, IPublishedElement>? block)
    {
        return mapperContext.MapModal<IModal>(block);
    }

    /// <summary>
    /// Maps a <see cref="IPublishedElement"/> to a <typeparamref name="TModal"/>.
    /// </summary>
    /// <typeparam name="TModal">The type of the modal.</typeparam>
    /// <param name="mapperContext">The current mapper context.</param>
    /// <param name="element">The element to map.</param>
    /// <returns>
    /// <para>A <typeparamref name="TModal"/> if successful.</para>
    /// <para>This method will return <see langword="default" /> if <paramref name="element"/> is <see langword="null"/>.</para>
    /// </returns>
    public static TModal? MapModal<TModal>(this MapperContext mapperContext, IPublishedElement? element) where TModal : class, IModal
    {
        if (element is null)
        {
            return default;
        }

        return mapperContext.Map<TModal?>(element);
    }

    /// <summary>
    /// Maps a <see cref="IPublishedElement"/> to a <see cref="IModal"/>.
    /// </summary>
    /// <param name="mapperContext">The current mapper context.</param>
    /// <param name="element">The element to map.</param>
    /// <returns>
    /// <para>A <see cref="IModal"/> if successful.</para>
    /// <para>This method will return <see langword="default" /> if <paramref name="element"/> is <see langword="null"/>.</para>
    /// </returns>
    public static IModal? MapModal(this MapperContext mapperContext, IPublishedElement? element)
    {
        return mapperContext.MapModal<IModal>(element);
    }

    /// <summary>
    /// Maps the first item from a <see cref="BlockListModel"/> to a <typeparamref name="TModal"/>.
    /// </summary>
    /// <typeparam name="TModal">The type of the modal.</typeparam>
    /// <param name="mapperContext">The current mapper context.</param>
    /// <param name="list">The list to map.</param>
    /// <returns>
    /// <para>A <typeparamref name="TModal"/> if successful.</para>
    /// <para>This method will return <see langword="default" /> if <paramref name="list"/> or its first item are <see langword="null"/>.</para>
    /// </returns>
    public static TModal? MapModal<TModal>(this MapperContext mapperContext, BlockListModel? list) where TModal : class, IModal
    {
        if (list is null)
        {
            return default;
        }

        return mapperContext.MapModal<TModal>(list.FirstOrDefault());
    }

    /// <summary>
    /// Maps the first item from a <see cref="BlockListModel"/> to a <see cref="IModal"/>.
    /// </summary>
    /// <param name="mapperContext">The current mapper context.</param>
    /// <param name="list">The list to map.</param>
    /// <returns>
    /// <para>A <see cref="IModal"/> if successful.</para>
    /// <para>This method will return <see langword="default" /> if <paramref name="list"/> or its first item are <see langword="null"/>.</para>
    /// </returns>
    public static IModal? MapModal(this MapperContext mapperContext, BlockListModel? list)
    {
        return mapperContext.MapModal<IModal>(list);
    }
}
