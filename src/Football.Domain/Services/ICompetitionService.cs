using Football.Domain.Core.Services;
using Football.Domain.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Football.Domain.Services
{
    public interface ICompetitionService: IService
    {
        Task<ICollection<CompetitionDto>> GetCompetitions();
    }
}
