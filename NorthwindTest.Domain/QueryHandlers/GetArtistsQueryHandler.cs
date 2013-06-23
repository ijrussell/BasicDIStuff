using System.Collections.Generic;
using System.Linq;
using NorthwindTest.Domain.Data;
using NorthwindTest.Domain.Queries;
using NorthwindTest.Domain.Views;
using NorthwindTest.Infrastructure;

namespace NorthwindTest.Domain.QueryHandlers
{
    public class GetArtistsQueryHandler : IQueryHandler<GetArtistsQuery, IEnumerable<ArtistView>>
    {
        private readonly IMvcMusicStoreDbContext _context;

        public GetArtistsQueryHandler(IMvcMusicStoreDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ArtistView> Execute(GetArtistsQuery query)
        {
            return (from s in _context.Artists
                    select new ArtistView
                    {
                        ArtistId = s.ArtistId,
                        Name = s.Name
                    }).ToList();
        }
    }
}
