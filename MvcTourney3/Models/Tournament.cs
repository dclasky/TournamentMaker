namespace MvcTourney3.Models
{
    public class Tournament
    {
        public int Id
        {
            get; set;
        }
        public string? Season
        {
            get; set;
        }
        public int? GametitleId
        {
            get; set;
        }
        public GameTitles Gametitle
        {
            get; set;
        }
        public Matches Matches
        {
            get; set;
        }

    }
}