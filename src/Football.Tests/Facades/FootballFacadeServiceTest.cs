using Football.Infrastructure.Services.Facades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Football.Tests.Facades
{
    public class FootballFacadeServiceTest
    {
        public FootballFacadeServiceTest()
        {

        }

        [Fact]
        public async Task TestGetCompetitions()
        {
            FootballFacadeService facade = new FootballFacadeService();

            var competitions = await facade.GetCompetitions();

            Assert.True(competitions.Any(), "Deveria retornar competições");
        }

        [Theory]
        [InlineData(444)]
        [InlineData(447)]
        [InlineData(457)]
        public async Task TestGetLeague(int id)
        {
            FootballFacadeService facade = new FootballFacadeService();

            var league = await facade.GetLeague(id);

            Assert.True(league.Standing.Any(), "Deveria retornar times");
        }
    }
}
