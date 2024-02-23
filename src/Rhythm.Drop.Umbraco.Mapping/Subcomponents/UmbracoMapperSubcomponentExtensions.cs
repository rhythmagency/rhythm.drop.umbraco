namespace Rhythm.Drop.Umbraco.Mapping.Subcomponents;

using global::Umbraco.Cms.Core.Mapping;
using global::Umbraco.Cms.Core.Models.Blocks;
using global::Umbraco.Cms.Core.Models.PublishedContent;
using Rhythm.Drop.Models.Subcomponents;

/// <summary>
/// A collection of methods to augment <see cref="IUmbracoMapper"/> to map <see cref="ISubcomponent"/> objects.
/// </summary>
public static class UmbracoMapperSubcomponentExtensions
{
    private static readonly Action<MapperContext> _defaultContextFunc = (c) => { };

    /// <summary>
    /// Maps a single block reference to a <typeparamref name="TSubcomponent"/>.
    /// </summary>
    /// <typeparam name="TSubcomponent">The type of the subcomponent.</typeparam>
    /// <param name="mapper">The current umbraco mapper.</param>
    /// <param name="block">The block to map.</param>
    /// <param name="configureContext">The optional configure mapper context action.</param>
    /// <returns>
    /// <para>A <typeparamref name="TSubcomponent"/> if successful.</para>
    /// <para>This method will return <see langword="default" /> if <paramref name="block"/> is <see langword="null"/>.</para>
    /// </returns>
    public static TSubcomponent? MapSubcomponent<TSubcomponent>(this IUmbracoMapper mapper, IBlockReference<IPublishedElement, IPublishedElement>? block, Action<MapperContext>? configureContext = default) where TSubcomponent : class, ISubcomponent
    {
        if (block is null)
        {
            return default;
        }

        return mapper.Map<TSubcomponent>(block, configureContext ?? _defaultContextFunc);
    }

    /// <summary>
    /// Maps a single block reference to a <see cref="ISubcomponent"/>.
    /// </summary>
    /// <param name="mapper">The current umbraco mapper.</param>
    /// <param name="block">The block to map.</param>
    /// <param name="configureContext">The optional configure mapper context action.</param>
    /// <returns>
    /// <para>A <see cref="ISubcomponent"/> if successful.</para>
    /// <para>This method will return <see langword="default" /> if <paramref name="block"/> is <see langword="null"/>.</para>
    /// </returns>
    public static ISubcomponent? MapSubcomponent(this IUmbracoMapper mapper, IBlockReference<IPublishedElement, IPublishedElement>? block, Action<MapperContext>? configureContext = default)
    {
        return mapper.MapSubcomponent<ISubcomponent>(block, configureContext);
    }

    /// <summary>
    /// Maps a <see cref="IPublishedElement"/> to a <typeparamref name="TSubcomponent"/>.
    /// </summary>
    /// <typeparam name="TSubcomponent">The type of the subcomponent.</typeparam>
    /// <param name="mapper">The current umbraco mapper.</param>
    /// <param name="element">The element to map.</param>
    /// <param name="configureContext">The optional configure mapper context action.</param>
    /// <returns>
    /// <para>A <typeparamref name="TSubcomponent"/> if successful.</para>
    /// <para>This method will return <see langword="default" /> if <paramref name="element"/> is <see langword="null"/>.</para>
    /// </returns>
    public static TSubcomponent? MapSubcomponent<TSubcomponent>(this IUmbracoMapper mapper, IPublishedElement? element, Action<MapperContext>? configureContext = default) where TSubcomponent : class, ISubcomponent
    {
        if (element is null)
        {
            return default;
        }

        return mapper.Map<TSubcomponent>(element, configureContext ?? _defaultContextFunc);
    }

    /// <summary>
    /// Maps a <see cref="IPublishedElement"/> to a <see cref="ISubcomponent"/>.
    /// </summary>
    /// <param name="mapper">The current umbraco mapper.</param>
    /// <param name="element">The element to map.</param>
    /// <param name="configureContext">The optional configure mapper context action.</param>
    /// <returns>
    /// <para>A <see cref="ISubcomponent"/> if successful.</para>
    /// <para>This method will return <see langword="default" /> if <paramref name="element"/> is <see langword="null"/>.</para>
    /// </returns>
    public static ISubcomponent? MapSubcomponent(this IUmbracoMapper mapper, IPublishedElement? element, Action<MapperContext>? configureContext = default)
    {
        return mapper.MapSubcomponent<ISubcomponent>(element, configureContext);
    }

    /// <summary>
    /// Maps the first item from a <see cref="BlockListModel"/> to a <typeparamref name="TSubcomponent"/>.
    /// </summary>
    /// <typeparam name="TSubcomponent">The type of the subcomponent.</typeparam>
    /// <param name="mapper">The current umbraco mapper.</param>
    /// <param name="list">The list to map.</param>
    /// <param name="configureContext">The optional configure mapper context action.</param>
    /// <returns>
    /// <para>A <typeparamref name="TSubcomponent"/> if successful.</para>
    /// <para>This method will return <see langword="default" /> if <paramref name="list"/> or its first item are <see langword="null"/>.</para>
    /// </returns>
    public static TSubcomponent? MapSubcomponent<TSubcomponent>(this IUmbracoMapper mapper, BlockListModel? list, Action<MapperContext>? configureContext = default) where TSubcomponent : class, ISubcomponent
    {
        if (list is null)
        {
            return default;
        }

        return mapper.MapSubcomponent<TSubcomponent>(list.FirstOrDefault(), configureContext);
    }

    /// <summary>
    /// Maps the first item from a <see cref="BlockListModel"/> to a <see cref="ISubcomponent"/>.
    /// </summary>
    /// <param name="mapper">The current umbraco mapper.</param>
    /// <param name="list">The list to map.</param>
    /// <param name="configureContext">The optional configure mapper context action.</param>
    /// <returns>
    /// <para>A <see cref="ISubcomponent"/> if successful.</para>
    /// <para>This method will return <see langword="default" /> if <paramref name="list"/> or its first item are <see langword="null"/>.</para>
    /// </returns>
    public static ISubcomponent? MapSubcomponent(this IUmbracoMapper mapper, BlockListModel? list, Action<MapperContext>? configureContext = default)
    {
        return mapper.MapSubcomponent<ISubcomponent>(list, configureContext);
    }
}