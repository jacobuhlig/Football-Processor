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

        public FileHandler() { }

        public FileHandler(string filePath)
        {
            _file = new FileInfo(filePath);
            leagues = new List<League>(); // Initialize the leagues list
            teams = new List<Team>(); // Initialize the teams list

            try
            {
                _reader = new StreamReader(_file.FullName);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void StartReading()
        {
            List<string> linesOfFile = ReadFile();

            int length = linesOfFile.Count;

            for (int i = 0; i < length; i++)
            {
                List<string> splitLine = ReadFile2(linesOfFile[i]);

                if (splitLine.Count < 4)
                {
                    Team team = new Team(splitLine[0], splitLine[1], splitLine[2]);

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

        public void PrintList()
        {
            try
            {
                List<string> stringList = ReadFile();
                foreach (string item in stringList)
                {
                    Console.WriteLine(item);
                }
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                _reader.Close();
            }
        }

        public List<string> getTeamAbbreviations()
        {
            List<string> foundAbb = new List<string>();

            try
            {
                teams.ForEach(team => foundAbb.Add(team.abbreviation));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return foundAbb;
        }

        public void PrintSimpleStandings(int position)
        {
            try
            {
                Team team = teams[position - 1];

                /* Position in the table, Special marking in parentheses, Full club name */
                Console.WriteLine($"Position in the table           : {position}");
                Console.WriteLine($"Special marking in parentheses  : {team.abbreviation}");
                Console.WriteLine($"Full club name                  : {team.clubname}");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                _reader.Close();
            }
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

        /* public void WriteResults()
        {
            try
            {
                string[] files = Directory.GetFiles("02._csv\\rounds");
                int numberOfFiles = files.Length + 1;

                Console.WriteLine(numberOfFiles);
                _writer = new StreamWriter($"02._csv\\03._results.txt");

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
        } */
    }
}
