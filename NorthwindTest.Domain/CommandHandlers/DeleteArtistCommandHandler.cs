using NorthwindTest.Domain.Commands;
using NorthwindTest.Domain.Data;
using NorthwindTest.Infrastructure;

namespace NorthwindTest.Domain.CommandHandlers
{
    public class DeleteArtistCommandHandler : ICommandHandler<DeleteArtistCommand>
    {
        private readonly IMvcMusicStoreDbContext _context;

        public DeleteArtistCommandHandler(IMvcMusicStoreDbContext context)
        {
            _context = context;
        }

        public void Handle(DeleteArtistCommand command)
        {
            var artist = _context.Artists.Find(command.ArtistId);
            
            if (artist == null) 
                return;
            
            _context.Artists.Remove(artist);
            _context.SaveChanges();
        }
    }
}
