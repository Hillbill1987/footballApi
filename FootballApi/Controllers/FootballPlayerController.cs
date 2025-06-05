using FootballApi.Data;
using FootballApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FootballApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FootballPlayerController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public FootballPlayerController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<FootballPlayer>>> GetPlayers()
        {
            return Ok(await _dataContext.players.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FootballPlayer>> GetPlayerById(int id)
        {
            var player = await _dataContext.players.FindAsync(id);

            if (player == null)
                return NotFound();

            return Ok(player);
        }

        [HttpPost]
        public async Task<ActionResult<FootballPlayer>> AddPlayer(FootballPlayer player)
        {
            if (player == null)
                return BadRequest();
            _dataContext.players.Add(player);
            await _dataContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPlayerById), new { id = player.Id }, player);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePlayer(int id, FootballPlayer updatedPlayer)
        {
            var player = await _dataContext.players.FindAsync(id);

            if (player == null)
                return NotFound();
            player.Id = updatedPlayer.Id;
            player.FirstName = updatedPlayer.FirstName;
            player.LastName = updatedPlayer.LastName;
            player.Age = updatedPlayer.Age;
            player.Team = updatedPlayer.Team;

            await _dataContext.SaveChangesAsync();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePLayer(int id)
        {
            var player = await _dataContext.players.FindAsync(id);

            if (player == null)
                return NotFound();

            _dataContext.players.Remove(player);
            await _dataContext.SaveChangesAsync();
            return NoContent();
        }
    }
}
