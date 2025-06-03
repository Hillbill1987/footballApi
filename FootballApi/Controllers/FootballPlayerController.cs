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

        [HttpGet("{id}")]
        public ActionResult<FootballPlayer> GetPlayerById(int id)
        {
            var player = players.FirstOrDefault(x => x.Id == id);

            if (player == null)
                return NotFound();

            return Ok(player);
        }

        [HttpPost]
        public ActionResult<FootballPlayer> AddPlayer(FootballPlayer player)
        {
            if (player == null)
                return BadRequest();
            players.Add(player);
            return CreatedAtAction(nameof(GetPlayerById), new { id = player.Id }, player);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePlayer(int id, FootballPlayer updatedPlayer)
        {
            var player = players.FirstOrDefault(x => x.Id == id);

            if (player == null)
                return NotFound();
            player.Id = updatedPlayer.Id;
            player.FirstName = updatedPlayer.FirstName;
            player.LastName = updatedPlayer.LastName;
            player.Age = updatedPlayer.Age;
            player.Team = updatedPlayer.Team;

            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeletePLayer(int id)
        {
            var player = players.FirstOrDefault(x => x.Id == id);

            if (player == null)
                return NotFound();

            players.Remove(player);
            return NoContent();
        }
    }
}
