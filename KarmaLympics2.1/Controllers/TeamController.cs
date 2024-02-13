using AutoMapper;
using KarmaLympics2._1.Dto;
using KarmaLympics2._1.Interfaces;
using KarmaLympics2._1.Models;
using Microsoft.AspNetCore.Mvc;




namespace KarmaLympics2._1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController(ITeamRepository teamRepository, IMapper mapper) : ControllerBase
    {
        private readonly ITeamRepository _teamRepository = teamRepository;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Team>))]
        public IActionResult GetTeams()
        {
            var teams = _mapper.Map<List<TeamDto>>(_teamRepository.GetTeams());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(teams);
        }

        [HttpGet("teamId")]
        [ProducesResponseType(200, Type = typeof(Team))]
        [ProducesResponseType(400)]
        public IActionResult GetTeam(int teamId)
        {
            if(!_teamRepository.TeamExists(teamId))
                return NotFound();

            TeamDto team = _mapper.Map<TeamDto>(_teamRepository.GetTeam(teamId));
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(team);
        }

        [HttpGet("{teamId}/teamScore")]
        [ProducesResponseType(200, Type = typeof(int))]
        [ProducesResponseType(400)]
        public IActionResult GetTeamScore(int teamId)
        {
            if (!_teamRepository.TeamExists(teamId))
                return NotFound();

            int teamScore = _teamRepository.GetTeamScore(teamId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(teamScore);
        }
    }
}
