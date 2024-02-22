namespace Rhythm.Drop.Umbraco.Mapping.Components;

using global::Umbraco.Cms.Core.Models.Blocks;
using Rhythm.Drop.Models.Components;

/// <inheritdoc/>
public abstract class BlockGridComponentMapDefinition<TComponent> : ComponentMapDefinition<BlockGridModel, TComponent> where TComponent : class, IComponent
{
}

/// <inheritdoc/>
public abstract class BlockGridComponentMapDefinition : ComponentMapDefinition<BlockGridModel>
{
}