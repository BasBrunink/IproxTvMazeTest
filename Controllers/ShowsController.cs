using IproxTvMazeTest.model;
using Microsoft.AspNetCore.Mvc;

namespace IproxTvMazeTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShowsController : Controller
    {

        private readonly ILogger<ShowsController> _logger;
        private readonly AppDbContext _context;

        public ShowsController(ILogger<ShowsController> logger)
        {
            _logger = logger;
            _context = new AppDbContext();
        }

        //Create
        [HttpPost(Name = "CreateShow")]
        public void CreateShow([FromBody] Show show)
        {
            if (show == null)
            {
                _logger.LogWarning("Show is null");
                return;
            }
            _context.Shows.Add(show);
            _context.SaveChanges();
            _logger.LogInformation("Show with id " + show.Id + " created");
        }


        //Get

        [HttpGet(Name = "GetShows")]
        public List<Show> Get()
        {
            var shows = _context.Shows.ToList();
            _logger.LogInformation(shows.Count + " shows found");
            return shows;
        }
        [HttpGet("{name}")]
        public Show Get(string name)
        {
            Show show = _context.Shows.Where(show => show.Name.Equals(name)).Single();
            if (show == null)
            {
                _logger.LogWarning("Show with name " + name + " not found");
                return null;
            }
            _logger.LogInformation("Show with name " + name + " found");
            return show;
        }

        //Update
        [HttpPut("{id}")]
        public void UpdateShow(string id, [FromBody] Show show)
        {
            Show showToUpdate = _context.Shows.Where(show => show.Id.Equals(id)).Single();
            if (showToUpdate == null)
            {
                _logger.LogWarning("Show with id " + show.Id + " not found");
                return;
            }
            showToUpdate.Name = show.Name;
            showToUpdate.Language = show.Language;
            showToUpdate.Premiered = show.Premiered;
            showToUpdate.Genres = show.Genres;
            showToUpdate.Summary = show.Summary;
            _context.SaveChanges();
        }
        //DELETE
        [HttpDelete("{id}")]
        public void DeleteShow(string id)
        {
            Show showToDelete = _context.Shows.Where(show => show.Id.Equals(id)).Single();
            if (showToDelete == null)
            {
                _logger.LogWarning("Show with id " + id + " not found");
                return;
            }
            _context.Shows.Remove(showToDelete);
            _context.SaveChanges();
        }
    }
}
