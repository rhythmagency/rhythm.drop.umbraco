namespace Rhythm.Drop.Umbraco.Mapping.Links;

using global::Umbraco.Cms.Core.Mapping;
using global::Umbraco.Cms.Core.Models.Blocks;
using global::Umbraco.Cms.Core.Models.PublishedContent;
using Rhythm.Drop.Models.Links;

/// <summary>
/// A base map definition for mapping a <see cref="BlockGridItem{T}"/> or <see cref="BlockListItem{T}"/> with a content type of <typeparamref name="TBlockContent"/> to a <see cref="ILink"/>.
/// </summary>
/// <typeparam name="TBlockContent">The type of the block content.</typeparam>
public abstract class BlockItemLinkMapDefinition<TBlockContent> : BlockItemLinkMapDefinition<TBlockContent, ILink> where TBlockContent : IPublishedElement
{
    /// <inheritdoc/>
    public override void DefineMaps(IUmbracoMapper mapper)
    {
        mapper.Define<BlockListItem<TBlockContent>, ILink?>(Map);
        
        mapper.Define<BlockGridItem<TBlockContent>, ILink?>(Map);
    }
}

/// <summary>
/// A base map definition for mapping a <see cref="BlockGridItem{T}"/> or <see cref="BlockListItem{T}"/> with a content type of <typeparamref name="TBlockContent"/> to a <typeparamref name="TLink"/> and <see cref="ILink"/>.
/// </summary>
/// <typeparam name="TBlockContent">The type of the block content.</typeparam>
/// <typeparam name="TLink">The type of the link.</typeparam>
public abstract class BlockItemLinkMapDefinition<TBlockContent, TLink> : ILinkMapDefinition where TLink : class, ILink where TBlockContent : IPublishedElement
{
    /// <inheritdoc/>
    public virtual void DefineMaps(IUmbracoMapper mapper)
    {
        mapper.Define<BlockGridItem<TBlockContent>, TLink?>(Map);
        mapper.Define<BlockGridItem<TBlockContent>, ILink?>(Map);

        mapper.Define<BlockListItem<TBlockContent>, TLink?>(Map);
        mapper.Define<BlockListItem<TBlockContent>, TLink?>(Map);
    }

    /// <summary>
    /// Maps a <see cref="BlockGridItem{TBlockContent}"/> to a <typeparamref name="TLink"/>.
    /// </summary>
    /// <param name="source">The source.</param>
    /// <param name="context">The context.</param>
    /// <returns>A <typeparamref name="TLink"/> if successful.</returns>
    public virtual TLink? Map(BlockGridItem<TBlockContent> source, MapperContext context)
    {
        return Map(source.Content, context);
    }

    /// <summary>
    /// Maps a <see cref="BlockListItem{TBlockContent}"/> to a <typeparamref name="TLink"/>.
    /// </summary>
    /// <param name="source">The source.</param>
    /// <param name="context">The context.</param>
    /// <returns>A <typeparamref name="TLink"/> if successful.</returns>
    public virtual TLink? Map(BlockListItem<TBlockContent> source, MapperContext context)
    {
        return Map(source.Content, context);
    }

    /// <summary>
    /// Maps a <typeparamref name="TBlockContent"/> to a <typeparamref name="TLink"/>.
    /// </summary>
    /// <param name="source">The source.</param>
    /// <param name="context">The context.</param>
    /// <returns>A <typeparamref name="TLink"/> if successful.</returns>
    /// <remarks>This the intermediary method that is used by default implementations of <see cref="Map(BlockGridItem{TBlockContent}, MapperContext)"/> or <see cref="Map(BlockListItem{TBlockContent}, MapperContext)"/></remarks>
    protected virtual TLink? Map(TBlockContent source, MapperContext context)
    {
        return default;
    }
}