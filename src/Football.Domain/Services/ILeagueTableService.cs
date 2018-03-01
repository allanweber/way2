using Football.Domain.Core.Services;
using Football.Domain.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Football.Domain.Services
{
    public interface ILeagueTableService: IService
    {
        Task<ICollection<TeamStandingDto>> GetLeagueTableByCompetition(int competitionId);
    }
}
