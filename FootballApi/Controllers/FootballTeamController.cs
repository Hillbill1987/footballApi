using FootballApi.Data;
using FootballApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FootballApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FootballTeamController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public FootballTeamController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        [HttpGet]
        public async Task<ActionResult<List<FootballTeam>>> GetTeams()
        {
            return Ok(await _dataContext.teams.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<FootballTeam>> GetTeamById(int id)
        {
            var team = await _dataContext.teams.FindAsync(id);
            if (team == null)
                return NotFound();

            return Ok(team);
        }

        [HttpPost]
        public async Task<ActionResult<FootballTeam>> AddTeam(FootballTeam team)
        {
            if (team == null)
                return BadRequest();
            _dataContext.teams.Add(team);
            await _dataContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTeamById), new { id = team.Id }, team);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeam(int id, FootballTeam updatedteam)
        {
            var team = await _dataContext.teams.FindAsync(id);
            if (team == null)
                return NotFound();

            team.Id = updatedteam.Id;
            team.Name = updatedteam.Name;
            team.YearFounded = updatedteam.YearFounded;
            team.Country = updatedteam.Country;
            team.Manager = updatedteam.Manager;

            await _dataContext.SaveChangesAsync();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            var team = await _dataContext.teams.FindAsync(id);
            if (team == null)
                return NotFound();

            _dataContext.teams.Remove(team);
            await _dataContext.SaveChangesAsync();
            return NoContent();
        }

    }
}
