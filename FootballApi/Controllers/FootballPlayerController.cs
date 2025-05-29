using FootballApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FootballApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FootballPlayerController : ControllerBase
    {
        static private List<FootballPlayer> players = new List<FootballPlayer>
        {
            new FootballPlayer
            {
                Id = 1,
                FirstName = "Dave",
                LastName = "test",
                Age = 25,
                Team = "Underwood"
            },
            new FootballPlayer
            {
                Id = 2,
                FirstName = "Roger",
                LastName= "Owens",
                Age = 35,
                Team = "Cola"
            },
            new FootballPlayer
            {
                Id = 3,
                FirstName = "Kello",
                LastName = "Dance",
                Age =30,
                Team = "Water"
            }
        };
        [HttpGet]
        public ActionResult<List<FootballPlayer>> GetPlayers()
        {
            return Ok(players);
        }
    }
}
