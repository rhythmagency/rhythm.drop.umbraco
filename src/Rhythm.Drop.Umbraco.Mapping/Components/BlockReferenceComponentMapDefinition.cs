namespace Rhythm.Drop.Umbraco.Mapping.Components;

using global::Umbraco.Cms.Core.Mapping;
using global::Umbraco.Cms.Core.Models.Blocks;
using global::Umbraco.Cms.Core.Models.PublishedContent;
using Rhythm.Drop.Models.Components;

/// <summary>
/// A base map definition for mapping a <see cref="BlockGridItem{T}"/> or <see cref="BlockListItem{T}"/> with a content type of <typeparamref name="TBlockContent"/> to a <see cref="IComponent"/>.
/// </summary>
/// <typeparam name="TBlockContent">The type of the block content.</typeparam>
public abstract class BlockReferenceComponentMapDefinition<TBlockContent> : BlockReferenceComponentMapDefinition<TBlockContent, IComponent> where TBlockContent : IPublishedElement
{
    /// <inheritdoc/>
    public override void DefineMaps(IUmbracoMapper mapper)
    {
        mapper.Define<BlockListItem<TBlockContent>, IComponent?>(Map);
        
        mapper.Define<BlockGridItem<TBlockContent>, IComponent?>(Map);
    }
}

/// <summary>
/// A base map definition for mapping a <see cref="BlockGridItem{T}"/> or <see cref="BlockListItem{T}"/> with a content type of <typeparamref name="TBlockContent"/> to a <typeparamref name="TComponent"/> and <see cref="IComponent"/>.
/// </summary>
/// <typeparam name="TBlockContent">The type of the block content.</typeparam>
/// <typeparam name="TComponent">The type of the component.</typeparam>
public abstract class BlockReferenceComponentMapDefinition<TBlockContent, TComponent> : IComponentMapDefinition where TComponent : class, IComponent where TBlockContent : IPublishedElement
{
    /// <inheritdoc/>
    public virtual void DefineMaps(IUmbracoMapper mapper)
    {
        mapper.Define<BlockGridItem<TBlockContent>, TComponent?>(Map);
        mapper.Define<BlockGridItem<TBlockContent>, IComponent?>(Map);

        mapper.Define<BlockListItem<TBlockContent>, TComponent?>(Map);
        mapper.Define<BlockListItem<TBlockContent>, TComponent?>(Map);
    }

    /// <summary>
    /// Maps a <see cref="BlockGridItem{TBlockContent}"/> to a <typeparamref name="TComponent"/>.
    /// </summary>
    /// <param name="source">The source.</param>
    /// <param name="context">The context.</param>
    /// <returns>A <typeparamref name="TComponent"/> if successful.</returns>
    public virtual TComponent? Map(BlockGridItem<TBlockContent> source, MapperContext context)
    {
        return Map(source.Content, context);
    }

    /// <summary>
    /// Maps a <see cref="BlockListItem{TBlockContent}"/> to a <typeparamref name="TComponent"/>.
    /// </summary>
    /// <param name="source">The source.</param>
    /// <param name="context">The context.</param>
    /// <returns>A <typeparamref name="TComponent"/> if successful.</returns>
    public virtual TComponent? Map(BlockListItem<TBlockContent> source, MapperContext context)
    {
        return Map(source.Content, context);
    }

    /// <summary>
    /// Maps a <typeparamref name="TBlockContent"/> to a <typeparamref name="TComponent"/>.
    /// </summary>
    /// <param name="source">The source.</param>
    /// <param name="context">The context.</param>
    /// <returns>A <typeparamref name="TComponent"/> if successful.</returns>
    /// <remarks>This the intermediary method that is used by default implementations of <see cref="Map(BlockGridItem{TBlockContent}, MapperContext)"/> or <see cref="Map(BlockListItem{TBlockContent}, MapperContext)"/></remarks>
    protected virtual TComponent? Map(TBlockContent source, MapperContext context)
    {
        return default;
    }
}