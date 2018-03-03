using Football.Domain.Constants;
using Football.Domain.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Football.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Produces("application/json")]
    [Route("api/v1/[Controller]")]
    [EnableCors(AppConstants.ALLOWALLHEADERS)]
    public class LeagueTableController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="leagueTableService"></param>
        public LeagueTableController(ILeagueTableService leagueTableService)
        {
            this.LeagueTableService = leagueTableService;
        }

        /// <summary>
        /// 
        /// </summary>
        public ILeagueTableService LeagueTableService { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var leagues = await this.LeagueTableService.GetLeagueTableByCompetition(id);

            return this.Ok(leagues);
        }
    }
}