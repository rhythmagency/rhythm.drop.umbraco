namespace Rhythm.Drop.Umbraco.Mapping.Components;

using global::Umbraco.Cms.Core.Mapping;
using global::Umbraco.Cms.Core.Models.Blocks;
using global::Umbraco.Cms.Core.Models.PublishedContent;
using Rhythm.Drop.Models.Components;

/// <summary>
/// A collection of methods to augment <see cref="IUmbracoMapper"/> to collections of <see cref="IComponent"/> objects.
/// </summary>
public static class UmbracoMapperComponentsExtensions
{
    /// <summary>
    /// Maps a <see cref="IPublishedContent"/> to a collection of <typeparamref name="TComponent"/>.
    /// </summary>
    /// <typeparam name="TComponent">The type of the component.</typeparam>
    /// <param name="mapper">The current umbraco mapper.</param>
    /// <param name="content">The content to map.</param>
    /// <returns>An array of <see cref="IComponent"/>.</returns>
    public static TComponent[] MapComponents<TComponent>(this IUmbracoMapper mapper, IPublishedContent content) where TComponent : class, IComponent
    {
        var component = mapper.Map<TComponent[]>(content, (context) =>
        {
            context.Items["CurrentPage"] = content;
        });

        return component ?? [];
    }

    /// <summary>
    /// Maps a <see cref="IPublishedContent"/> to a collection of <see cref="IComponent"/>.
    /// </summary>
    /// <param name="mapper">The current umbraco mapper.</param>
    /// <param name="content">The content to map.</param>
    /// <returns>An array of <see cref="IComponent"/>.</returns>
    public static IComponent[] MapComponents(this IUmbracoMapper mapper, IPublishedContent content)
    {
        return mapper.MapComponents<IComponent>(content);
    }

    /// <summary>
    /// Maps a <see cref="BlockListModel"/> to a collection of <typeparamref name="TComponent"/>.
    /// </summary>
    /// <typeparam name="TComponent">The type of the component.</typeparam>
    /// <param name="mapper">The current umbraco mapper.</param>
    /// <param name="list">The list to map.</param>
    /// <returns>An array of <typeparamref name="TComponent"/>.</returns>
    public static TComponent[] MapComponents<TComponent>(this IUmbracoMapper mapper, BlockListModel list) where TComponent : class, IComponent
    {
        var components = new List<TComponent>();
        foreach (var block in list)
        {
            var component = mapper.Map<TComponent?>(block.Content);
            if (component is null)
            {
                continue;
            }

            components.Add(component);
        }

        return [.. components];
    }

    /// <summary>
    /// Maps a <see cref="BlockListModel"/> to a collection of <see cref="IComponent"/>.
    /// </summary>
    /// <param name="mapper">The current umbraco mapper.</param>
    /// <param name="list">The list to map.</param>
    /// <returns>An array of <see cref="IComponent"/>.</returns>
    public static IComponent[] MapComponents(this IUmbracoMapper mapper, BlockListModel list)
    {
        return mapper.MapComponents<IComponent>(list);
    }

    /// <summary>
    /// Maps a <see cref="BlockGridModel"/> to a collection of <see cref="IComponent"/>.
    /// </summary>
    /// <param name="mapper">The current umbraco mapper.</param>
    /// <param name="grid">The grid to map.</param>
    /// <returns>An array of <typeparamref name="TComponent"/>.</returns>
    public static TComponent[] MapComponents<TComponent>(this IUmbracoMapper mapper, BlockGridModel? grid) where TComponent : class, IComponent
    {
        var gridComponent = mapper.MapComponent<TComponent>(grid);
        if (gridComponent is null)
        {
            return [];
        }

        return [gridComponent];
    }

    /// <summary>
    /// Maps a <see cref="BlockGridModel"/> to a collection of <see cref="IComponent"/>.
    /// </summary>
    /// <param name="mapper">The current umbraco mapper.</param>
    /// <param name="grid">The grid to map.</param>
    /// <returns>An array of <see cref="IComponent"/>.</returns>
    public static IComponent[] MapComponents(this IUmbracoMapper mapper, BlockGridModel? grid)
    {
        return mapper.MapComponents<IComponent>(grid);
    }
}