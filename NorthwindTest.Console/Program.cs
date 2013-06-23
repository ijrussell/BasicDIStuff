using System;
using Ninject;
using NorthwindTest.Domain.Commands;
using NorthwindTest.Domain.Queries;
using NorthwindTest.Infrastructure;

namespace NorthwindTest.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var kernel = new StandardKernel(new CommonModule(), new CommandHandlerModule(), new QueryHandlerModule());

            try
            {
                var queryService = new QueryService(kernel);
                var commandService = new CommandService(kernel);

                var query = new GetArtistsQuery {Top = 5, DescendingOrder = true};
                
                GetArtists(queryService, query);

                //var cmd = new CreateArtistCommand
                //{
                //    Name = "Tangerine Dream"
                //};
                
                //commandService.ExecuteCommand(cmd);

                //var deleteCmd = new DeleteArtistCommand
                //{
                //    ArtistId = 138
                //};

                //commandService.ExecuteCommand(deleteCmd);

                //GetArtists(queryService, query);



            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            finally
            {
                kernel.Dispose();
            }

            System.Console.ReadLine();
        }

        private static void GetArtists(QueryService queryService, GetArtistsQuery query)
        {
            var artists = queryService.ExecuteQuery(query);

            foreach (var artist in artists)
                System.Console.WriteLine("[{0}] {1}", artist.ArtistId, artist.Name);

            System.Console.WriteLine();
        }
    }
}
