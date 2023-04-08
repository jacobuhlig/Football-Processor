using System;
using Football_Processor;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World");

        var teamsHandler = new FileHandler("02._csv\\01._setup.csv");
        teamsHandler.StartReading();
        List<Team> teams1 = teamsHandler.teams;
        teamsHandler.teams.Clear();

        Console.WriteLine("After first init");

        var leaguesHandler = new FileHandler("02._csv\\02._teams.csv");
        leaguesHandler.StartReading();
        List<League> leagues1 = leaguesHandler.leagues;
        teamsHandler.teams.Clear();

        Console.WriteLine("After second init");

        foreach (var team in teams1)
        {
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
