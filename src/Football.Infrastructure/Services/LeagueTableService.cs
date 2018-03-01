using AutoMapper;
using Football.Domain.Dtos;
using Football.Domain.Services;
using Football.Infrastructure.Services.Facades;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Football.Infrastructure.Services
{
    public class LeagueTableService : ILeagueTableService
    {
        public LeagueTableService(
            IMapper mapper,
            FootballFacadeService footballFacadeService
        )
        {
            this.Mapper = mapper;
            this.FootballFacadeService = footballFacadeService;
        }

        public IMapper Mapper { get; }
        public FootballFacadeService FootballFacadeService { get; }

        public async Task<ICollection<TeamStandingDto>> GetLeagueTableByCompetition(int competitionId)
        {
            var league = await this.FootballFacadeService.GetLeague(competitionId);

            if(league != null && league.Standing.Count > 0)
            {
                var standings = this.Mapper.Map<ICollection<TeamStandingDto>>(league.Standing);
                return standings;
            }

            return null;
        }
    }
}
