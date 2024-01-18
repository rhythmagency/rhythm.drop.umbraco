namespace Rhythm.Drop.Umbraco.Mapping.Components;

using global::Umbraco.Cms.Core.Mapping;
using Rhythm.Drop.Models.Components;
using IDiscoverable = global::Umbraco.Cms.Core.Composing.IDiscoverable;

/// <summary>
/// A contract for creating a map definition that maps a <typeparamref name="TSource"/> collection of <typeparamref name="TComponent"/>.
/// </summary>
/// <typeparam name="TSource">The source type.</typeparam>
/// <typeparam name="TComponent">The component type.</typeparam>
public interface IComponentCollectionMapDefinition<in TSource, out TComponent> : IComponentCollectionMapDefinition where TComponent : IComponent
{
    /// <summary>
    /// Maps a <typeparamref name="TSource"/> to a a collection of <typeparamref name="TComponent"/>.
    /// </summary>
    /// <param name="source">The source object.</param>
    /// <param name="context">The mapper context.</param>
    /// <remarks>A collection of <typeparamref name="TComponent"/>.</remarks>
    TComponent[] Map(TSource source, MapperContext context);
}

/// <summary>
/// A base contract for creating a map definition for mapping to a collection of <see cref="IComponent"/>.
/// </summary>
/// <remarks>This exists for type finding and should not be used directly.</remarks>
public interface IComponentCollectionMapDefinition : IMapDefinition, IDiscoverable
{
}