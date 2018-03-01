using AutoMapper;
using Football.Domain.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Football.Tests.Services
{
    public class CompetitionServiceTest
    {
        public CompetitionServiceTest()
        {
            ServiceCollectionExtensions.UseStaticRegistration = false;
            var server = new TestServer(new WebHostBuilder().UseStartup<Startup>());

            this.CompetitionService = server.Host.Services.GetService<ICompetitionService>();
        }

        public ICompetitionService CompetitionService { get; }

        [Fact]
        public async Task GetCompetitionsTest()
        {
            var competitions = await this.CompetitionService.GetCompetitions();

            Assert.True(competitions.Any(), "Deveria retornar competições");
        }
    }
}
