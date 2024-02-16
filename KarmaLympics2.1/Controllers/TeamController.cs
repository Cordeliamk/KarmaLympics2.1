using AutoMapper;
using KarmaLympics2._1.Dto;
using KarmaLympics2._1.Interfaces;
using KarmaLympics2._1.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;




namespace KarmaLympics2._1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController(ITeamRepository teamRepository, IOccasionRepository occasionRepository, IMapper mapper) : Controller
    {
        private readonly ITeamRepository _teamRepository = teamRepository;
        private readonly IOccasionRepository _occasionRepository = occasionRepository;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Team>))]
        public async Task<IActionResult> GetTeams()
        {
            var teams = _mapper.Map<List<TeamDto>>( await _teamRepository.GetTeams());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(teams);
        }

        [HttpGet("teamId")]
        [ProducesResponseType(200, Type = typeof(Team))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetTeam(int teamId)
        {
            if(! await _teamRepository.TeamExists(teamId))
                return NotFound();

            TeamDto team = _mapper.Map<TeamDto>( await _teamRepository.GetTeam(teamId));
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(team);
        }

        [HttpGet("{teamId}/teamScore")]
        [ProducesResponseType(200, Type = typeof(int))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetTeamScore(int teamId)
        {
            if (! await _teamRepository.TeamExists(teamId))
                return NotFound();

            int teamScore = await _teamRepository.GetTeamScore(teamId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(teamScore);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateTeam([FromBody] TeamDto teamCreate, string occasionUrl)
        {
            int occasionId = await _occasionRepository.ExtractOccasionIdFromUrl(occasionUrl);

            Occasion occasion = await _occasionRepository.GetOccasion(occasionId);

            if (teamCreate == null)
                return BadRequest(ModelState);

            ICollection<Team> teams = await _teamRepository.GetTeams();
            Team team = teams
              .Where(t => t.TeamName.Trim().ToUpper() == teamCreate.TeamName.TrimEnd().ToUpper())
              .FirstOrDefault();

            if (team != null)
            {
                ModelState.AddModelError("", "TeamName Already exists");
                return StatusCode(422, ModelState);
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Team teamMap = _mapper.Map<Team>(teamCreate);

            if(! await _teamRepository.CreateTeam(teamMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }
            return Ok("Succesfully Created");
                
        }
    }
}
