namespace Rhythm.Drop.Umbraco.Web.Helpers;

using global::Umbraco.Cms.Core.Cache;
using global::Umbraco.Extensions;
using Rhythm.Drop.Models.Modals;
using Rhythm.Drop.Web.Infrastructure.Helpers.Modals;
using System.Collections.Generic;

/// <summary>
/// An implementation of <see cref="IModalPersistenceHelper"/> which uses Umbraco's <see cref="AppCaches.RequestCache"/>.
/// </summary>
/// <param name="appCaches">The app caches.</param>
internal sealed class UmbracoModalPersistenceHelper(AppCaches appCaches)  : IModalPersistenceHelper 
{
    private const string CacheKeyPrefix = "RhythmDrop__Modal__";

    private readonly IRequestCache _requestCache = appCaches.RequestCache;

    /// <inheritdoc/>
    public IReadOnlyCollection<IModal> GetAll()
    {
        var cachedItems = _requestCache.GetCacheItemsByKeySearch<IModal>(CacheKeyPrefix);

        return cachedItems.WhereNotNull().ToArray();
    }

    /// <inheritdoc/>
    public void Persist(IModal modal)
    {
        var cacheKey = $"{CacheKeyPrefix}_{modal.UniqueKey}";
        _requestCache.GetCacheItem(cacheKey, () => modal);
    }
}