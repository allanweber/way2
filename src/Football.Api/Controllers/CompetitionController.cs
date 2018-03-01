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
    public class CompetitionController : Controller
    {
        public CompetitionController(ICompetitionService competitionService)
        {
            this.CompetitionService = competitionService;
        }

        public ICompetitionService CompetitionService { get; }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var competitions = await this.CompetitionService.GetCompetitions();
            return Ok(competitions);
        }
    }
}