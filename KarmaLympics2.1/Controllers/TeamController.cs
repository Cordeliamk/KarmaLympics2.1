using KarmaLympics2._1.Interfaces;
using KarmaLympics2._1.Models;
using Microsoft.AspNetCore.Mvc;




namespace KarmaLympics2._1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamRepository _teamRepository;

        public TeamController(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Team>))]
        public IActionResult GetTeams()
        {
            var teams = _teamRepository.GetTeams();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(teams);
        }

        [HttpGet("teamId")]
        [ProducesResponseType(200, Type = typeof(Team))]
        [ProducesResponseType(400)]
        public IActionResult GetTeam(int teamId)
        {
            if(!_teamRepository.teamExists(teamId))
                return NotFound();

            Team team = _teamRepository.GetTeam(teamId);
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(team);
        }

        [HttpGet("{TeamId}/teamScore")]
        [ProducesResponseType(200, Type = typeof(Team))]
        [ProducesResponseType(400)]
        public IActionResult GetTeamScore(int teamId)
        {
            if (!_teamRepository.teamExists(teamId))
                return NotFound();

            int teamScore = _teamRepository.GetTeamScore(teamId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(teamScore);

        }


    }
}
