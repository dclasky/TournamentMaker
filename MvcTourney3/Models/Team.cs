namespace MvcTourney3.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        //THE FOLLOWING IS ESSENTIAL FOR BINDING, WHICH YOU ARE USING
        public int GametitleId
        {
            get; set;
        }
        public GameTitles Gametitle
        {
            get; set;
        }
        public string School { get; set; }

        //THIS IS GONNA BE SIMILAR TO THE OTHER JOINED TABLES BUT A DIFFERENT TAG ON THE HTML SIDE
        public List<Player> Players { get; set; } /*= new List<Player>();*/

    }
}
