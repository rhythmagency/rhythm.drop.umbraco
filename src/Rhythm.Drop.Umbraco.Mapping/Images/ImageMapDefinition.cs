namespace Rhythm.Drop.Umbraco.Mapping.Images;

using global::Umbraco.Cms.Core.Mapping;
using Rhythm.Drop.Models.Images;

/// <summary>
/// An abstract map definition for mapping a <typeparamref name="TSource"/> to a <see cref="IImage"/>.
/// </summary>
/// <typeparam name="TSource">The source type.</typeparam>
public abstract class ImageMapDefinition<TSource> : ImageMapDefinition<TSource, IImage>
{
    /// <inheritdoc/>
    public override void DefineMaps(IUmbracoMapper mapper)
    {
        mapper.Define<TSource, IImage?>(Map);
    }
}

/// <summary>
/// An abstract map definition for mapping a <typeparamref name="TSource"/> to a <typeparamref name="TImage"/>.
/// </summary>
/// <typeparam name="TSource">The source type.</typeparam>
/// <typeparam name="TImage">The image type.</typeparam>
public abstract class ImageMapDefinition<TSource, TImage> : IImageMapDefinition<TSource, TImage> where TImage : class, IImage
{
    /// <inheritdoc/>
    public virtual void DefineMaps(IUmbracoMapper mapper)
    {
        mapper.Define<TSource, IImage?>(Map);
        mapper.Define<TSource, TImage?>(Map);
    }

    /// <inheritdoc/>
    public virtual TImage? Map(TSource source, MapperContext context)
    {
        return default;
    }
}