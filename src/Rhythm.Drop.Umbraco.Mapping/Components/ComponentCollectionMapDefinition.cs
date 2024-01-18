namespace Rhythm.Drop.Umbraco.Mapping.Components;

using global::Umbraco.Cms.Core.Mapping;
using Rhythm.Drop.Models.Components;

/// <summary>
/// An abstract map definition for mapping a <typeparamref name="TSource"/> to a collection of <see cref="IComponent"/>.
/// </summary>
/// <typeparam name="TSource">The source type.</typeparam>
public abstract class ComponentCollectionMapDefinition<TSource> : ComponentCollectionMapDefinition<TSource, IComponent>
{
    /// <inheritdoc/>
    public override void DefineMaps(IUmbracoMapper mapper)
    {
        mapper.Define<TSource, IComponent[]>(Map);
    }
}

/// <summary>
/// An abstract map definition for mapping a <typeparamref name="TSource"/> to a collection of <typeparamref name="TSource"/>.
/// </summary>
/// <typeparam name="TSource">The source type.</typeparam>
/// <typeparam name="TComponent">The component type.</typeparam>
public abstract class ComponentCollectionMapDefinition<TSource, TComponent> : IComponentCollectionMapDefinition<TSource, TComponent> where TComponent : class, IComponent
{
    /// <inheritdoc/>
    public virtual void DefineMaps(IUmbracoMapper mapper)
    {
        mapper.Define<TSource, IComponent[]>(Map);
        mapper.Define<TSource, TComponent[]>(Map);
    }

    /// <inheritdoc/>
    public virtual TComponent[] Map(TSource source, MapperContext context)
    {
        return [];
    }
}
