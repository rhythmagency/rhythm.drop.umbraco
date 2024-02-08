namespace Rhythm.Drop.Umbraco.Mapping.Modals;

using global::Umbraco.Cms.Core.Composing;
using global::Umbraco.Cms.Core.Mapping;
using Rhythm.Drop.Models.Modals;

/// <summary>
/// A contract for creating a map definition that maps a <typeparamref name="TSource"/> to a <typeparamref name="TModal"/>.
/// </summary>
/// <typeparam name="TSource">The source type.</typeparam>
/// <typeparam name="TModal">The modal type.</typeparam>
public interface IModalMapDefinition<in TSource, out TModal> : IModalMapDefinition where TModal : IModal
{
    /// <summary>
    /// Maps a <typeparamref name="TSource"/> to a <typeparamref name="TModal"/>.
    /// </summary>
    /// <param name="source">The source object.</param>
    /// <param name="context">The mapper context.</param>
    /// <remarks>A <typeparamref name="TModal"/> if successful.</remarks>
    TModal? Map(TSource source, MapperContext context);
}

/// <summary>
/// A base contract for creating a map definition for mapping to a <see cref="IModal"/>.
/// </summary>
/// <remarks>This exists for type finding and should not be used directly.</remarks>
public interface IModalMapDefinition : IMapDefinition, IDiscoverable
{
}