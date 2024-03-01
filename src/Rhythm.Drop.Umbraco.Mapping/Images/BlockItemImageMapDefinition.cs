namespace Rhythm.Drop.Umbraco.Mapping.Images;

using global::Umbraco.Cms.Core.Mapping;
using global::Umbraco.Cms.Core.Models.Blocks;
using global::Umbraco.Cms.Core.Models.PublishedContent;
using Rhythm.Drop.Models.Images;

/// <summary>
/// A base map definition for mapping a <see cref="BlockGridItem{T}"/> or <see cref="BlockListItem{T}"/> with a content type of <typeparamref name="TBlockContent"/> to a <see cref="IImage"/>.
/// </summary>
/// <typeparam name="TBlockContent">The type of the block content.</typeparam>
public abstract class BlockItemImageMapDefinition<TBlockContent> : BlockItemImageMapDefinition<TBlockContent, IImage> where TBlockContent : IPublishedElement
{
    /// <inheritdoc/>
    public override void DefineMaps(IUmbracoMapper mapper)
    {
        mapper.Define<BlockListItem<TBlockContent>, IImage?>(Map);
        
        mapper.Define<BlockGridItem<TBlockContent>, IImage?>(Map);
    }
}

/// <summary>
/// A base map definition for mapping a <see cref="BlockGridItem{T}"/> or <see cref="BlockListItem{T}"/> with a content type of <typeparamref name="TBlockContent"/> to a <typeparamref name="TImage"/> and <see cref="IImage"/>.
/// </summary>
/// <typeparam name="TBlockContent">The type of the block content.</typeparam>
/// <typeparam name="TImage">The type of the image.</typeparam>
public abstract class BlockItemImageMapDefinition<TBlockContent, TImage> : IImageMapDefinition where TImage : class, IImage where TBlockContent : IPublishedElement
{
    /// <inheritdoc/>
    public virtual void DefineMaps(IUmbracoMapper mapper)
    {
        mapper.Define<BlockGridItem<TBlockContent>, TImage?>(Map);
        mapper.Define<BlockGridItem<TBlockContent>, IImage?>(Map);

        mapper.Define<BlockListItem<TBlockContent>, TImage?>(Map);
        mapper.Define<BlockListItem<TBlockContent>, IImage?>(Map);
    }

    /// <summary>
    /// Maps a <see cref="BlockGridItem{TBlockContent}"/> to a <typeparamref name="TImage"/>.
    /// </summary>
    /// <param name="source">The source.</param>
    /// <param name="context">The context.</param>
    /// <returns>A <typeparamref name="TImage"/> if successful.</returns>
    public virtual TImage? Map(BlockGridItem<TBlockContent> source, MapperContext context)
    {
        return Map(source.Content, context);
    }

    /// <summary>
    /// Maps a <see cref="BlockListItem{TBlockContent}"/> to a <typeparamref name="TImage"/>.
    /// </summary>
    /// <param name="source">The source.</param>
    /// <param name="context">The context.</param>
    /// <returns>A <typeparamref name="TImage"/> if successful.</returns>
    public virtual TImage? Map(BlockListItem<TBlockContent> source, MapperContext context)
    {
        return Map(source.Content, context);
    }

    /// <summary>
    /// Maps a <typeparamref name="TBlockContent"/> to a <typeparamref name="TImage"/>.
    /// </summary>
    /// <param name="source">The source.</param>
    /// <param name="context">The context.</param>
    /// <returns>A <typeparamref name="TImage"/> if successful.</returns>
    /// <remarks>This the intermediary method that is used by default implementations of <see cref="Map(BlockGridItem{TBlockContent}, MapperContext)"/> or <see cref="Map(BlockListItem{TBlockContent}, MapperContext)"/></remarks>
    protected virtual TImage? Map(TBlockContent source, MapperContext context)
    {
        return default;
    }
}