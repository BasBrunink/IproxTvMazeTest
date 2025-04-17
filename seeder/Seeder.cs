using IproxTvMazeTest.model;
using IproxTvMazeTest.scraper;
using k8s.Models;

namespace IproxTvMazeTest.seeder
{
    public class Seeder
    {
        private readonly AppDbContext _context;

        public Seeder()
        {
            _context = new AppDbContext();
        }
        public bool SeedShows()
        {
            TvMazeScraper scraper1 = new TvMazeScraper();

            List<Show> shows = scraper1.GetShows(new DateOnly(2014, 01, 01)).Result;
            Console.WriteLine("Got shows");
            Console.WriteLine(shows.Count);
            
            return persistShows(shows);

        }
        private bool persistShows(List<Show> shows)
        {
         
            if (shows.Count == 0 || _context.Shows.Count() == shows.Count)
            {
                Console.WriteLine("No shows to save");
                return false;
            } else
            {
                _context.Shows.AddRange(shows);
                _context.SaveChanges();

                Console.WriteLine("Saved shows");
                return true;
            }
            
          
        }


      
    
        
    }
}
