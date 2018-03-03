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
    /// <summary>
    /// 
    /// </summary>
   public class LeagueTableServiceTests
    {
        /// <summary>
        /// 
        /// </summary>
        public LeagueTableServiceTests()
        {
            ServiceCollectionExtensions.UseStaticRegistration = false;
            var server = new TestServer(new WebHostBuilder().UseStartup<Startup>());

            this.LeagueTableService = server.Host.Services.GetService<ILeagueTableService>();
        }

        /// <summary>
        /// 
        /// </summary>
        public ILeagueTableService  LeagueTableService { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="competitionId"></param>
        /// <returns></returns>
        [Theory]
        [InlineData(444)]
        [InlineData(447)]
        [InlineData(457)]
        public async Task GetLeagueTableByCompetitionTest(int competitionId)
        {
            var competitions = await this.LeagueTableService.GetLeagueTableByCompetition(competitionId);

            Assert.True(competitions.Any(), "Deveria retornar times");
        }
    }
}
