namespace Rhythm.Drop.Umbraco.Mapping.Components;

using global::Umbraco.Cms.Core.Mapping;
using Rhythm.Drop.Models.Components;
using IDiscoverable = global::Umbraco.Cms.Core.Composing.IDiscoverable;

/// <summary>
/// A contract for creating a map definition that maps a <typeparamref name="TSource"/> to a <typeparamref name="TComponent"/>.
/// </summary>
/// <typeparam name="TSource">The source type.</typeparam>
/// <typeparam name="TComponent">The component type.</typeparam>
public interface IComponentMapDefinition<in TSource, out TComponent> : IComponentMapDefinition where TComponent : IComponent
{
    /// <summary>
    /// Maps a <typeparamref name="TSource"/> to a <typeparamref name="TComponent"/>.
    /// </summary>
    /// <param name="source">The source object.</param>
    /// <param name="context">The mapper context.</param>
    /// <remarks>A <typeparamref name="TComponent"/> if successful.</remarks>
    TComponent? Map(TSource source, MapperContext context);
}

/// <summary>
/// A base contract for creating a map definition for mapping to a <see cref="IComponent"/>.
/// </summary>
/// <remarks>This exists for type finding and should not be used directly.</remarks>
public interface IComponentMapDefinition : IMapDefinition, IDiscoverable
{
}