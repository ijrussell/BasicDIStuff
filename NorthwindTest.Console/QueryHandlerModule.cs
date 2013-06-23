using System.Collections.Generic;
using Ninject.Modules;
using NorthwindTest.Domain.Queries;
using NorthwindTest.Domain.QueryHandlers;
using NorthwindTest.Domain.Views;
using NorthwindTest.Infrastructure;

namespace NorthwindTest.Console
{
    public class QueryHandlerModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IQueryHandler<GetArtistsQuery, IEnumerable<ArtistView>>>().To<GetArtistsQueryHandler>().WhenInjectedInto<CachingGetArtistsQueryHandler>();
            Bind<IQueryHandler<GetArtistsQuery, IEnumerable<ArtistView>>>().To<CachingGetArtistsQueryHandler>();
        }
    }
}
