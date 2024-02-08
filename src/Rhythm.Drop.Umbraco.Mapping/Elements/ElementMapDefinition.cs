namespace Rhythm.Drop.Umbraco.Mapping.Elements;

using global::Umbraco.Cms.Core.Mapping;
using Rhythm.Drop.Models.Elements;

/// <summary>
/// An abstract map definition for mapping a <typeparamref name="TSource"/> to a <see cref="IElement"/>.
/// </summary>
/// <typeparam name="TSource">The source type.</typeparam>
public abstract class ElementMapDefinition<TSource> : ElementMapDefinition<TSource, IElement>
{
    /// <inheritdoc/>
    public override void DefineMaps(IUmbracoMapper mapper)
    {
        mapper.Define<TSource, IElement?>(Map);
    }
}

/// <summary>
/// An abstract map definition for mapping a <typeparamref name="TSource"/> to a <typeparamref name="TElement"/>.
/// </summary>
/// <typeparam name="TSource">The source type.</typeparam>
/// <typeparam name="TElement">The element type.</typeparam>
public abstract class ElementMapDefinition<TSource, TElement> : IElementMapDefinition<TSource, TElement> where TElement : class, IElement
{
    /// <inheritdoc/>
    public virtual void DefineMaps(IUmbracoMapper mapper)
    {
        mapper.Define<TSource, IElement?>(Map);
        mapper.Define<TSource, TElement?>(Map);
    }

    /// <inheritdoc/>
    public virtual TElement? Map(TSource source, MapperContext context)
    {
        return default;
    }
}