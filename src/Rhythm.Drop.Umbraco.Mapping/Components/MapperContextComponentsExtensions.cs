namespace Rhythm.Drop.Umbraco.Mapping.Components;

using global::Umbraco.Cms.Core.Mapping;
using global::Umbraco.Cms.Core.Models.Blocks;
using global::Umbraco.Cms.Core.Models.PublishedContent;
using Rhythm.Drop.Models.Components;

/// <summary>
/// A collection of methods to augment <see cref="MapperContext"/> to map to collections of <see cref="IComponent"/> objects.
/// </summary>
public static class MapperContextComponentsExtensions
{
    /// <summary>
    /// Maps a <see cref="IPublishedContent"/> to a collection of <typeparamref name="TComponent"/>.
    /// </summary>
    /// <typeparam name="TComponent">The type of the component.</typeparam>
    /// <param name="mapperContext">The current mapper context.</param>
    /// <param name="content">The content to map.</param>
    /// <returns>
    /// <para>An array of <see cref="IComponent"/>.</para>
    /// <para>This method will return an empty collection if <paramref name="content"/> is <see langword="null"/>.</para>
    /// </returns>
    public static TComponent[] MapComponents<TComponent>(this MapperContext mapperContext, IPublishedContent? content) where TComponent : class, IComponent
    {
        if (content is null)
        {
            return [];
        }

        var component = mapperContext.Map<TComponent[]>(content);

        return component ?? [];
    }

    /// <summary>
    /// Maps a <see cref="IPublishedContent"/> to a collection of <see cref="IComponent"/>.
    /// </summary>
    /// <param name="mapperContext">The current mapper context.</param>
    /// <param name="content">The content to map.</param>
    /// <returns>
    /// <para>An array of <see cref="IComponent"/>.</para>
    /// <para>This method will return an empty collection if <paramref name="content"/> is <see langword="null"/>.</para>
    /// </returns>
    public static IComponent[] MapComponents(this MapperContext mapperContext, IPublishedContent? content)
    {
        return mapperContext.MapComponents<IComponent>(content);
    }

    /// <summary>
    /// Maps a <see cref="BlockListModel"/> to a collection of <typeparamref name="TComponent"/>.
    /// </summary>
    /// <typeparam name="TComponent">The type of the component.</typeparam>
    /// <param name="mapperContext">The current mapper context.</param>
    /// <param name="list">The list to map.</param>
    /// <returns>
    /// <para>An array of <typeparamref name="TComponent"/>.</para>
    /// <para>This method will return an empty collection if <paramref name="list"/> is <see langword="null"/>.</para>
    /// </returns>
    public static TComponent[] MapComponents<TComponent>(this MapperContext mapperContext, BlockListModel? list) where TComponent : class, IComponent
    {
        if (list is null)
        {
            return [];
        }

        var components = new List<TComponent>();
        foreach (var block in list)
        {
            var component = mapperContext.MapComponent<TComponent>(block);
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
    /// <param name="mapperContext">The current mapper context.</param>
    /// <param name="list">The list to map.</param>
    /// <returns>
    /// <para>An array of <see cref="IComponent"/>.</para>
    /// <para>This method will return an empty collection if <paramref name="list"/> is <see langword="null"/>.</para>
    /// </returns>
    public static IComponent[] MapComponents(this MapperContext mapperContext, BlockListModel? list)
    {
        return mapperContext.MapComponents<IComponent>(list);
    }

    /// <summary>
    /// Maps a <see cref="BlockGridModel"/> to a collection of <see cref="IComponent"/>.
    /// </summary>
    /// <param name="mapperContext">The current mapper context.</param>
    /// <param name="grid">The grid to map.</param>
    /// <returns>
    /// <para>An array of <typeparamref name="TComponent"/>.</para>
    /// <para>This method will return an empty collection if <paramref name="grid"/> is <see langword="null"/>.</para>
    /// </returns>
    public static TComponent[] MapComponents<TComponent>(this MapperContext mapperContext, BlockGridModel? grid) where TComponent : class, IComponent
    {
        var gridComponent = mapperContext.MapComponent<TComponent>(grid);
        if (gridComponent is null)
        {
            return [];
        }

        return [gridComponent];
    }

    /// <summary>
    /// Maps a <see cref="BlockGridModel"/> to a collection of <see cref="IComponent"/>.
    /// </summary>
    /// <param name="mapperContext">The current mapper context.</param>
    /// <param name="grid">The grid to map.</param>
    /// <returns>
    /// <para>An array of <see cref="IComponent"/>.</para>
    /// <para>This method will return an empty collection if <paramref name="grid"/> is <see langword="null"/>.</para>
    /// </returns>
    public static IComponent[] MapComponents(this MapperContext mapperContext, BlockGridModel? grid)
    {
        return mapperContext.MapComponents<IComponent>(grid);
    }
}