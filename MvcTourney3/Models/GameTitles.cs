namespace MvcTourney3.Models
{
    public class GameTitles
    {
        public int Id
        {
            get; set;
        }
        public string? Title
        {
            get; set;
        }
        public List<Matches> Matches
        {
            get; set;
        }
    }
}