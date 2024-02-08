namespace Rhythm.Drop.Umbraco.Mapping.Modals;

using global::Umbraco.Cms.Core.Mapping;
using global::Umbraco.Cms.Core.Models.Blocks;
using Rhythm.Drop.Models.Modals;

/// <summary>
/// A collection of methods to augment <see cref="IUmbracoMapper"/> to collections of <see cref="IModal"/> objects.
/// </summary>
public static class UmbracoMapperModalsExtensions
{
    private static readonly Action<MapperContext> _defaultContextFunc = (c) => { };

    /// <summary>
    /// Maps a <see cref="BlockListModel"/> to a collection of <typeparamref name="TModal"/>.
    /// </summary>
    /// <typeparam name="TModal">The type of the modal.</typeparam>
    /// <param name="mapper">The current umbraco mapper.</param>
    /// <param name="list">The list to map.</param>
    /// <param name="configureContext">The optional configure mapper context action.</param>
    /// <returns>
    /// <para>An array of <typeparamref name="TModal"/>.</para>
    /// <para>This method will return an empty collection if <paramref name="list"/> is <see langword="null"/>.</para>
    /// </returns>
    public static TModal[] MapModals<TModal>(this IUmbracoMapper mapper, BlockListModel? list, Action<MapperContext>? configureContext = default) where TModal : class, IModal
    {
        if (list is null)
        {
            return [];
        }

        var modals = new List<TModal>();
        foreach (var block in list)
        {
            var modal = mapper.MapModal<TModal>(block.Content, configureContext);
            if (modal is null)
            {
                continue;
            }

            modals.Add(modal);
        }

        return [.. modals];
    }

    /// <summary>
    /// Maps a <see cref="BlockListModel"/> to a collection of <see cref="IModal"/>.
    /// </summary>
    /// <param name="mapper">The current umbraco mapper.</param>
    /// <param name="list">The list to map.</param>
    /// <param name="configureContext">The optional configure mapper context action.</param>
    /// <returns>
    /// <para>An array of <see cref="IModal"/>.</para>
    /// <para>This method will return an empty collection if <paramref name="list"/> is <see langword="null"/>.</para>
    /// </returns>
    public static IModal[] MapModals(this IUmbracoMapper mapper, BlockListModel? list, Action<MapperContext>? configureContext = default)
    {
        return mapper.MapModals<IModal>(list, configureContext);
    }
}