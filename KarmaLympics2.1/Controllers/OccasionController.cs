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
    public class OccasionController(IOccasionRepository occasionRepository, IMapper mapper) : Controller
    {
        private readonly IOccasionRepository _occasionRepository = occasionRepository;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Occasion>))]

        public async Task<IActionResult> GetOccasion(int occasionId)
        {
            if (!await _occasionRepository.OccasionExists(occasionId))
                return NotFound();

            OccasionDto occasion = _mapper.Map<OccasionDto>(await _occasionRepository.GetOccasion(occasionId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(occasion);
        }

        [HttpGet("{occasionId}/hostMail")]
        [ProducesResponseType(200, Type = typeof(string))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetOccasionHostMail(int occasionId)
        {
            if (!await _occasionRepository.OccasionExists(occasionId))
                return NotFound();

            string hostMail = await _occasionRepository.GetOccasionHostMail(occasionId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(hostMail);
        }

        [HttpGet("{occasionId}/OccasionUrl")]
        [ProducesResponseType(200, Type = typeof(string))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetOccasionUrl(int occasionId)
        {
            if (!await _occasionRepository.OccasionExists(occasionId))
                return NotFound();

            string occasionUrl = await _occasionRepository.GetOccasionUrl(occasionId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(occasionUrl);
        }
       
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateOccasion([FromBody] OccasionDto occasionCreate)
        {
            if (occasionCreate == null)
               return BadRequest(ModelState);

            // Generate a unique URL for the occasion (e.g., using occasion ID)
            Occasion occasionMap = _mapper.Map<Occasion>(occasionCreate);

            if (!await _occasionRepository.CreateOccasion(occasionMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            int occasionId = occasionMap.Id;


            string occasionUrl = await _occasionRepository.GenerateUniqueUrl(occasionId, occasionCreate.OccasionName);


            occasionMap.OccasionUrl = occasionUrl;

            if (!await _occasionRepository.UpdateOccasion(occasionMap))
            {
                ModelState.AddModelError("","Something went wrong while saving");
                return StatusCode(500, ModelState);
            }
            return Ok(new { OccasionUrl = occasionUrl } );
        }
    }
}
