using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Football.Domain.Core.CommandHandlers;
using System.Threading.Tasks;

namespace Football.Api.Filters
{
    public sealed class CommandResultFilterAttribute : ActionFilterAttribute
    {
        public override Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            var objectResult = context.Result as ObjectResult;

            if (objectResult?.Value is FailureResult result && ((FailureResult)objectResult?.Value).IsFailure )
            {
                context.Result = new BadRequestObjectResult(result);
            }

            return base.OnResultExecutionAsync(context, next);

        }
    }
}
