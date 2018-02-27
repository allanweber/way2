using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Football.Domain.Constants;
using Football.Domain.Services;
using System.Threading.Tasks;

namespace Football.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/[Controller]")]
    [EnableCors(AppConstants.ALLOWALLHEADERS)]
    public class ScreeningController: Controller
    {
        public ScreeningController(IFootballService screeningService)
        {
            ScreeningService = screeningService;
        }

        public IFootballService ScreeningService { get; }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }
    }
}
