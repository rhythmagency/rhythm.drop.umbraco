namespace Rhythm.Drop.Umbraco.Mapping.Components;

using global::Umbraco.Cms.Core.Mapping;
using global::Umbraco.Cms.Core.Models.Blocks;
using global::Umbraco.Cms.Core.Models.PublishedContent;
using Rhythm.Drop.Models.Components;

/// <summary>
/// A collection of methods to augment <see cref="IUmbracoMapper"/> to map <see cref="IComponent"/> objects.
/// </summary>
public static class UmbracoMapperComponentExtensions
{
    /// <summary>
    /// Maps a single block reference to a <typeparamref name="TComponent"/>.
    /// </summary>
    /// <typeparam name="TComponent">The type of the component.</typeparam>
    /// <param name="mapper">The current umbraco mapper.</param>
    /// <param name="block">The block to map.</param>
    /// <returns>A <typeparamref name="TComponent"/> if successful.</returns>
    public static TComponent? MapComponent<TComponent>(this IUmbracoMapper mapper, IBlockReference<IPublishedElement, IPublishedElement>? block) where TComponent : class, IComponent
    {
        if (block is null)
        {
            return default;
        }

        return mapper.MapComponent<TComponent>(block.Content);
    }

    /// <summary>
    /// Maps a single block reference to a <see cref="IComponent"/>.
    /// </summary>
    /// <param name="mapper">The current umbraco mapper.</param>
    /// <param name="block">The block to map.</param>
    /// <returns>A <see cref="IComponent"/> if successful.</returns>
    public static IComponent? MapComponent(this IUmbracoMapper mapper, IBlockReference<IPublishedElement, IPublishedElement>? block)
    {
        return mapper.MapComponent<IComponent>(block);
    }

    /// <summary>
    /// Maps a <see cref="IPublishedElement"/> to a <typeparamref name="TComponent"/>.
    /// </summary>
    /// <typeparam name="TComponent">The type of the component.</typeparam>
    /// <param name="mapper">The current umbraco mapper.</param>
    /// <param name="element">The element to map.</param>
    /// <returns>A <typeparamref name="TComponent"/> if successful.</returns>
    public static TComponent? MapComponent<TComponent>(this IUmbracoMapper mapper, IPublishedElement? element) where TComponent : class, IComponent
    {
        if (element is null)
        {
            return default;
        }

        return mapper.Map<TComponent?>(element);
    }

    /// <summary>
    /// Maps a <see cref="IPublishedElement"/> to a <see cref="IComponent"/>.
    /// </summary>
    /// <param name="mapper">The current umbraco mapper.</param>
    /// <param name="element">The element to map.</param>
    /// <returns>A <see cref="IComponent"/> if successful.</returns>
    public static IComponent? MapComponent(this IUmbracoMapper mapper, IPublishedElement? element)
    {
        return mapper.MapComponent<IComponent>(element);
    }

    /// <summary>
    /// Maps the first item from a <see cref="BlockListModel"/> to a <typeparamref name="TComponent"/>.
    /// </summary>
    /// <typeparam name="TComponent">The type of the component.</typeparam>
    /// <param name="mapper">The current umbraco mapper.</param>
    /// <param name="list">The list to map.</param>
    /// <returns>A <typeparamref name="TComponent"/> if successful.</returns>
    public static TComponent? MapComponent<TComponent>(this IUmbracoMapper mapper, BlockListModel list) where TComponent : class, IComponent
    {
        return mapper.MapComponent<TComponent>(list.FirstOrDefault());
    }

    /// <summary>
    /// Maps the first item from a <see cref="BlockListModel"/> to a <see cref="IComponent"/>.
    /// </summary>
    /// <param name="mapper">The current umbraco mapper.</param>
    /// <param name="list">The list to map.</param>
    /// <returns>A <see cref="IComponent"/> if successful.</returns>
    public static IComponent? MapComponent(this IUmbracoMapper mapper, BlockListModel list)
    {
        return mapper.MapComponent<IComponent>(list);
    }

    /// <summary>
    /// Maps the a <see cref="BlockGridModel"/> to a <see cref="IComponent"/>.
    /// </summary>
    /// <param name="mapper">The current umbraco mapper.</param>
    /// <param name="grid">The grid to map.</param>
    /// <returns>A <see cref="IComponent"/> if successful.</returns>
    public static IComponent? MapComponent(this IUmbracoMapper mapper, BlockGridModel? grid)
    {
        return mapper.MapComponent<IComponent>(grid);
    }

    /// <summary>
    /// Maps the a <see cref="BlockGridModel"/> to a <typeparamref name="TComponent"/>.
    /// </summary>
    /// <param name="mapper">The current umbraco mapper.</param>
    /// <param name="grid">The grid to map.</param>
    /// <returns>A <typeparamref name="TComponent"/> if successful.</returns>
    public static TComponent? MapComponent<TComponent>(this IUmbracoMapper mapper, BlockGridModel? grid) where TComponent : class, IComponent
    {
        if (grid is null)
        {
            return default;
        }

        return mapper.Map<TComponent?>(grid);
    }
}