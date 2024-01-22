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
    private static readonly Action<MapperContext> _defaultContextFunc = (c) => { };

    /// <summary>
    /// Maps a <see cref="IPublishedContent"/> to a collection of <typeparamref name="TComponent"/>.
    /// </summary>
    /// <typeparam name="TComponent">The type of the component.</typeparam>
    /// <param name="mapper">The current umbraco mapper.</param>
    /// <param name="content">The content to map.</param>
    /// <param name="configureContext">The optional configure mapper context action.</param>
    /// <returns>
    /// <para>An array of <see cref="IComponent"/>.</para>
    /// <para>This method will return an empty collection if <paramref name="content"/> is <see langword="null"/>.</para>
    /// </returns>
    public static TComponent[] MapComponents<TComponent>(this IUmbracoMapper mapper, IPublishedContent? content, Action<MapperContext>? configureContext = default) where TComponent : class, IComponent
    {
        if (content is null)
        {
            return [];
        }

        var component = mapper.Map<TComponent[]>(content, configureContext ?? _defaultContextFunc);

        return component ?? [];
    }

    /// <summary>
    /// Maps a <see cref="IPublishedContent"/> to a collection of <see cref="IComponent"/>.
    /// </summary>
    /// <param name="mapper">The current umbraco mapper.</param>
    /// <param name="content">The content to map.</param>
    /// <param name="configureContext">The optional configure mapper context action.</param>
    /// <returns>
    /// <para>An array of <see cref="IComponent"/>.</para>
    /// <para>This method will return an empty collection if <paramref name="content"/> is <see langword="null"/>.</para>
    /// </returns>
    public static IComponent[] MapComponents(this IUmbracoMapper mapper, IPublishedContent? content, Action<MapperContext>? configureContext = default)
    {
        return mapper.MapComponents<IComponent>(content, configureContext);
    }

    /// <summary>
    /// Maps a <see cref="IPublishedContent"/> to a collection of <see cref="IComponent"/>.
    /// </summary>
    /// <param name="mapper">The current umbraco mapper.</param>
    /// <param name="content">The content to map.</param>
    /// <returns>
    /// <para>An array of <see cref="IComponent"/>.</para>
    /// <para>This method will return an empty collection if <paramref name="content"/> is <see langword="null"/>.</para>
    /// </returns>
    public static TComponent[] MapComponents<TComponent>(this IUmbracoMapper mapper, IPublishedContent? content) where TComponent : class, IComponent
    {
        void configureContext(MapperContext context)
        {
            context.Items["CurrentPage"] = content;
        }

        return mapper.MapComponents<TComponent>(content, configureContext);
    }

    /// <summary>
    /// Maps a <see cref="IPublishedContent"/> to a collection of <see cref="IComponent"/>.
    /// </summary>
    /// <param name="mapper">The current umbraco mapper.</param>
    /// <param name="content">The content to map.</param>
    /// <returns>
    /// <para>An array of <see cref="IComponent"/>.</para>
    /// <para>This method will return an empty collection if <paramref name="content"/> is <see langword="null"/>.</para>
    /// </returns>
    public static IComponent[] MapComponents(this IUmbracoMapper mapper, IPublishedContent? content)
    {
        return mapper.MapComponents<IComponent>(content);
    }

    /// <summary>
    /// Maps a <see cref="BlockListModel"/> to a collection of <typeparamref name="TComponent"/>.
    /// </summary>
    /// <typeparam name="TComponent">The type of the component.</typeparam>
    /// <param name="mapper">The current umbraco mapper.</param>
    /// <param name="list">The list to map.</param>
    /// <param name="configureContext">The optional configure mapper context action.</param>
    /// <returns>
    /// <para>An array of <typeparamref name="TComponent"/>.</para>
    /// <para>This method will return an empty collection if <paramref name="list"/> is <see langword="null"/>.</para>
    /// </returns>
    public static TComponent[] MapComponents<TComponent>(this IUmbracoMapper mapper, BlockListModel? list, Action<MapperContext>? configureContext = default) where TComponent : class, IComponent
    {
        if (list is null)
        {
            return [];
        }

        var components = new List<TComponent>();
        foreach (var block in list)
        {
            var component = mapper.MapComponent<TComponent>(block.Content, configureContext);
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
    /// <param name="configureContext">The optional configure mapper context action.</param>
    /// <returns>
    /// <para>An array of <see cref="IComponent"/>.</para>
    /// <para>This method will return an empty collection if <paramref name="list"/> is <see langword="null"/>.</para>
    /// </returns>
    public static IComponent[] MapComponents(this IUmbracoMapper mapper, BlockListModel? list, Action<MapperContext>? configureContext = default)
    {
        return mapper.MapComponents<IComponent>(list, configureContext);
    }

    /// <summary>
    /// Maps a <see cref="BlockGridModel"/> to a collection of <see cref="IComponent"/>.
    /// </summary>
    /// <param name="mapper">The current umbraco mapper.</param>
    /// <param name="grid">The grid to map.</param>
    /// <param name="configureContext">The optional configure mapper context action.</param>
    /// <returns>
    /// <para>An array of <typeparamref name="TComponent"/>.</para>
    /// <para>This method will return an empty collection if <paramref name="grid"/> is <see langword="null"/>.</para>
    /// </returns>
    public static TComponent[] MapComponents<TComponent>(this IUmbracoMapper mapper, BlockGridModel? grid, Action<MapperContext>? configureContext = default) where TComponent : class, IComponent
    {
        var gridComponent = mapper.MapComponent<TComponent>(grid, configureContext);
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
    /// <param name="configureContext">The optional configure mapper context action.</param>
    /// <returns>
    /// <para>An array of <see cref="IComponent"/>.</para>
    /// <para>This method will return an empty collection if <paramref name="grid"/> is <see langword="null"/>.</para>
    /// </returns>
    public static IComponent[] MapComponents(this IUmbracoMapper mapper, BlockGridModel? grid, Action<MapperContext>? configureContext = default)
    {
        return mapper.MapComponents<IComponent>(grid, configureContext);
    }
}