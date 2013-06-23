using Ninject.Modules;
using NorthwindTest.Domain.CommandHandlers;
using NorthwindTest.Domain.Commands;
using NorthwindTest.Infrastructure;

namespace NorthwindTest.Console
{
    public class CommandHandlerModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ICommandHandler<DeleteArtistCommand>>().To<DeleteArtistCommandHandler>();
            Bind<ICommandHandler<CreateArtistCommand>>().To<CreateArtistCommandHandler>();
        }
    }
}
