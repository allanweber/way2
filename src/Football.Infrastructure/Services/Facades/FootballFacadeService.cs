using Football.Domain.ValueObjects;
using Football.Infrastructure.Core;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Football.Infrastructure.Services.Facades
{
    public class FootballFacadeService
    {
        private static IConfigurationRoot Configuration { get; set; }

        private List<KeyValuePair<string, string>> headers = null;

        private readonly string baseUrl = "http://api.football-data.org/v1/";

        private readonly string competitionsPath = "competitions/";

        private readonly string leagueTablePath = "leagueTable/";

        public FootballFacadeService()
        {
            this.ConfigurationBuilder();
            this.headers = new List<KeyValuePair<string, string>>();

            var token = $"{Configuration["Tokens:FootballToken"]}";
            this.headers.Add(new KeyValuePair<string, string>("X-Auth-Token", token));
        }

        private void ConfigurationBuilder()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();
        }

        public async Task<IEnumerable<Competition>> GetCompetitions()
        {
            BaseHttpClient client = new BaseHttpClient(this.baseUrl, this.competitionsPath, this.headers);
            var response = await client.Get();
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return await response.Content.ReadAsAsync<IEnumerable<Competition>>();

            throw new Exception($"Não foi possível retornar as competições: {response.StatusCode} - {response.ReasonPhrase}.");
        }

        public async Task<League> GetLeague(int id)
        {
            BaseHttpClient client = new BaseHttpClient(this.baseUrl, $"{this.competitionsPath}{id}/{this.leagueTablePath}", this.headers);
            var response = await client.Get();
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return await response.Content.ReadAsAsync<League>();

            throw new Exception($"Não foi possível retornar as liga: {response.StatusCode} - {response.ReasonPhrase}.");
        }
    }
}
