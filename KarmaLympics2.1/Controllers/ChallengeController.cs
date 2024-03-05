using AutoMapper;
using KarmaLympics2._1.Dto;
using KarmaLympics2._1.Interfaces;
using KarmaLympics2._1.Models;
using KarmaLympics2._1.Repository;
using Microsoft.AspNetCore.Mvc;


namespace KarmaLympics2._1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChallengeController(IChallengeRepository challengeRepository, IMapper mapper) : Controller
    {
        private readonly IChallengeRepository _challengeRepository = challengeRepository;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Challenge>))]
        public async Task<IActionResult> GetChallenges()
        {
            var challenges = _mapper.Map<List<ChallengeDto>>(await _challengeRepository.GetChallenges());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(challenges);
        }

        [HttpGet("challengeId")]
        [ProducesResponseType(200, Type = typeof(Challenge))]
        [ProducesResponseType(400)]

        public async Task<IActionResult> GetChallenge(int challengeId)
        {
            ChallengeDto challenge = _mapper.Map<ChallengeDto>( await _challengeRepository.GetChallenge(challengeId));
            if (!ModelState.IsValid)
            return BadRequest(ModelState);
            return Ok(challenge);
        }

        [HttpGet("{challengeId}/challengePoints")]
        [ProducesResponseType(200, Type = typeof(int))]
        [ProducesResponseType(400)]

        public async Task<IActionResult> GetChallengePoint(int challengeId)
        {
            if (!await _challengeRepository.ChallengeExists(challengeId))
                return NotFound();

            int challengePoints = await _challengeRepository.GetChallengePoint(challengeId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(challengePoints);
        }


        [HttpPost("{occasionId}/occasionId")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateChallenge(int occasionId, [FromBody] ChallengeDto challengeCreate)
        {
            if (challengeCreate == null)
                return BadRequest(ModelState);
          

            Challenge challengeMap = _mapper.Map<Challenge>(challengeCreate);
            challengeMap.OccasionId = occasionId;

            if (!await _challengeRepository.CreateChallenge(challengeMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully created");
        }
    }
}
