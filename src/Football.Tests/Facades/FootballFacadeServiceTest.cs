using Football.Infrastructure.Services.Facades;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Football.Tests.Facades
{
    /// <summary>
    /// 
    /// </summary>
    public class FootballFacadeServiceTest
    {
        /// <summary>
        /// 
        /// </summary>
        public FootballFacadeServiceTest()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task TestGetCompetitions()
        {
            FootballFacadeService facade = new FootballFacadeService();

            var competitions = await facade.GetCompetitions();

            Assert.True(competitions.Any(), "Deveria retornar competições");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
