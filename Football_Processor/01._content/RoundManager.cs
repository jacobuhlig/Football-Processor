namespace Football_Processor
{
    struct Match
    {
        //hometeam
        public string hTeam { get; set; }
        //awayteam
        public string aTeam { get; set; }

        public int hGoals { get; set; }
        public int aGoals { get; set; }

        public Match(string home, string away, int homeGoals, int awayGoals)
        {
            this.hTeam = home;
            this.aTeam = away;
            this.hGoals = homeGoals;
            this.aGoals = awayGoals;
        }
    }

    public class RoundManager
    {


        public void InitRounds()
        {
            /*
            This should emulate the rounds that are to take place between the different teams
            The filehandling should also be handled from here as well.
            */
            FileHandler fh = new FileHandler();

            //List<string> teams = fh.getTeamAbbreviations();
            List<string> teams = new List<string> { "VBK", "SIF", "AAB", "NFC", "FCN", "FCK", "FA", "BIF", "LBK", "FCM", "ACH", "AGF" };

            for (int round = 1; round <= 22; round++)
            {
                var matches = GenerateRound(teams, round);
                SaveMatchesToCSV(matches, $"02._csv\\01._rounds\\round-{round}.csv");
            }



        }

        public void runRound(List<Team> teams)
        {

        }

        private static List<Match> GenerateRound(List<string> teams, int round)
        {
            int numTeams = teams.Count;
            var matches = new List<Match>();

            // Rotate the list of teams, keeping the first team fixed
            var rotatedTeams = new List<string> { teams[0] };
            rotatedTeams.AddRange(teams.Skip((round - 1) % (numTeams - 1)).Take(numTeams - 1));
            rotatedTeams.AddRange(teams.Skip(1).Take((round - 1) % (numTeams - 1)));

            for (int i = 0; i < numTeams / 2; i++)
            {
                var homeTeam = rotatedTeams[i];
                var awayTeam = rotatedTeams[numTeams - i - 1];

                var match = new Match
                {
                    hTeam = homeTeam,
                    aTeam = awayTeam,
                    hGoals = GenerateGoals(),
                    aGoals = GenerateGoals()
                };

                matches.Add(match);
            }

            return matches;
        }

        private static int GenerateGoals()
        {
            Random random = new Random();
            return random.Next(0, 6); // Random number of goals between 0 and 5
        }

        private static void SaveMatchesToCSV(List<Match> matches, string fileName)
        {
            using (var writer = new StreamWriter(fileName))
            {
                writer.WriteLine("home,away,homeGoals,awayGoals");

                foreach (var match in matches)
                {
                    writer.WriteLine($"{match.hTeam},{match.aTeam},{match.hGoals},{match.aGoals}");
                }
            }
        }





    }
}
