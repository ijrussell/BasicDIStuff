using System.Collections.Generic;
using NorthwindTest.Domain.Queries;
using NorthwindTest.Domain.Views;
using NorthwindTest.Infrastructure;

namespace NorthwindTest.Domain.QueryHandlers
{
    public class CachingGetArtistsQueryHandler : IQueryHandler<GetArtistsQuery, IEnumerable<ArtistView>>
    {
        private readonly IQueryHandler<GetArtistsQuery, IEnumerable<ArtistView>> _queryHandler;
        private readonly ICacheService _cache;

        public CachingGetArtistsQueryHandler(IQueryHandler<GetArtistsQuery, IEnumerable<ArtistView>> queryHandler, ICacheService cache)
        {
            _queryHandler = queryHandler;
            _cache = cache;
        }

        public IEnumerable<ArtistView> Execute(GetArtistsQuery query)
        {
            if (!_cache.Exists("artists"))
            {
                var artists = _queryHandler.Execute(query);

                return _cache.Add("artists", artists);
            }

            return _cache.Get<IEnumerable<ArtistView>>("artists");
        }
    }
}
