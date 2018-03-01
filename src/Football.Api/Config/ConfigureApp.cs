using Football.Domain.Constants;
using Football.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace Football.Api.Config
{
    public static class ConfigureApp
    {
        public static void ConfigureAppBuilder(this IApplicationBuilder app)
        {
            app.UseMiddleware(typeof(ErrorHandlingMiddleware));

            app.UseMvcWithDefaultRoute();

            app.UseCors(AppConstants.ALLOWALLHEADERS);

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json",
                    "RH");
            });
        }
    }
}
