using NorthwindTest.Infrastructure;

namespace NorthwindTest.Domain.Commands
{
    public class CreateArtistCommand : ICommand
    {
        public int ArtistId { get; set; }
        public string Name { get; set; }
    }
}