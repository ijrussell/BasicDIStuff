using System.Collections.Generic;
using NorthwindTest.Domain.Views;
using NorthwindTest.Infrastructure;

namespace NorthwindTest.Domain.Queries
{
    public class GetArtistsQuery : IQuery<IEnumerable<ArtistView>>
    {
        public int Top { get; set; }
        public bool DescendingOrder { get; set; }
    }
}
