using Football.Domain.Constants;
using Football.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace Football.Api.Config
{
    /// <summary>
    /// 
    /// </summary>
    public static class ConfigureApp
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        public static void ConfigureAppBuilder(this IApplicationBuilder app)
        {
            app.UseMiddleware(typeof(ErrorHandlingMiddleware));

            app.UseMvcWithDefaultRoute();

            app.UseCors(AppConstants.ALLOWALLHEADERS);

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json",
                    "Football");
            });
        }
    }
}
