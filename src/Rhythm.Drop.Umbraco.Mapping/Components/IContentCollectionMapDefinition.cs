namespace Rhythm.Drop.Umbraco.Mapping.Components;

using global::Umbraco.Cms.Core.Mapping;
using Rhythm.Drop.Models.Components;

/// <summary>
/// A contract for creating a map definition that maps a <typeparamref name="TSource"/> collection of <typeparamref name="TComponent"/>.
/// </summary>
/// <typeparam name="TSource">The source type.</typeparam>
/// <typeparam name="TComponent">The component type.</typeparam>
public interface IComponentCollectionMapDefinition<in TSource, out TComponent> : IMapDefinition where TComponent : IComponent
{
    /// <summary>
    /// Maps a <typeparamref name="TSource"/> to a a collection of <typeparamref name="TComponent"/>.
    /// </summary>
    /// <param name="source">The source object.</param>
    /// <param name="context">The mapper context.</param>
    /// <remarks>A collection of <typeparamref name="TComponent"/>.</remarks>
    TComponent[] Map(TSource source, MapperContext context);
}