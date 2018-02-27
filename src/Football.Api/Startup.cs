using AutoMapper;
using Football.Api.Filters;
using Football.Domain.Constants;
using Football.Domain.Services;
using Football.Infrastructure.Services;
using Football.Middlewares;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;

namespace Football
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            Environment = env;
        }

        public IConfiguration Configuration { get; }
        public IHostingEnvironment Environment { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddMvcOptions(setup => setup.Filters.Add<CommandResultFilterAttribute>());

            services.AddAutoMapper();

            services.AddMediatR();

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1",
                new Info
                {
                    Title = "RH",
                    Version = "v1",
                    Description = "RH App",
                    Contact = new Contact
                    {
                        Name = "Allan Cassiano Weber",
                        Url = "https:/github.com/allanweber"
                    }
                });

                var basePath = AppContext.BaseDirectory;
                var xmlPath = Path.Combine(basePath, "RH.xml");
                s.IncludeXmlComments(xmlPath);
            });

            services.AddCors(o => o.AddPolicy(AppConstants.ALLOWALLHEADERS, builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddScoped<IFootballService, ScreeningService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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
