using FootballApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FootballApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FootballTeamController : ControllerBase
    {
        static private List<FootballTeam> Teams = new List<FootballTeam>
        {
            new FootballTeam
            {
                Id = 1,
                Name = "Fc Cola",
                YearFounded = 1987,
                Country = "England",
                Manager = "Mr T"
            },
            new FootballTeam
            {
                Id = 2,
                Name = "RunTime Warriors",
                YearFounded = 1912,
                Country = "Nigeria",
                Manager = "Mr No"
            },
            new FootballTeam
            {
                Id= 3,
                Name = "Shavers head",
                YearFounded = 1956,
                Country = "Scotland",
                Manager = "Mr Yu"
            }

        };
        [HttpGet]
        public ActionResult<List<FootballTeam>> GetTeams()
        {
            return Ok(Teams);
        }
    }
}
