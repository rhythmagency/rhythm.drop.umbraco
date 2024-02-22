namespace Rhythm.Drop.Umbraco.Mapping.Components;

using global::Umbraco.Cms.Core.Mapping;
using global::Umbraco.Cms.Core.Models.Blocks;
using global::Umbraco.Cms.Core.Models.PublishedContent;
using Rhythm.Drop.Models.Components;

/// <summary>
/// A collection of methods to augment <see cref="MapperContext"/> to map a <see cref="IComponent"/> object.
/// </summary>
public static class MapperContextComponentExtensions
{
    /// <summary>
    /// Maps a single block reference to a <typeparamref name="TComponent"/>.
    /// </summary>
    /// <typeparam name="TComponent">The type of the component.</typeparam>
    /// <param name="mapperContext">The current mapper context.</param>
    /// <param name="block">The block to map.</param>
    /// <returns>
    /// <para>A <typeparamref name="TComponent"/> if successful.</para>
    /// <para>This method will return <see langword="default" /> if <paramref name="block"/> is <see langword="null"/>.</para>
    /// </returns>
    public static TComponent? MapComponent<TComponent>(this MapperContext mapperContext, IBlockReference<IPublishedElement, IPublishedElement>? block) where TComponent : class, IComponent
    {
        if (block is null)
        {
            return default;
        }

        return mapperContext.Map<TComponent>(block);
    }

    /// <summary>
    /// Maps a single block reference to a <see cref="IComponent"/>.
    /// </summary>
    /// <param name="mapperContext">The current mapper context.</param>
    /// <param name="block">The block to map.</param>
    /// <returns>
    /// <para>A <see cref="IComponent"/> if successful.</para>
    /// <para>This method will return <see langword="default" /> if <paramref name="block"/> is <see langword="null"/>.</para>
    /// </returns>
    public static IComponent? MapComponent(this MapperContext mapperContext, IBlockReference<IPublishedElement, IPublishedElement>? block)
    {
        return mapperContext.MapComponent<IComponent>(block);
    }

    /// <summary>
    /// Maps a <see cref="IPublishedElement"/> to a <typeparamref name="TComponent"/>.
    /// </summary>
    /// <typeparam name="TComponent">The type of the component.</typeparam>
    /// <param name="mapperContext">The current mapper context.</param>
    /// <param name="element">The element to map.</param>
    /// <returns>
    /// <para>A <typeparamref name="TComponent"/> if successful.</para>
    /// <para>This method will return <see langword="default" /> if <paramref name="element"/> is <see langword="null"/>.</para>
    /// </returns>
    public static TComponent? MapComponent<TComponent>(this MapperContext mapperContext, IPublishedElement? element) where TComponent : class, IComponent
    {
        if (element is null)
        {
            return default;
        }

        return mapperContext.Map<TComponent>(element);
    }

    /// <summary>
    /// Maps a <see cref="IPublishedElement"/> to a <see cref="IComponent"/>.
    /// </summary>
    /// <param name="mapperContext">The current mapper context.</param>
    /// <param name="element">The element to map.</param>
    /// <returns>
    /// <para>A <see cref="IComponent"/> if successful.</para>
    /// <para>This method will return <see langword="default" /> if <paramref name="element"/> is <see langword="null"/>.</para>
    /// </returns>
    public static IComponent? MapComponent(this MapperContext mapperContext, IPublishedElement? element)
    {
        return mapperContext.MapComponent<IComponent>(element);
    }

    /// <summary>
    /// Maps the first item from a <see cref="BlockListModel"/> to a <typeparamref name="TComponent"/>.
    /// </summary>
    /// <typeparam name="TComponent">The type of the component.</typeparam>
    /// <param name="mapperContext">The current mapper context.</param>
    /// <param name="list">The list to map.</param>
    /// <returns>
    /// <para>A <typeparamref name="TComponent"/> if successful.</para>
    /// <para>This method will return <see langword="default" /> if <paramref name="list"/> or its first item are <see langword="null"/>.</para>
    /// </returns>
    public static TComponent? MapComponent<TComponent>(this MapperContext mapperContext, BlockListModel? list) where TComponent : class, IComponent
    {
        if (list is null)
        {
            return default;
        }

        return mapperContext.MapComponent<TComponent>(list.FirstOrDefault());
    }

    /// <summary>
    /// Maps the first item from a <see cref="BlockListModel"/> to a <see cref="IComponent"/>.
    /// </summary>
    /// <param name="mapperContext">The current mapper context.</param>
    /// <param name="list">The list to map.</param>
    /// <returns>
    /// <para>A <see cref="IComponent"/> if successful.</para>
    /// <para>This method will return <see langword="default" /> if <paramref name="list"/> or its first item are <see langword="null"/>.</para>
    /// </returns>
    public static IComponent? MapComponent(this MapperContext mapperContext, BlockListModel? list)
    {
        return mapperContext.MapComponent<IComponent>(list);
    }

    /// <summary>
    /// Maps the a <see cref="BlockGridModel"/> to a <typeparamref name="TComponent"/>.
    /// </summary>
    /// <param name="mapperContext">The current mapper context.</param>
    /// <param name="grid">The grid to map.</param>
    /// <returns>
    /// <para>A <typeparamref name="TComponent"/> if successful.</para>
    /// <para>This method will return <see langword="default" /> if <paramref name="grid"/> is <see langword="null"/>.</para>
    /// </returns>
    public static TComponent? MapComponent<TComponent>(this MapperContext mapperContext, BlockGridModel? grid) where TComponent : class, IComponent
    {
        if (grid is null)
        {
            return default;
        }

        return mapperContext.Map<TComponent>(grid);
    }

    /// <summary>
    /// Maps the a <see cref="BlockGridModel"/> to a <see cref="IComponent"/>.
    /// </summary>
    /// <param name="mapperContext">The current mapper context.</param>
    /// <param name="grid">The grid to map.</param>
    /// <returns>
    /// <para>A <see cref="IComponent"/> if successful.</para>
    /// <para>This method will return <see langword="default" /> if <paramref name="grid"/> is null.</para>
    /// </returns>
    public static IComponent? MapComponent(this MapperContext mapperContext, BlockGridModel? grid)
    {
        return mapperContext.MapComponent<IComponent>(grid);
    }
}
