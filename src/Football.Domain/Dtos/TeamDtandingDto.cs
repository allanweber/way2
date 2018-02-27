using System;
using System.Collections.Generic;
using System.Text;

namespace Football.Domain.Dtos
{
    public class TeamDtandingDto
    {
        public int Position { get; set; }
        public string TeamName { get; set; }
        public int Wins { get; set; }
        public int Draws { get; set; }
        public int Losses { get; set; }
        public int Points { get; set; }
    }
}
