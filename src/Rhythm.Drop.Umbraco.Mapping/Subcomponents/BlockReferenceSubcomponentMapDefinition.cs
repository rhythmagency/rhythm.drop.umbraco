namespace Rhythm.Drop.Umbraco.Mapping.Subcomponents;

using global::Umbraco.Cms.Core.Mapping;
using global::Umbraco.Cms.Core.Models.Blocks;
using global::Umbraco.Cms.Core.Models.PublishedContent;
using Rhythm.Drop.Models.Subcomponents;

/// <summary>
/// A base map definition for mapping a <see cref="BlockGridItem{T}"/> or <see cref="BlockListItem{T}"/> with a content type of <typeparamref name="TBlockContent"/> to a <see cref="ISubcomponent"/>.
/// </summary>
/// <typeparam name="TBlockContent">The type of the block content.</typeparam>
public abstract class BlockReferenceSubcomponentMapDefinition<TBlockContent> : BlockReferenceSubcomponentMapDefinition<TBlockContent, ISubcomponent> where TBlockContent : IPublishedElement
{
    /// <inheritdoc/>
    public override void DefineMaps(IUmbracoMapper mapper)
    {
        mapper.Define<BlockListItem<TBlockContent>, ISubcomponent?>(Map);

        mapper.Define<BlockGridItem<TBlockContent>, ISubcomponent?>(Map);
    }
}

/// <summary>
/// A base map definition for mapping a <see cref="BlockGridItem{T}"/> or <see cref="BlockListItem{T}"/> with a content type of <typeparamref name="TBlockContent"/> to a <typeparamref name="TSubcomponent"/> and <see cref="ISubcomponent"/>.
/// </summary>
/// <typeparam name="TBlockContent">The type of the block content.</typeparam>
/// <typeparam name="TSubcomponent">The type of the subcomponent.</typeparam>
public abstract class BlockReferenceSubcomponentMapDefinition<TBlockContent, TSubcomponent> : ISubcomponentMapDefinition where TBlockContent : IPublishedElement where TSubcomponent : class, ISubcomponent
{
    /// <inheritdoc/>
    public virtual void DefineMaps(IUmbracoMapper mapper)
    {
        mapper.Define<BlockGridItem<TBlockContent>, TSubcomponent?>(Map);
        mapper.Define<BlockGridItem<TBlockContent>, ISubcomponent?>(Map);

        mapper.Define<BlockListItem<TBlockContent>, TSubcomponent?>(Map);
        mapper.Define<BlockListItem<TBlockContent>, ISubcomponent?>(Map);
    }

    /// <summary>
    /// Maps a <see cref="BlockGridItem{TBlockContent}"/> to a <typeparamref name="TSubcomponent"/>.
    /// </summary>
    /// <param name="source">The source.</param>
    /// <param name="context">The context.</param>
    /// <returns>A <typeparamref name="TSubcomponent"/> if successful.</returns>
    public virtual TSubcomponent? Map(BlockGridItem<TBlockContent> source, MapperContext context)
    {
        return Map(source.Content, context);
    }

    /// <summary>
    /// Maps a <see cref="BlockListItem{TBlockContent}"/> to a <typeparamref name="TSubcomponent"/>.
    /// </summary>
    /// <param name="source">The source.</param>
    /// <param name="context">The context.</param>
    /// <returns>A <typeparamref name="TSubcomponent"/> if successful.</returns>
    public virtual TSubcomponent? Map(BlockListItem<TBlockContent> source, MapperContext context)
    {
        return Map(source.Content, context);
    }

    /// <summary>
    /// Maps a <typeparamref name="TBlockContent"/> to a <typeparamref name="TSubcomponent"/>.
    /// </summary>
    /// <param name="source">The source.</param>
    /// <param name="context">The context.</param>
    /// <returns>A <typeparamref name="TSubcomponent"/> if successful.</returns>
    /// <remarks>This the intermediary method that is used by default implementations of <see cref="Map(BlockGridItem{TBlockContent}, MapperContext)"/> or <see cref="Map(BlockListItem{TBlockContent}, MapperContext)"/></remarks>
    protected virtual TSubcomponent? Map(TBlockContent source, MapperContext context)
    {
        return default;
    }
}