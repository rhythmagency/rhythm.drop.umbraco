namespace Rhythm.Drop.Umbraco.Mapping.Images;

using global::Umbraco.Cms.Core.Mapping;
using global::Umbraco.Cms.Core.Models.Blocks;
using global::Umbraco.Cms.Core.Models.PublishedContent;
using Rhythm.Drop.Models.Images;

/// <summary>
/// A collection of methods to augment <see cref="MapperContext"/> to map a <see cref="IImage"/> object.
/// </summary>
public static class MapperContextImageExtensions
{
    /// <summary>
    /// Maps a single block reference to a <typeparamref name="TImage"/>.
    /// </summary>
    /// <typeparam name="TImage">The type of the image.</typeparam>
    /// <param name="mapperContext">The current mapper context.</param>
    /// <param name="block">The block to map.</param>
    /// <returns>
    /// <para>A <typeparamref name="TImage"/> if successful.</para>
    /// <para>This method will return <see langword="default" /> if <paramref name="block"/> is <see langword="null"/>.</para>
    /// </returns>
    public static TImage? MapImage<TImage>(this MapperContext mapperContext, IBlockReference<IPublishedElement, IPublishedElement>? block) where TImage : class, IImage
    {
        if (block is null)
        {
            return default;
        }

        return mapperContext.Map<TImage>(block);
    }

    /// <summary>
    /// Maps a single block reference to a <see cref="IImage"/>.
    /// </summary>
    /// <param name="mapperContext">The current mapper context.</param>
    /// <param name="block">The block to map.</param>
    /// <returns>
    /// <para>A <see cref="IImage"/> if successful.</para>
    /// <para>This method will return <see langword="default" /> if <paramref name="block"/> is <see langword="null"/>.</para>
    /// </returns>
    public static IImage? MapImage(this MapperContext mapperContext, IBlockReference<IPublishedElement, IPublishedElement>? block)
    {
        return mapperContext.MapImage<IImage>(block);
    }

    /// <summary>
    /// Maps a <see cref="IPublishedElement"/> to a <typeparamref name="TImage"/>.
    /// </summary>
    /// <typeparam name="TImage">The type of the image.</typeparam>
    /// <param name="mapperContext">The current mapper context.</param>
    /// <param name="element">The element to map.</param>
    /// <returns>
    /// <para>A <typeparamref name="TImage"/> if successful.</para>
    /// <para>This method will return <see langword="default" /> if <paramref name="element"/> is <see langword="null"/>.</para>
    /// </returns>
    public static TImage? MapImage<TImage>(this MapperContext mapperContext, IPublishedElement? element) where TImage : class, IImage
    {
        if (element is null)
        {
            return default;
        }

        return mapperContext.Map<TImage?>(element);
    }

    /// <summary>
    /// Maps a <see cref="IPublishedElement"/> to a <see cref="IImage"/>.
    /// </summary>
    /// <param name="mapperContext">The current mapper context.</param>
    /// <param name="element">The element to map.</param>
    /// <returns>
    /// <para>A <see cref="IImage"/> if successful.</para>
    /// <para>This method will return <see langword="default" /> if <paramref name="element"/> is <see langword="null"/>.</para>
    /// </returns>
    public static IImage? MapImage(this MapperContext mapperContext, IPublishedElement? element)
    {
        return mapperContext.MapImage<IImage>(element);
    }

    /// <summary>
    /// Maps the first item from a <see cref="BlockListModel"/> to a <typeparamref name="TImage"/>.
    /// </summary>
    /// <typeparam name="TImage">The type of the image.</typeparam>
    /// <param name="mapperContext">The current mapper context.</param>
    /// <param name="list">The list to map.</param>
    /// <returns>
    /// <para>A <typeparamref name="TImage"/> if successful.</para>
    /// <para>This method will return <see langword="default" /> if <paramref name="list"/> or its first item are <see langword="null"/>.</para>
    /// </returns>
    public static TImage? MapImage<TImage>(this MapperContext mapperContext, BlockListModel? list) where TImage : class, IImage
    {
        if (list is null)
        {
            return default;
        }

        return mapperContext.MapImage<TImage>(list.FirstOrDefault());
    }

    /// <summary>
    /// Maps the first item from a <see cref="BlockListModel"/> to a <see cref="IImage"/>.
    /// </summary>
    /// <param name="mapperContext">The current mapper context.</param>
    /// <param name="list">The list to map.</param>
    /// <returns>
    /// <para>A <see cref="IImage"/> if successful.</para>
    /// <para>This method will return <see langword="default" /> if <paramref name="list"/> or its first item are <see langword="null"/>.</para>
    /// </returns>
    public static IImage? MapImage(this MapperContext mapperContext, BlockListModel? list)
    {
        return mapperContext.MapImage<IImage>(list);
    }
}
