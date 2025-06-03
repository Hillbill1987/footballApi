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
        [HttpGet("{id}")]
        public ActionResult<FootballTeam> GetTeamById(int id)
        {
            var team = Teams.FirstOrDefault(t => t.Id == id);
            if(team == null)
                return NotFound();

            return Ok(team);
        }

        [HttpPost]
        public ActionResult AddTeam(FootballTeam team)
        {
            if (team == null)
                return BadRequest();
            Teams.Add(team);
            return CreatedAtAction(nameof(GetTeamById), new { id = team.Id }, team);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateTeam(int id,FootballTeam updatedteam)
        {
            var team = Teams.FirstOrDefault(t => t.Id == id);
            if (team == null)
                return NotFound();

            team.Id = updatedteam.Id;
            team.Name = updatedteam.Name;
            team.YearFounded = updatedteam.YearFounded;
            team.Country = updatedteam.Country;
            team.Manager = updatedteam.Manager;

            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteTeam(int id)
        {
            var team = Teams.FirstOrDefault(t => t.Id == id);
            if (team == null)
                return NotFound();

            Teams.Remove(team);
            return NoContent();
        }

    }
}
