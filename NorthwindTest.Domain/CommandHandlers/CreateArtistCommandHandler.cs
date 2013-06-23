using NorthwindTest.Domain.Commands;
using NorthwindTest.Domain.Data;
using NorthwindTest.Domain.Entities;
using NorthwindTest.Infrastructure;

namespace NorthwindTest.Domain.CommandHandlers
{
    public class CreateArtistCommandHandler : ICommandHandler<CreateArtistCommand>
    {
        private readonly IMvcMusicStoreDbContext _context;

        public CreateArtistCommandHandler(IMvcMusicStoreDbContext context)
        {
            _context = context;
        }

        public void Handle(CreateArtistCommand command)
        {
            var artist = MapFrom(command);

            _context.Artists.Add(artist);
            _context.SaveChanges();
        }

        private Artist MapFrom(CreateArtistCommand command)
        {
            return new Artist
            {
                Name = command.Name
            };
        }
    }
}
