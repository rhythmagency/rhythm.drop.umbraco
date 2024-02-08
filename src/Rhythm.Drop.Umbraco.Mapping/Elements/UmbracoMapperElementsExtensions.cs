namespace Rhythm.Drop.Umbraco.Mapping.Elements;

using global::Umbraco.Cms.Core.Mapping;
using global::Umbraco.Cms.Core.Models.Blocks;
using Rhythm.Drop.Models.Elements;

/// <summary>
/// A collection of methods to augment <see cref="IUmbracoMapper"/> to collections of <see cref="IElement"/> objects.
/// </summary>
public static class UmbracoMapperElementsExtensions
{
    private static readonly Action<MapperContext> _defaultContextFunc = (c) => { };

    /// <summary>
    /// Maps a <see cref="BlockListModel"/> to a collection of <typeparamref name="TElement"/>.
    /// </summary>
    /// <typeparam name="TElement">The type of the element.</typeparam>
    /// <param name="mapper">The current umbraco mapper.</param>
    /// <param name="list">The list to map.</param>
    /// <param name="configureContext">The optional configure mapper context action.</param>
    /// <returns>
    /// <para>An array of <typeparamref name="TElement"/>.</para>
    /// <para>This method will return an empty collection if <paramref name="list"/> is <see langword="null"/>.</para>
    /// </returns>
    public static TElement[] MapElements<TElement>(this IUmbracoMapper mapper, BlockListModel? list, Action<MapperContext>? configureContext = default) where TElement : class, IElement
    {
        if (list is null)
        {
            return [];
        }

        var elements = new List<TElement>();
        foreach (var block in list)
        {
            var element = mapper.MapElement<TElement>(block.Content, configureContext);
            if (element is null)
            {
                continue;
            }

            elements.Add(element);
        }

        return [.. elements];
    }

    /// <summary>
    /// Maps a <see cref="BlockListModel"/> to a collection of <see cref="IElement"/>.
    /// </summary>
    /// <param name="mapper">The current umbraco mapper.</param>
    /// <param name="list">The list to map.</param>
    /// <param name="configureContext">The optional configure mapper context action.</param>
    /// <returns>
    /// <para>An array of <see cref="IElement"/>.</para>
    /// <para>This method will return an empty collection if <paramref name="list"/> is <see langword="null"/>.</para>
    /// </returns>
    public static IElement[] MapElements(this IUmbracoMapper mapper, BlockListModel? list, Action<MapperContext>? configureContext = default)
    {
        return mapper.MapElements<IElement>(list, configureContext);
    }
}