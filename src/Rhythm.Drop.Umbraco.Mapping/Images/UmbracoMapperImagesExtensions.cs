namespace Rhythm.Drop.Umbraco.Mapping.Images;

using global::Umbraco.Cms.Core.Mapping;
using global::Umbraco.Cms.Core.Models.Blocks;
using Rhythm.Drop.Models.Images;

/// <summary>
/// A collection of methods to augment <see cref="IUmbracoMapper"/> to collections of <see cref="IImage"/> objects.
/// </summary>
public static class UmbracoMapperImagesExtensions
{
    private static readonly Action<MapperContext> _defaultContextFunc = (c) => { };

    /// <summary>
    /// Maps a <see cref="BlockListModel"/> to a collection of <typeparamref name="TImage"/>.
    /// </summary>
    /// <typeparam name="TImage">The type of the image.</typeparam>
    /// <param name="mapper">The current umbraco mapper.</param>
    /// <param name="list">The list to map.</param>
    /// <param name="configureContext">The optional configure mapper context action.</param>
    /// <returns>
    /// <para>An array of <typeparamref name="TImage"/>.</para>
    /// <para>This method will return an empty collection if <paramref name="list"/> is <see langword="null"/>.</para>
    /// </returns>
    public static TImage[] MapImages<TImage>(this IUmbracoMapper mapper, BlockListModel? list, Action<MapperContext>? configureContext = default) where TImage : class, IImage
    {
        if (list is null)
        {
            return [];
        }

        var images = new List<TImage>();
        foreach (var block in list)
        {
            var image = mapper.MapImage<TImage>(block.Content, configureContext);
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
    /// <param name="mapper">The current umbraco mapper.</param>
    /// <param name="list">The list to map.</param>
    /// <param name="configureContext">The optional configure mapper context action.</param>
    /// <returns>
    /// <para>An array of <see cref="IImage"/>.</para>
    /// <para>This method will return an empty collection if <paramref name="list"/> is <see langword="null"/>.</para>
    /// </returns>
    public static IImage[] MapImages(this IUmbracoMapper mapper, BlockListModel? list, Action<MapperContext>? configureContext = default)
    {
        return mapper.MapImages<IImage>(list, configureContext);
    }
}