using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Football.Middlewares
{
    /// <summary>
    /// Tratamento de erro para api
    /// </summary>
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="next"></param>
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;

            var errorResult = new GlobalExceptionResult(exception.Message);
            errorResult.SetDevelopmentDetails(exception.Message, exception.StackTrace, exception.ToString());

            var result = JsonConvert.SerializeObject(errorResult);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}
