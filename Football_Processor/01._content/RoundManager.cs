namespace Football_Processor
{
    struct Match
    {
        //hometeam
        public Team hTeam { get; set; }
        //awayteam
        public Team aTeam { get; set; }

        public int hGoals { get; set; }
        public int aGoals { get; set; }

        public Match(Team home, Team away, int homeGoals, int awayGoals)
        {
            this.hTeam = home;
            this.aTeam = away;
            this.hGoals = homeGoals;
            this.aGoals = awayGoals;
        }
    }

    public class RoundManager
    {
        private List<Match> InitRounds(List<Team> teams)
        {
            /*
            This should emulate the rounds that are to take place between the different teams
            The filehandling should also be handled from here as well.
            */
            List<Match> matches = new List<Match>();
            FileHandler fh = new FileHandler();

            fh.getTeamAbbreviations();






            return matches;
        }

        public void runRound(List<Team> teams)
        {

        }





    }
}
