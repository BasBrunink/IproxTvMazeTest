
using IproxTvMazeTest.model;
using Newtonsoft.Json;

namespace IproxTvMazeTest.scraper
{
    public class TvMazeScraper
    {
        public async Task<List<Show>> GetShows(DateOnly premiereDate)
        {
            var client = new HttpClient();
            var response = await client.GetAsync("https://api.tvmaze.com/shows");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var shows = JsonConvert.DeserializeObject<List<Show>>(json) ?? new List<Show>();
                var filteredShows = shows.FindAll(x => x.Premiered >= premiereDate);
                return filteredShows;
            }
            else
            {
                throw new Exception("Failed to fetch shows from TVMaze API");
            }
        }
    }
}
