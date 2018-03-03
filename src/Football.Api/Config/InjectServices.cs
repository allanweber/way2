using AutoMapper;
using Football.Domain.Constants;
using Football.Domain.Services;
using Football.Infrastructure.Services;
using Football.Infrastructure.Services.Facades;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;

namespace Football.Api.Config
{
    public static class InjectServices
    {
        public static void InjectDepedencies(this IServiceCollection services)
        {
            services.AddMvc();

            services.AddAutoMapper();

            services.AddMediatR();

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1",
                new Info
                {
                    Title = "RH",
                    Version = "v1",
                    Description = "Football App",
                    Contact = new Contact
                    {
                        Name = "Allan Cassiano Weber",
                        Url = "https:/github.com/allanweber"
                    }
                });

                var basePath = AppContext.BaseDirectory;
                var xmlPath = Path.Combine(basePath, "Football.xml");
                s.IncludeXmlComments(xmlPath);
            });

            services.AddCors(o => o.AddPolicy(AppConstants.ALLOWALLHEADERS, builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
        }

        public static void InjectAppDepedencies(this IServiceCollection services)
        {
            services.AddScoped<FootballFacadeService>();
            services.AddScoped<ICompetitionService, CompetitionService>();
            services.AddScoped<ILeagueTableService, LeagueTableService>();
        }
    }
}
