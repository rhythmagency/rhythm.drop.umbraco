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
    private static readonly Action<MapperContext> _defaultContextFunc = (c) => { };

    /// <summary>
    /// Maps a single block reference to a <typeparamref name="TComponent"/>.
    /// </summary>
    /// <typeparam name="TComponent">The type of the component.</typeparam>
    /// <param name="mapper">The current umbraco mapper.</param>
    /// <param name="block">The block to map.</param>
    /// <param name="configureContext">The optional configure mapper context action.</param>
    /// <returns>
    /// <para>A <typeparamref name="TComponent"/> if successful.</para>
    /// <para>This method will return <see langword="default" /> if <paramref name="block"/> is <see langword="null"/>.</para>
    /// </returns>
    public static TComponent? MapComponent<TComponent>(this IUmbracoMapper mapper, IBlockReference<IPublishedElement, IPublishedElement>? block, Action<MapperContext>? configureContext = default) where TComponent : class, IComponent
    {
        if (block is null)
        {
            return default;
        }

        return mapper.MapComponent<TComponent>(block.Content, configureContext);
    }

    /// <summary>
    /// Maps a single block reference to a <see cref="IComponent"/>.
    /// </summary>
    /// <param name="mapper">The current umbraco mapper.</param>
    /// <param name="block">The block to map.</param>
    /// <param name="configureContext">The optional configure mapper context action.</param>
    /// <returns>
    /// <para>A <see cref="IComponent"/> if successful.</para>
    /// <para>This method will return <see langword="default" /> if <paramref name="block"/> is <see langword="null"/>.</para>
    /// </returns>
    public static IComponent? MapComponent(this IUmbracoMapper mapper, IBlockReference<IPublishedElement, IPublishedElement>? block, Action<MapperContext>? configureContext = default)
    {
        return mapper.MapComponent<IComponent>(block, configureContext);
    }

    /// <summary>
    /// Maps a <see cref="IPublishedElement"/> to a <typeparamref name="TComponent"/>.
    /// </summary>
    /// <typeparam name="TComponent">The type of the component.</typeparam>
    /// <param name="mapper">The current umbraco mapper.</param>
    /// <param name="element">The element to map.</param>
    /// <param name="configureContext">The optional configure mapper context action.</param>
    /// <returns>
    /// <para>A <typeparamref name="TComponent"/> if successful.</para>
    /// <para>This method will return <see langword="default" /> if <paramref name="element"/> is <see langword="null"/>.</para>
    /// </returns>
    public static TComponent? MapComponent<TComponent>(this IUmbracoMapper mapper, IPublishedElement? element, Action<MapperContext>? configureContext = default) where TComponent : class, IComponent
    {
        if (element is null)
        {
            return default;
        }

        return mapper.Map<TComponent?>(element, configureContext ?? _defaultContextFunc);
    }

    /// <summary>
    /// Maps a <see cref="IPublishedElement"/> to a <see cref="IComponent"/>.
    /// </summary>
    /// <param name="mapper">The current umbraco mapper.</param>
    /// <param name="element">The element to map.</param>
    /// <param name="configureContext">The optional configure mapper context action.</param>
    /// <returns>
    /// <para>A <see cref="IComponent"/> if successful.</para>
    /// <para>This method will return <see langword="default" /> if <paramref name="element"/> is <see langword="null"/>.</para>
    /// </returns>
    public static IComponent? MapComponent(this IUmbracoMapper mapper, IPublishedElement? element, Action<MapperContext>? configureContext = default)
    {
        return mapper.MapComponent<IComponent>(element, configureContext);
    }

    /// <summary>
    /// Maps the first item from a <see cref="BlockListModel"/> to a <typeparamref name="TComponent"/>.
    /// </summary>
    /// <typeparam name="TComponent">The type of the component.</typeparam>
    /// <param name="mapper">The current umbraco mapper.</param>
    /// <param name="list">The list to map.</param>
    /// <param name="configureContext">The optional configure mapper context action.</param>
    /// <returns>
    /// <para>A <typeparamref name="TComponent"/> if successful.</para>
    /// <para>This method will return <see langword="default" /> if <paramref name="list"/> or its first item are <see langword="null"/>.</para>
    /// </returns>
    public static TComponent? MapComponent<TComponent>(this IUmbracoMapper mapper, BlockListModel? list, Action<MapperContext>? configureContext = default) where TComponent : class, IComponent
    {
        if (list is null)
        {
            return default;
        }

        return mapper.MapComponent<TComponent>(list.FirstOrDefault(), configureContext);
    }

    /// <summary>
    /// Maps the first item from a <see cref="BlockListModel"/> to a <see cref="IComponent"/>.
    /// </summary>
    /// <param name="mapper">The current umbraco mapper.</param>
    /// <param name="list">The list to map.</param>
    /// <param name="configureContext">The optional configure mapper context action.</param>
    /// <returns>
    /// <para>A <see cref="IComponent"/> if successful.</para>
    /// <para>This method will return <see langword="default" /> if <paramref name="list"/> or its first item are <see langword="null"/>.</para>
    /// </returns>
    public static IComponent? MapComponent(this IUmbracoMapper mapper, BlockListModel? list, Action<MapperContext>? configureContext = default)
    {
        return mapper.MapComponent<IComponent>(list, configureContext);
    }

    /// <summary>
    /// Maps the a <see cref="BlockGridModel"/> to a <see cref="IComponent"/>.
    /// </summary>
    /// <param name="mapper">The current umbraco mapper.</param>
    /// <param name="grid">The grid to map.</param>
    /// <param name="configureContext">The optional configure mapper context action.</param>
    /// <returns>
    /// <para>A <see cref="IComponent"/> if successful.</para>
    /// <para>This method will return <see langword="default" /> if <paramref name="grid"/> is <see langword="null"/>.</para>
    /// </returns>
    public static IComponent? MapComponent(this IUmbracoMapper mapper, BlockGridModel? grid, Action<MapperContext>? configureContext = default)
    {
        return mapper.MapComponent<IComponent>(grid, configureContext);
    }

    /// <summary>
    /// Maps the a <see cref="BlockGridModel"/> to a <typeparamref name="TComponent"/>.
    /// </summary>
    /// <param name="mapper">The current umbraco mapper.</param>
    /// <param name="grid">The grid to map.</param>
    /// <param name="configureContext">The optional configure mapper context action.</param>
    /// <returns>
    /// <para>A <typeparamref name="TComponent"/> if successful.</para>
    /// <para>This method will return <see langword="default" /> if <paramref name="grid"/> is <see langword="null"/>.</para>
    /// </returns>
    public static TComponent? MapComponent<TComponent>(this IUmbracoMapper mapper, BlockGridModel? grid, Action<MapperContext>? configureContext = default) where TComponent : class, IComponent
    {
        if (grid is null)
        {
            return default;
        }

        return mapper.Map<TComponent?>(grid, configureContext ?? _defaultContextFunc);
    }
}