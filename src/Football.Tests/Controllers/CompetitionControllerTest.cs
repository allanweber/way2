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
    public class CompetitionControllerTest
    {
        private readonly TestServer server;
        private readonly HttpClient client;

        public CompetitionControllerTest()
        {
            ServiceCollectionExtensions.UseStaticRegistration = false;
            server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            client = server.CreateClient();
        }

        [Fact]
        public async Task GetCompetitionsTest()
        {
            var response = await client.GetAsync("api/v1/Competition");
            response.EnsureSuccessStatusCode();
            Assert.True(response.StatusCode == System.Net.HttpStatusCode.OK, "Status deveria ser 200");

            ICollection<CompetitionDto> result = JsonConvert.DeserializeObject<ICollection<CompetitionDto>>
                (response.Content.ReadAsStringAsync().Result);

            Assert.True(result.Any(), "Deveria retornar competições");
        }
    }
}
