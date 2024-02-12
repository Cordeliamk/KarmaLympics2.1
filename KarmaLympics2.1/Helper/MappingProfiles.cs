using AutoMapper;
using KarmaLympics2._1.Dto;
using KarmaLympics2._1.Models;

namespace KarmaLympics2._1.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Team, TeamDto>();
        }
    }
}
