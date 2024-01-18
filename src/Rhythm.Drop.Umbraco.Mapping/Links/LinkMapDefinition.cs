namespace Rhythm.Drop.Umbraco.Mapping.Links;

using global::Umbraco.Cms.Core.Mapping;
using Rhythm.Drop.Models.Links;

/// <summary>
/// An abstract map definition for mapping a <typeparamref name="TSource"/> to a <see cref="ILink"/>.
/// </summary>
/// <typeparam name="TSource">The source type.</typeparam>
public abstract class LinkMapDefinition<TSource> : LinkMapDefinition<TSource, ILink>
{
    /// <inheritdoc/>
    public override void DefineMaps(IUmbracoMapper mapper)
    {
        mapper.Define<TSource, ILink?>(Map);
    }
}

/// <summary>
/// An abstract map definition for mapping a <typeparamref name="TSource"/> to a <typeparamref name="TLink"/>.
/// </summary>
/// <typeparam name="TSource">The source type.</typeparam>
/// <typeparam name="TLink">The link type.</typeparam>
public abstract class LinkMapDefinition<TSource, TLink> : ILinkMapDefinition<TSource, TLink> where TLink : class, ILink
{
    /// <inheritdoc/>
    public virtual void DefineMaps(IUmbracoMapper mapper)
    {
        mapper.Define<TSource, ILink?>(Map);
        mapper.Define<TSource, TLink?>(Map);
    }

    /// <inheritdoc/>
    public virtual TLink? Map(TSource source, MapperContext context)
    {
        return default;
    }
}