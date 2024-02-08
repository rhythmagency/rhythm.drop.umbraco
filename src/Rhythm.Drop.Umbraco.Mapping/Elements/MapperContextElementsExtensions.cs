namespace Rhythm.Drop.Umbraco.Mapping.Elements;

using global::Umbraco.Cms.Core.Mapping;
using global::Umbraco.Cms.Core.Models.Blocks;
using Rhythm.Drop.Models.Elements;

/// <summary>
/// A collection of methods to augment <see cref="MapperContext"/> to map to collections of <see cref="IElement"/> objects.
/// </summary>
public static class MapperContextElementsExtensions
{
    /// <summary>
    /// Maps a <see cref="BlockListModel"/> to a collection of <typeparamref name="TElement"/>.
    /// </summary>
    /// <typeparam name="TElement">The type of the element.</typeparam>
    /// <param name="mapperContext">The current mapper context.</param>
    /// <param name="list">The list to map.</param>
    /// <returns>
    /// <para>An array of <typeparamref name="TElement"/>.</para>
    /// <para>This method will return an empty collection if <paramref name="list"/> is <see langword="null"/>.</para>
    /// </returns>
    public static TElement[] MapElements<TElement>(this MapperContext mapperContext, BlockListModel? list) where TElement : class, IElement
    {
        if (list is null)
        {
            return [];
        }

        var elements = new List<TElement>();
        foreach (var block in list)
        {
            var element = mapperContext.MapElement<TElement>(block.Content);
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
    /// <param name="mapperContext">The current mapper context.</param>
    /// <param name="list">The list to map.</param>
    /// <returns>
    /// <para>An array of <see cref="IElement"/>.</para>
    /// <para>This method will return an empty collection if <paramref name="list"/> is <see langword="null"/>.</para>
    /// </returns>
    public static IElement[] MapElements(this MapperContext mapperContext, BlockListModel? list)
    {
        return mapperContext.MapElements<IElement>(list);
    }
}