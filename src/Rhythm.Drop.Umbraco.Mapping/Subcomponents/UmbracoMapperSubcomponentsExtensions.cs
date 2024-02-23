namespace Rhythm.Drop.Umbraco.Mapping.Subcomponents;

using global::Umbraco.Cms.Core.Mapping;
using global::Umbraco.Cms.Core.Models.Blocks;
using Rhythm.Drop.Models.Subcomponents;

/// <summary>
/// A collection of methods to augment <see cref="IUmbracoMapper"/> to collections of <see cref="ISubcomponent"/> objects.
/// </summary>
public static class UmbracoMapperSubcomponentsExtensions
{
    private static readonly Action<MapperContext> _defaultContextFunc = (c) => { };

    /// <summary>
    /// Maps a <see cref="BlockListModel"/> to a collection of <typeparamref name="TSubcomponent"/>.
    /// </summary>
    /// <typeparam name="TSubcomponent">The type of the subcomponent.</typeparam>
    /// <param name="mapper">The current umbraco mapper.</param>
    /// <param name="list">The list to map.</param>
    /// <param name="configureContext">The optional configure mapper context action.</param>
    /// <returns>
    /// <para>An array of <typeparamref name="TSubcomponent"/>.</para>
    /// <para>This method will return an empty collection if <paramref name="list"/> is <see langword="null"/>.</para>
    /// </returns>
    public static TSubcomponent[] MapSubcomponents<TSubcomponent>(this IUmbracoMapper mapper, BlockListModel? list, Action<MapperContext>? configureContext = default) where TSubcomponent : class, ISubcomponent
    {
        if (list is null)
        {
            return [];
        }

        var subcomponents = new List<TSubcomponent>();
        foreach (var block in list)
        {
            var subcomponent = mapper.MapSubcomponent<TSubcomponent>(block, configureContext);
            if (subcomponent is null)
            {
                continue;
            }

            subcomponents.Add(subcomponent);
        }

        return [.. subcomponents];
    }

    /// <summary>
    /// Maps a <see cref="BlockListModel"/> to a collection of <see cref="ISubcomponent"/>.
    /// </summary>
    /// <param name="mapper">The current umbraco mapper.</param>
    /// <param name="list">The list to map.</param>
    /// <param name="configureContext">The optional configure mapper context action.</param>
    /// <returns>
    /// <para>An array of <see cref="ISubcomponent"/>.</para>
    /// <para>This method will return an empty collection if <paramref name="list"/> is <see langword="null"/>.</para>
    /// </returns>
    public static ISubcomponent[] MapSubcomponents(this IUmbracoMapper mapper, BlockListModel? list, Action<MapperContext>? configureContext = default)
    {
        return mapper.MapSubcomponents<ISubcomponent>(list, configureContext);
    }
}