namespace Rhythm.Drop.Umbraco.Mapping.Elements;

using global::Umbraco.Cms.Core.Composing;
using global::Umbraco.Cms.Core.Mapping;
using Rhythm.Drop.Models.Elements;

/// <summary>
/// A contract for creating a map definition that maps a <typeparamref name="TSource"/> to a <typeparamref name="TElement"/>.
/// </summary>
/// <typeparam name="TSource">The source type.</typeparam>
/// <typeparam name="TElement">The element type.</typeparam>
public interface IElementMapDefinition<in TSource, out TElement> : IElementMapDefinition where TElement : IElement
{
    /// <summary>
    /// Maps a <typeparamref name="TSource"/> to a <typeparamref name="TElement"/>.
    /// </summary>
    /// <param name="source">The source object.</param>
    /// <param name="context">The mapper context.</param>
    /// <remarks>A <typeparamref name="TElement"/> if successful.</remarks>
    TElement? Map(TSource source, MapperContext context);
}

/// <summary>
/// A base contract for creating a map definition for mapping to a <see cref="IElement"/>.
/// </summary>
/// <remarks>This exists for type finding and should not be used directly.</remarks>
public interface IElementMapDefinition : IMapDefinition, IDiscoverable
{
}