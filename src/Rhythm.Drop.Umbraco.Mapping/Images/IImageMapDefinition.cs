namespace Rhythm.Drop.Umbraco.Mapping.Images;

using global::Umbraco.Cms.Core.Composing;
using global::Umbraco.Cms.Core.Mapping;
using Rhythm.Drop.Models.Images;

/// <summary>
/// A contract for creating a map definition that maps a <typeparamref name="TSource"/> to a <typeparamref name="TImage"/>.
/// </summary>
/// <typeparam name="TSource">The source type.</typeparam>
/// <typeparam name="TImage">The image type.</typeparam>
public interface IImageMapDefinition<in TSource, out TImage> : IImageMapDefinition where TImage : IImage
{
    /// <summary>
    /// Maps a <typeparamref name="TSource"/> to a <typeparamref name="TImage"/>.
    /// </summary>
    /// <param name="source">The source object.</param>
    /// <param name="context">The mapper context.</param>
    /// <remarks>A <typeparamref name="TImage"/> if successful.</remarks>
    TImage? Map(TSource source, MapperContext context);
}

/// <summary>
/// A base contract for creating a map definition for mapping to a <see cref="IImage"/>.
/// </summary>
/// <remarks>This exists for type finding and should not be used directly.</remarks>
public interface IImageMapDefinition : IMapDefinition, IDiscoverable
{
}