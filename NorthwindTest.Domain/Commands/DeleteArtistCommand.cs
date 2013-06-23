using NorthwindTest.Infrastructure;

namespace NorthwindTest.Domain.Commands
{
    public class DeleteArtistCommand : ICommand
    {
        public int ArtistId { get; set; }
    }
}