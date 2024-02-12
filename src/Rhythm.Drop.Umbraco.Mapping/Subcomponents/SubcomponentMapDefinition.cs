namespace Rhythm.Drop.Umbraco.Mapping.Subcomponents;

using global::Umbraco.Cms.Core.Mapping;
using Rhythm.Drop.Models.Subcomponents;

/// <summary>
/// An abstract map definition for mapping a <typeparamref name="TSource"/> to a <see cref="ISubcomponent"/>.
/// </summary>
/// <typeparam name="TSource">The source type.</typeparam>
public abstract class SubcomponentMapDefinition<TSource> : SubcomponentMapDefinition<TSource, ISubcomponent>
{
    /// <inheritdoc/>
    public override void DefineMaps(IUmbracoMapper mapper)
    {
        mapper.Define<TSource, ISubcomponent?>(Map);
    }
}

/// <summary>
/// An abstract map definition for mapping a <typeparamref name="TSource"/> to a <typeparamref name="TSubcomponent"/>.
/// </summary>
/// <typeparam name="TSource">The source type.</typeparam>
/// <typeparam name="TSubcomponent">The subcomponent type.</typeparam>
public abstract class SubcomponentMapDefinition<TSource, TSubcomponent> : ISubcomponentMapDefinition<TSource, TSubcomponent> where TSubcomponent : class, ISubcomponent
{
    /// <inheritdoc/>
    public virtual void DefineMaps(IUmbracoMapper mapper)
    {
        mapper.Define<TSource, ISubcomponent?>(Map);
        mapper.Define<TSource, TSubcomponent?>(Map);
    }

    /// <inheritdoc/>
    public virtual TSubcomponent? Map(TSource source, MapperContext context)
    {
        return default;
    }
}