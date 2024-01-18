namespace Rhythm.Drop.Umbraco.Mapping.Links;

using global::Umbraco.Cms.Core.Composing;
using global::Umbraco.Cms.Core.Mapping;
using Rhythm.Drop.Models.Links;

/// <summary>
/// A contract for creating a map definition that maps a <typeparamref name="TSource"/> to a <typeparamref name="TLink"/>.
/// </summary>
/// <typeparam name="TSource">The source type.</typeparam>
/// <typeparam name="TLink">The link type.</typeparam>
public interface ILinkMapDefinition<in TSource, out TLink> : ILinkMapDefinition where TLink : ILink
{
    /// <summary>
    /// Maps a <typeparamref name="TSource"/> to a <typeparamref name="TLink"/>.
    /// </summary>
    /// <param name="source">The source object.</param>
    /// <param name="context">The mapper context.</param>
    /// <remarks>A <typeparamref name="TLink"/> if successful.</remarks>
    TLink? Map(TSource source, MapperContext context);
}

/// <summary>
/// A base contract for creating a map definition for mapping to a <see cref="ILink"/>.
/// </summary>
/// <remarks>This exists for type finding and should not be used directly.</remarks>
public interface ILinkMapDefinition : IMapDefinition, IDiscoverable
{
}