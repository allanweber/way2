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
    public class CompetitionServiceTest
    {
        /// <summary>
        /// 
        /// </summary>
        public CompetitionServiceTest()
        {
            ServiceCollectionExtensions.UseStaticRegistration = false;
            var server = new TestServer(new WebHostBuilder().UseStartup<Startup>());

            this.CompetitionService = server.Host.Services.GetService<ICompetitionService>();
        }

        private ICompetitionService CompetitionService { get; }

        /// <summary>
        /// /
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetCompetitionsTest()
        {
            var competitions = await this.CompetitionService.GetCompetitions();

            Assert.True(competitions.Any(), "Deveria retornar competições");
        }
    }
}
