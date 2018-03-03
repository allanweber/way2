using AutoMapper;
using Football.Domain.Dtos;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Football.Tests.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class LeagueTableControllerTests
    {
        private readonly TestServer server;
        private readonly HttpClient client;

        /// <summary>
        /// 
        /// </summary>
        public LeagueTableControllerTests()
        {
            ServiceCollectionExtensions.UseStaticRegistration = false;
            server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            client = server.CreateClient();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="competitionId"></param>
        /// <returns></returns>
        [Theory]
        [InlineData(444)]
        [InlineData(447)]
        [InlineData(457)]
        public async Task GetLeagueTableTest(int competitionId)
        {
            var response = await client.GetAsync($"api/v1/LeagueTable/{competitionId}");
            response.EnsureSuccessStatusCode();
            Assert.True(response.StatusCode == System.Net.HttpStatusCode.OK, "Status deveria ser 200");

            ICollection<TeamStandingDto> result = JsonConvert.DeserializeObject<ICollection<TeamStandingDto>>
                (response.Content.ReadAsStringAsync().Result);

            Assert.True(result.Any(), "Deveria retornar times");
        }
    }
}
