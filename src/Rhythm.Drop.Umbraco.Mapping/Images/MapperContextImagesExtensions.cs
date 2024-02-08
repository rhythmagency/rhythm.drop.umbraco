namespace Rhythm.Drop.Umbraco.Mapping.Images;

using global::Umbraco.Cms.Core.Mapping;
using global::Umbraco.Cms.Core.Models.Blocks;
using Rhythm.Drop.Models.Images;

/// <summary>
/// A collection of methods to augment <see cref="MapperContext"/> to map to collections of <see cref="IImage"/> objects.
/// </summary>
public static class MapperContextImagesExtensions
{
    /// <summary>
    /// Maps a <see cref="BlockListModel"/> to a collection of <typeparamref name="TImage"/>.
    /// </summary>
    /// <typeparam name="TImage">The type of the image.</typeparam>
    /// <param name="mapperContext">The current mapper context.</param>
    /// <param name="list">The list to map.</param>
    /// <returns>
    /// <para>An array of <typeparamref name="TImage"/>.</para>
    /// <para>This method will return an empty collection if <paramref name="list"/> is <see langword="null"/>.</para>
    /// </returns>
    public static TImage[] MapImages<TImage>(this MapperContext mapperContext, BlockListModel? list) where TImage : class, IImage
    {
        if (list is null)
        {
            return [];
        }

        var images = new List<TImage>();
        foreach (var block in list)
        {
            var image = mapperContext.MapImage<TImage>(block.Content);
            if (image is null)
            {
                continue;
            }

            images.Add(image);
        }

        return [.. images];
    }

    /// <summary>
    /// Maps a <see cref="BlockListModel"/> to a collection of <see cref="IImage"/>.
    /// </summary>
    /// <param name="mapperContext">The current mapper context.</param>
    /// <param name="list">The list to map.</param>
    /// <returns>
    /// <para>An array of <see cref="IImage"/>.</para>
    /// <para>This method will return an empty collection if <paramref name="list"/> is <see langword="null"/>.</para>
    /// </returns>
    public static IImage[] MapImages(this MapperContext mapperContext, BlockListModel? list)
    {
        return mapperContext.MapImages<IImage>(list);
    }
}