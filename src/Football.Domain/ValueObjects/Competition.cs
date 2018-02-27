using System;

namespace Football.Domain.ValueObjects
{
    public class Competition
    {
        public int Id { get; set; }
        public string Caption { get; set; }
        public string League { get; set; }
        public string Year { get; set; }
        public int CurrentMatchday { get; set; }
        public int NumberOfMatchdays { get; set; }
        public int NumberOfTeams { get; set; }
        public int NumberOfGames { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
