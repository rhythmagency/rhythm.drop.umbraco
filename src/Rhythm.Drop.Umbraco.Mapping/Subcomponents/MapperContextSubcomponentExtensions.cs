namespace Rhythm.Drop.Umbraco.Mapping.Subcomponents;

using global::Umbraco.Cms.Core.Mapping;
using global::Umbraco.Cms.Core.Models.Blocks;
using global::Umbraco.Cms.Core.Models.PublishedContent;
using Rhythm.Drop.Models.Subcomponents;

/// <summary>
/// A collection of methods to augment <see cref="MapperContext"/> to map a <see cref="ISubcomponent"/> object.
/// </summary>
public static class MapperContextSubcomponentExtensions
{
    /// <summary>
    /// Maps a single block reference to a <typeparamref name="TSubcomponent"/>.
    /// </summary>
    /// <typeparam name="TSubcomponent">The type of the element.</typeparam>
    /// <param name="mapperContext">The current mapper context.</param>
    /// <param name="block">The block to map.</param>
    /// <returns>
    /// <para>A <typeparamref name="TSubcomponent"/> if successful.</para>
    /// <para>This method will return <see langword="default" /> if <paramref name="block"/> is <see langword="null"/>.</para>
    /// </returns>
    public static TSubcomponent? MapSubcomponent<TSubcomponent>(this MapperContext mapperContext, IBlockReference<IPublishedElement, IPublishedElement>? block) where TSubcomponent : class, ISubcomponent
    {
        if (block is null)
        {
            return default;
        }

        return mapperContext.Map<TSubcomponent>(block);
    }

    /// <summary>
    /// Maps a single block reference to a <see cref="ISubcomponent"/>.
    /// </summary>
    /// <param name="mapperContext">The current mapper context.</param>
    /// <param name="block">The block to map.</param>
    /// <returns>
    /// <para>A <see cref="ISubcomponent"/> if successful.</para>
    /// <para>This method will return <see langword="default" /> if <paramref name="block"/> is <see langword="null"/>.</para>
    /// </returns>
    public static ISubcomponent? MapSubcomponent(this MapperContext mapperContext, IBlockReference<IPublishedElement, IPublishedElement>? block)
    {
        return mapperContext.MapSubcomponent<ISubcomponent>(block);
    }

    /// <summary>
    /// Maps a <see cref="IPublishedElement"/> to a <typeparamref name="TSubcomponent"/>.
    /// </summary>
    /// <typeparam name="TSubcomponent">The type of the element.</typeparam>
    /// <param name="mapperContext">The current mapper context.</param>
    /// <param name="element">The element to map.</param>
    /// <returns>
    /// <para>A <typeparamref name="TSubcomponent"/> if successful.</para>
    /// <para>This method will return <see langword="default" /> if <paramref name="element"/> is <see langword="null"/>.</para>
    /// </returns>
    public static TSubcomponent? MapSubcomponent<TSubcomponent>(this MapperContext mapperContext, IPublishedElement? element) where TSubcomponent : class, ISubcomponent
    {
        if (element is null)
        {
            return default;
        }

        return mapperContext.Map<TSubcomponent>(element);
    }

    /// <summary>
    /// Maps a <see cref="IPublishedElement"/> to a <see cref="ISubcomponent"/>.
    /// </summary>
    /// <param name="mapperContext">The current mapper context.</param>
    /// <param name="element">The element to map.</param>
    /// <returns>
    /// <para>A <see cref="ISubcomponent"/> if successful.</para>
    /// <para>This method will return <see langword="default" /> if <paramref name="element"/> is <see langword="null"/>.</para>
    /// </returns>
    public static ISubcomponent? MapSubcomponent(this MapperContext mapperContext, IPublishedElement? element)
    {
        return mapperContext.MapSubcomponent<ISubcomponent>(element);
    }

    /// <summary>
    /// Maps the first item from a <see cref="BlockListModel"/> to a <typeparamref name="TSubcomponent"/>.
    /// </summary>
    /// <typeparam name="TSubcomponent">The type of the element.</typeparam>
    /// <param name="mapperContext">The current mapper context.</param>
    /// <param name="list">The list to map.</param>
    /// <returns>
    /// <para>A <typeparamref name="TSubcomponent"/> if successful.</para>
    /// <para>This method will return <see langword="default" /> if <paramref name="list"/> or its first item are <see langword="null"/>.</para>
    /// </returns>
    public static TSubcomponent? MapSubcomponent<TSubcomponent>(this MapperContext mapperContext, BlockListModel? list) where TSubcomponent : class, ISubcomponent
    {
        if (list is null)
        {
            return default;
        }

        return mapperContext.MapSubcomponent<TSubcomponent>(list.FirstOrDefault());
    }

    /// <summary>
    /// Maps the first item from a <see cref="BlockListModel"/> to a <see cref="ISubcomponent"/>.
    /// </summary>
    /// <param name="mapperContext">The current mapper context.</param>
    /// <param name="list">The list to map.</param>
    /// <returns>
    /// <para>A <see cref="ISubcomponent"/> if successful.</para>
    /// <para>This method will return <see langword="default" /> if <paramref name="list"/> or its first item are <see langword="null"/>.</para>
    /// </returns>
    public static ISubcomponent? MapSubcomponent(this MapperContext mapperContext, BlockListModel? list)
    {
        return mapperContext.MapSubcomponent<ISubcomponent>(list);
    }
}
