namespace Football_Processor
{
    public class Team
    {
        public string abbreviation { get; set; }
        public string clubname { get; set; }
        public string ranking { get; set; }
        public League league { get; set; }

        // Special attribute (not in constructor)
        // nog = number of games
        public int gamesPlayed { get; set; }
        public int nogWon { get; set; }
        public int nogDrawn { get; set; }
        public int nogLost { get; set; }

        // ????
        public int goalsFor { get; set; }
        public int goalsAgainst { get; set; }
        public int goalDifference { get; set; }
        public int pointsAchieved { get; set; }
        public int winningStreak { get; set; }

        public Team(string abbreviation, string clubname, string ranking)
        {
            this.abbreviation = abbreviation;
            this.clubname = clubname;
            this.ranking = ranking;
            this.league = new League("test", "test", "test", "test", "test", "test");
        }

        public Team(string abbreviation, string clubname, string ranking, League league)
        {
            this.abbreviation = abbreviation;
            this.clubname = clubname;
            this.ranking = ranking;
            this.league = league;
        }
    }
}
