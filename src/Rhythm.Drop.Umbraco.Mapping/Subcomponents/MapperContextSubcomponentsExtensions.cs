namespace Rhythm.Drop.Umbraco.Mapping.Subcomponents;

using global::Umbraco.Cms.Core.Mapping;
using global::Umbraco.Cms.Core.Models.Blocks;
using Rhythm.Drop.Models.Subcomponents;

/// <summary>
/// A collection of methods to augment <see cref="MapperContext"/> to map to collections of <see cref="ISubcomponent"/> objects.
/// </summary>
public static class MapperContextSubcomponentsExtensions
{
    /// <summary>
    /// Maps a <see cref="BlockListModel"/> to a collection of <typeparamref name="TSubcomponent"/>.
    /// </summary>
    /// <typeparam name="TSubcomponent">The type of the element.</typeparam>
    /// <param name="mapperContext">The current mapper context.</param>
    /// <param name="list">The list to map.</param>
    /// <returns>
    /// <para>An array of <typeparamref name="TSubcomponent"/>.</para>
    /// <para>This method will return an empty collection if <paramref name="list"/> is <see langword="null"/>.</para>
    /// </returns>
    public static TSubcomponent[] MapSubcomponents<TSubcomponent>(this MapperContext mapperContext, BlockListModel? list) where TSubcomponent : class, ISubcomponent
    {
        if (list is null)
        {
            return [];
        }

        var elements = new List<TSubcomponent>();
        foreach (var block in list)
        {
            var element = mapperContext.MapSubcomponent<TSubcomponent>(block.Content);
            if (element is null)
            {
                continue;
            }

            elements.Add(element);
        }

        return [.. elements];
    }

    /// <summary>
    /// Maps a <see cref="BlockListModel"/> to a collection of <see cref="ISubcomponent"/>.
    /// </summary>
    /// <param name="mapperContext">The current mapper context.</param>
    /// <param name="list">The list to map.</param>
    /// <returns>
    /// <para>An array of <see cref="ISubcomponent"/>.</para>
    /// <para>This method will return an empty collection if <paramref name="list"/> is <see langword="null"/>.</para>
    /// </returns>
    public static ISubcomponent[] MapSubcomponents(this MapperContext mapperContext, BlockListModel? list)
    {
        return mapperContext.MapSubcomponents<ISubcomponent>(list);
    }
}