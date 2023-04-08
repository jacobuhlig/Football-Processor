using System;
using Football_Processor;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World");

        var leaguesHandler = new FileHandler("02._csv\\01._setup.csv");
        leaguesHandler.StartReading();
        List<League> leagues1 = leaguesHandler.leagues;
        /* leaguesHandler.leagues.Clear(); */

        Console.WriteLine("After first init");

        var teamsHandler = new FileHandler("02._csv\\02._teams.csv");
        teamsHandler.StartReading();
        List<Team> teams1 = teamsHandler.teams;
        /* teamsHandler.teams.Clear(); */

        Console.WriteLine("After second init");

        leaguesHandler.WriteFile(new Round("home", "away", "0-0"));

        Console.WriteLine("After first write");

        Console.WriteLine(teams1.ElementAt(0).abbreviation);
        foreach (var team in teams1)
        {
            Console.WriteLine("Got to the forEach");
            Console.WriteLine(team.abbreviation);
        }

        Console.WriteLine("After first writeout");

        foreach (var league in leagues1)
        {
            Console.WriteLine(league.leagueName);
        }

        Console.WriteLine("After second writeout");
    }
}
