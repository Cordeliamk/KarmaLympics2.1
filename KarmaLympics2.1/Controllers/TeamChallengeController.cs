using AutoMapper;
using KarmaLympics2._1.Dto;
using KarmaLympics2._1.Interfaces;
using KarmaLympics2._1.Models;
using KarmaLympics2._1.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KarmaLympics2._1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamChallengeController(ITeamChallengeRepository teamChallengeRepository, IMapper mapper) : Controller
    {
        private readonly ITeamChallengeRepository _teamChallengeRepository = teamChallengeRepository;
        private readonly IMapper _mapper = mapper;

        [HttpGet("{cordel} teamAnswers")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<string>))]
        public async Task<IActionResult> GetTeamAnswer(int teamId)
        {
            var teamAnswers = _mapper.Map<TeamChallengeDto>( await _teamChallengeRepository.GetTeamAnswer(teamId));
            if (!ModelState.IsValid)
                return BadRequest();
            return Ok(teamAnswers);
        }

        [HttpGet("{teamId}/teamChallenge/{challengeId}")]
        [ProducesResponseType(200, Type = typeof(TeamChallenge))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetTeamChallenge(int teamId, int challengeId)
        {
            TeamChallengeDto teamChallenge = _mapper.Map<TeamChallengeDto>( await _teamChallengeRepository.GetTeamChallenge(teamId, challengeId));
            if (!ModelState.IsValid)
                return BadRequest();
                return Ok(teamChallenge);
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<TeamChallenge>))]
        public async Task<IActionResult> GetTeamChallenges(int teamId)
        {
            var teamChallenges = _mapper.Map<List<TeamChallengeDto>>( await _teamChallengeRepository.GetTeamChallenges(teamId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(teamChallenges);
        }

        [HttpGet("{teamId}/teamPointsEarned/{challengeId}")]
        [ProducesResponseType(200, Type = typeof(int))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetTeamPointsEarned(int teamId, int challengeId)
        {
            int teamPointsEarned = await _teamChallengeRepository.GetTeamPointsEarned(teamId, challengeId);
            if (!ModelState.IsValid)
                return BadRequest();
            return Ok(teamPointsEarned);
        }

    }
}
