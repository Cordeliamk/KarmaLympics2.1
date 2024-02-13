using AutoMapper;
using KarmaLympics2._1.Interfaces;
using KarmaLympics2._1.Repository;
using Microsoft.AspNetCore.Mvc;

namespace KarmaLympics2._1.Controllers
{
    public class OccasionController(IOccasionRepository occasionRepository, IMapper mapper) : ControllerBase
    {
        private readonly IOccasionRepository _occasionRepository = occasionRepository;
        private readonly IMapper _mapper = mapper;


    }
}
