using Football.Domain.Constants;
using Football.Domain.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Football.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/[Controller]")]
    [EnableCors(AppConstants.ALLOWALLHEADERS)]
    public class LeagueTableController : Controller
    {
        public LeagueTableController(ILeagueTableService leagueTableService)
        {
            this.LeagueTableService = leagueTableService;
        }

        public ILeagueTableService LeagueTableService { get; }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var leagues = await this.LeagueTableService.GetLeagueTableByCompetition(id);

            return this.Ok(leagues);
        }
    }
}