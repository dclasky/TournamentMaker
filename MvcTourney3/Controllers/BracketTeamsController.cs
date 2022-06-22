using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcTourney3.Models;
using MvcTourney3.Data;

namespace MvcTourney3.Controllers
{
    //this controller transforms the teams table into a readable api
    //accessible through localhost:xxxx/api/BracketTeams/getteams
    [Route("api/[controller]")]
    [ApiController]
    public class BracketTeamsController : ControllerBase
    {
        private readonly MvcTourney3Context _context;

        public BracketTeamsController(MvcTourney3Context context)
        {
            _context = context;
        }

        [Route("getteams")]
        public List<Team> GetTeams()
        {
            return _context.Team.ToList();
        }
    }
}
