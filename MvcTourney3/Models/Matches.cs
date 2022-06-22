namespace MvcTourney3.Models
{
    public class Matches
    {
        public int Id { get; set; }

        public int Team1Id { get; set; }
        public Team Team1 { get; set; }
        public int Team2Id { get; set; }
        public Team Team2 { get; set; }
        public string Result { get; set; }
        public int Team1W
        {
            get; set;
        }
        public int Team2W
        {
            get; set;
        }
    }
}
