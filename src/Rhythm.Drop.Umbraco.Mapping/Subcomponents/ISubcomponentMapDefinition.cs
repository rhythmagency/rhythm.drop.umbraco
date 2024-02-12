namespace Rhythm.Drop.Umbraco.Mapping.Subcomponents;

using global::Umbraco.Cms.Core.Composing;
using global::Umbraco.Cms.Core.Mapping;
using Rhythm.Drop.Models.Subcomponents;

/// <summary>
/// A contract for creating a map definition that maps a <typeparamref name="TSource"/> to a <typeparamref name="TSubcomponent"/>.
/// </summary>
/// <typeparam name="TSource">The source type.</typeparam>
/// <typeparam name="TSubcomponent">The subcomponent type.</typeparam>
public interface ISubcomponentMapDefinition<in TSource, out TSubcomponent> : ISubcomponentMapDefinition where TSubcomponent : ISubcomponent
{
    /// <summary>
    /// Maps a <typeparamref name="TSource"/> to a <typeparamref name="TSubcomponent"/>.
    /// </summary>
    /// <param name="source">The source object.</param>
    /// <param name="context">The mapper context.</param>
    /// <remarks>A <typeparamref name="TSubcomponent"/> if successful.</remarks>
    TSubcomponent? Map(TSource source, MapperContext context);
}

/// <summary>
/// A base contract for creating a map definition for mapping to a <see cref="ISubcomponent"/>.
/// </summary>
/// <remarks>This exists for type finding and should not be used directly.</remarks>
public interface ISubcomponentMapDefinition : IMapDefinition, IDiscoverable
{
}