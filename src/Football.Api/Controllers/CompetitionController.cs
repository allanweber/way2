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
    public class CompetitionController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="competitionService"></param>
        public CompetitionController(ICompetitionService competitionService)
        {
            this.CompetitionService = competitionService;
        }

        /// <summary>
        /// 
        /// </summary>
        public ICompetitionService CompetitionService { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var competitions = await this.CompetitionService.GetCompetitions();
            return Ok(competitions);
        }
    }
}