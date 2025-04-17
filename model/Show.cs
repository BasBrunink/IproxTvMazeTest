using System.ComponentModel.DataAnnotations;

namespace IproxTvMazeTest.model
{
    public class Show
    {
        [Key]
        public String Id { get; set; }
        public String Name { get; set; }
        public String Language { get; set; }
        public DateOnly Premiered { get; set; }
        public List<String> Genres { get; set; }
        public String Summary { get; set; }
    }
}
