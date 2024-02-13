using AutoMapper;
using KarmaLympics2._1.Dto;
using KarmaLympics2._1.Interfaces;
using KarmaLympics2._1.Models;
using KarmaLympics2._1.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KarmaLympics2._1.Controllers
{
    public class OccasionController(IOccasionRepository occasionRepository, IMapper mapper) : ControllerBase
    {
        private readonly IOccasionRepository _occasionRepository = occasionRepository;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Occasion>))]

        public IActionResult GetOccasion(int occasionId)
        {
            if (!_occasionRepository.OccasionExists(occasionId))
                return NotFound();

            OccasionDto occasion = _mapper.Map<OccasionDto>(_occasionRepository.GetOccasion(occasionId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(occasion);
        }

        [HttpGet("{occasionId}/hostMail")]
        [ProducesResponseType(200, Type = typeof(string))]
        [ProducesResponseType(400)]
        public IActionResult GetOccasionHostMail(int occasionId)
        {
            if (!_occasionRepository.OccasionExists(occasionId))
                return NotFound();

            string hostMail = _occasionRepository.GetOccasionHostMail(occasionId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(hostMail);
        }

        [HttpGet("{occasionId}/OccasionUrl")]
        [ProducesResponseType(200, Type = typeof(string))]
        [ProducesResponseType(400)]
        public IActionResult GetOccasionUrl(int occasionId)
        {
            if (!_occasionRepository.OccasionExists(occasionId))
                return NotFound();

            string occasionUrl = _occasionRepository.GetOccasionHostMail(occasionId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(occasionUrl);
        }
    }
}
