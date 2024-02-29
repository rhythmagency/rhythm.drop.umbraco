namespace Rhythm.Drop.Umbraco.Mapping.Modals;

using global::Umbraco.Cms.Core.Mapping;
using global::Umbraco.Cms.Core.Models.Blocks;
using global::Umbraco.Cms.Core.Models.PublishedContent;
using Rhythm.Drop.Models.Modals;

/// <summary>
/// A base map definition for mapping a <see cref="BlockGridItem{T}"/> or <see cref="BlockListItem{T}"/> with a content type of <typeparamref name="TBlockContent"/> to a <see cref="IModal"/>.
/// </summary>
/// <typeparam name="TBlockContent">The type of the block content.</typeparam>
public abstract class BlockItemModalMapDefinition<TBlockContent> : BlockItemModalMapDefinition<TBlockContent, IModal> where TBlockContent : IPublishedElement
{
    /// <inheritdoc/>
    public override void DefineMaps(IUmbracoMapper mapper)
    {
        mapper.Define<BlockListItem<TBlockContent>, IModal?>(Map);
        
        mapper.Define<BlockGridItem<TBlockContent>, IModal?>(Map);
    }
}

/// <summary>
/// A base map definition for mapping a <see cref="BlockGridItem{T}"/> or <see cref="BlockListItem{T}"/> with a content type of <typeparamref name="TBlockContent"/> to a <typeparamref name="TModal"/> and <see cref="IModal"/>.
/// </summary>
/// <typeparam name="TBlockContent">The type of the block content.</typeparam>
/// <typeparam name="TModal">The type of the modal.</typeparam>
public abstract class BlockItemModalMapDefinition<TBlockContent, TModal> : IModalMapDefinition where TModal : class, IModal where TBlockContent : IPublishedElement
{
    /// <inheritdoc/>
    public virtual void DefineMaps(IUmbracoMapper mapper)
    {
        mapper.Define<BlockGridItem<TBlockContent>, TModal?>(Map);
        mapper.Define<BlockGridItem<TBlockContent>, IModal?>(Map);

        mapper.Define<BlockListItem<TBlockContent>, TModal?>(Map);
        mapper.Define<BlockListItem<TBlockContent>, TModal?>(Map);
    }

    /// <summary>
    /// Maps a <see cref="BlockGridItem{TBlockContent}"/> to a <typeparamref name="TModal"/>.
    /// </summary>
    /// <param name="source">The source.</param>
    /// <param name="context">The context.</param>
    /// <returns>A <typeparamref name="TModal"/> if successful.</returns>
    public virtual TModal? Map(BlockGridItem<TBlockContent> source, MapperContext context)
    {
        return Map(source.Content, context);
    }

    /// <summary>
    /// Maps a <see cref="BlockListItem{TBlockContent}"/> to a <typeparamref name="TModal"/>.
    /// </summary>
    /// <param name="source">The source.</param>
    /// <param name="context">The context.</param>
    /// <returns>A <typeparamref name="TModal"/> if successful.</returns>
    public virtual TModal? Map(BlockListItem<TBlockContent> source, MapperContext context)
    {
        return Map(source.Content, context);
    }

    /// <summary>
    /// Maps a <typeparamref name="TBlockContent"/> to a <typeparamref name="TModal"/>.
    /// </summary>
    /// <param name="source">The source.</param>
    /// <param name="context">The context.</param>
    /// <returns>A <typeparamref name="TModal"/> if successful.</returns>
    /// <remarks>This the intermediary method that is used by default implementations of <see cref="Map(BlockGridItem{TBlockContent}, MapperContext)"/> or <see cref="Map(BlockListItem{TBlockContent}, MapperContext)"/></remarks>
    protected virtual TModal? Map(TBlockContent source, MapperContext context)
    {
        return default;
    }
}