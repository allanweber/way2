using System.Collections.Generic;

namespace Football.Domain.ValueObjects
{
    public class League
    {
        public League()
        {
            this.Standing = new List<Standing>();
        }

        public string LeagueCaption { get; set; }
        public int Matchday { get; set; }
        public IList<Standing> Standing { get; set; }
    }
}
