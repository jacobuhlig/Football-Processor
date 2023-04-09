using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Football_Processor
{
    public class FileHandler
    {
        private readonly FileInfo _file;
        private StreamReader? _reader;
        private StreamWriter? _writer;
        private string _splitVar = ",";
        public List<Team> teams { get; set; }
        public List<League> leagues { get; set; }

        public FileHandler()
        {
        }

        public FileHandler(string filePath)
        {
            _file = new FileInfo(filePath);
            leagues = new List<League>(); // Initialize the leagues list
            teams = new List<Team>(); // Initialize the teams list

            try
            {
                Console.WriteLine("Got to try");
                Console.WriteLine(filePath);
                Console.WriteLine(_file.FullName);

                _reader = new StreamReader(_file.FullName);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void StartReading()
        {
            List<string> lineOfFile = ReadFile();
            Console.WriteLine(
                "Start() - lineOfFile.Count: "
                    + lineOfFile.Count
                    + " - lineOfFile[0]: "
                    + lineOfFile[0]
            );
            int length = lineOfFile.Count;

            for (int i = 0; i < length; i++)
            {
                List<string> splitLine = ReadFile2(lineOfFile[i]);

                if (splitLine.Count < 4)
                {
                    Team team = new Team(splitLine[0], splitLine[1], splitLine[2]);

                    Console.WriteLine(team.abbreviation + " " + team.clubname + " " + team.ranking);
                    try
                    {
                        teams.Add(team);
                    }
                    catch (NullReferenceException e)
                    {
                        Console.WriteLine("a" + e.Message);
                    }
                }
                else
                {
                    League league = new League(
                        splitLine[0],
                        splitLine[1],
                        splitLine[2],
                        splitLine[3],
                        splitLine[4],
                        splitLine[5]
                    );

                    Console.WriteLine(league.leagueName + " " + league.nopChampions);
                    try
                    {
                        leagues.Add(league);
                    }
                    catch (NullReferenceException e)
                    {
                        Console.WriteLine("b" + e.Message);
                    }
                }
            }
        }

        public List<string> ReadFile()
        {
            List<string> returnValue = new List<string>();

            try
            {
                string line;
                string header = _reader.ReadLine();
                while ((line = _reader.ReadLine()) != null)
                {
                    returnValue.Add(line);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                _reader.Close();
            }

            return returnValue;
        }

        public List<string> ReadFile2(string lineOfFile)
        {
            try
            {
                string[] splitLine = lineOfFile.Split(_splitVar);
                return splitLine.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public List<string> getTeamAbbreviations()
        {
            List<string> foundAbb = new List<string>();

            try
            {

                using (StreamReader _SR = new StreamReader("02._csv\\02._teams.csv"))
                    while (!_SR.EndOfStream)
                    {
                        var lines = _SR.ReadLine().Split(',');
                        foundAbb.Add(lines.First());
                    }


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
            return foundAbb;
        }

        public void WriteFile(Round round)
        {
            try
            {
                string[] files = Directory.GetFiles("02._csv\\rounds");
                int numberOfFiles = files.Length + 1;

                Console.WriteLine(numberOfFiles);
                _writer = new StreamWriter($"02._csv\\rounds\\rounds-{numberOfFiles}.csv");


                _writer.WriteLine($"{round.homeTeam},{round.awayTeam},{round.score}");


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                _writer.Close();
            }
        }
    }
}

