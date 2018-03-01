using AutoMapper;
using Football.Domain.Dtos;
using Football.Domain.Services;
using Football.Infrastructure.Services.Facades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Football.Infrastructure.Services
{
    public class CompetitionService : ICompetitionService
    {
        public CompetitionService(
            IMapper mapper,
            FootballFacadeService footballFacadeService
        )
        {
            this.Mapper = mapper;
            this.FootballFacadeService = footballFacadeService;
        }

        public IMapper Mapper { get; }
        public FootballFacadeService FootballFacadeService { get; }

        public async Task<ICollection<CompetitionDto>> GetCompetitions()
        {
            var competitions = await this.FootballFacadeService.GetCompetitions();

            var dto = this.Mapper.Map<ICollection<CompetitionDto>>(competitions);

            return dto;
        }
    }
}
