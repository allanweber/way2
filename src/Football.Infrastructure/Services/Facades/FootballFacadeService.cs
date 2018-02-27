using Football.Domain.ValueObjects;
using Football.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Football.Infrastructure.Services.Facades
{
    public class FootballFacadeService
    {
        private readonly string baseUrl = "http://api.football-data.org/v1/";

        private readonly string competitionsPath = "competitions/";

        private readonly string leagueTablePath = "leagueTable/";

        public async Task<IEnumerable<Competition>> GetCompetitions()
        {
            BaseHttpClient client = new BaseHttpClient(this.baseUrl, this.competitionsPath);
            var response = await client.Get();
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return await response.Content.ReadAsAsync<IEnumerable<Competition>>();

            throw new Exception($"Não foi possível retornar as competições: {response.StatusCode} - {response.ReasonPhrase}.");
        }

        public async Task<League> GetLeague(int id)
        {
            BaseHttpClient client = new BaseHttpClient(this.baseUrl, $"{this.competitionsPath}{id}/{this.leagueTablePath}");
            var response = await client.Get();
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return await response.Content.ReadAsAsync<League>();

            throw new Exception($"Não foi possível retornar as liga: {response.StatusCode} - {response.ReasonPhrase}.");
        }
    }
}
