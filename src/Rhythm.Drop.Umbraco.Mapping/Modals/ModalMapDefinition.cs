namespace Rhythm.Drop.Umbraco.Mapping.Modals;

using global::Umbraco.Cms.Core.Mapping;
using Rhythm.Drop.Models.Modals;

/// <summary>
/// An abstract map definition for mapping a <typeparamref name="TSource"/> to a <see cref="IModal"/>.
/// </summary>
/// <typeparam name="TSource">The source type.</typeparam>
public abstract class ModalMapDefinition<TSource> : ModalMapDefinition<TSource, IModal>
{
    /// <inheritdoc/>
    public override void DefineMaps(IUmbracoMapper mapper)
    {
        mapper.Define<TSource, IModal?>(Map);
    }
}

/// <summary>
/// An abstract map definition for mapping a <typeparamref name="TSource"/> to a <typeparamref name="TModal"/>.
/// </summary>
/// <typeparam name="TSource">The source type.</typeparam>
/// <typeparam name="TModal">The modal type.</typeparam>
public abstract class ModalMapDefinition<TSource, TModal> : IModalMapDefinition<TSource, TModal> where TModal : class, IModal
{
    /// <inheritdoc/>
    public virtual void DefineMaps(IUmbracoMapper mapper)
    {
        mapper.Define<TSource, IModal?>(Map);
        mapper.Define<TSource, TModal?>(Map);
    }

    /// <inheritdoc/>
    public virtual TModal? Map(TSource source, MapperContext context)
    {
        return default;
    }
}