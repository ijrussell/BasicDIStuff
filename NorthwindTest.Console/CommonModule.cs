using Ninject.Extensions.NamedScope;
using Ninject.Modules;
using NorthwindTest.Domain.Data;
using NorthwindTest.Infrastructure;

namespace NorthwindTest.Console
{
    public class CommonModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IMvcMusicStoreDbContext>().To<MvcMusicStoreDbContext>().InCallScope();
            Bind<ICacheService>().To<MemoryCacheService>().InSingletonScope();
        }
    }
}
