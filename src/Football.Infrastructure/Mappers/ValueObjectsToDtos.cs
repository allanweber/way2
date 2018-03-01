using AutoMapper;
using Football.Domain.Dtos;
using Football.Domain.ValueObjects;

namespace Football.Infrastructure.Mappers
{
    public class ValueObjectsToDtos: Profile
    {
        public ValueObjectsToDtos()
        {
            this.CreateMap<Competition, CompetitionDto>();
            this.CreateMap<Standing, TeamStandingDto>();
        }
    }
}
