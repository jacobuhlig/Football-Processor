namespace Football_Processor
{
    using System;
    using System.Text;

    public class UI
    {
        public UI_Elements elm;
        public FileHandler leaguesHandler;
        public FileHandler teamsHandler;
        public FileHandler resultsHandler;
        public bool readIntro;
        public bool introduced;
        public bool isRunning;

        public UI()
        {
            elm = new UI_Elements();

            // Init of leagues
            leaguesHandler = new FileHandler("02._csv\\01._setup.csv");
            leaguesHandler.StartReading();

            // Init of teams
            teamsHandler = new FileHandler("02._csv\\02._teams.csv");
            teamsHandler.StartReading();

            // Init of results
            resultsHandler = new FileHandler("02._csv\\03._results.txt");
        }

        public void Start()
        {
            isRunning = true;
            readIntro = true;
            introduced = false;

            while (isRunning)
            {
                int? parsedInput = GetValidIntInput(() =>
                {
                    PrintMessage(0);
                    PrintMessage(6);
                    PrintMessage(7);
                });

                if (!isRunning)
                {
                    break;
                }

                Console.Clear();

                if (parsedInput != null)
                {
                    ChooseMain(parsedInput.Value);
                }

                Console.Clear();
            }
        }

        public int? GetValidIntInput(Action printMessages)
        {
            int parsedInput;
            bool validInput;
            string input;

            do
            {
                Console.Clear();
                PrintMessage(1);

                if (readIntro)
                {
                    if (!introduced)
                    {
                        Console.WriteLine();
                        PrintMessage(5);
                        introduced = true;
                        readIntro = false;
                    }
                }

                printMessages();

                input = Console.ReadLine()?.Trim();

                if (input == "q")
                {
                    isRunning = false;
                    return null;
                }

                validInput = int.TryParse(input, out parsedInput);
            } while (!validInput);

            return parsedInput;
        }

        public void ChooseMain(int choice)
        {
            switch (choice)
            {
                case 1:
                    PrintMessage(1);
                    PrintMessage(2);
                    PrintMessage(8);
                    resultsHandler.PrintList();
                    break;
                case 2:
                    PrintMessage(1);
                    PrintMessage(3);
                    PrintListOfTeams();
                    Console.ReadLine();
                    break;
                case 3:
                    int? parsedInput = GetValidIntInput(() =>
                    {
                        PrintMessage(4);
                        PrintMessage(0);
                        PrintMessage(6);
                        PrintListOfTeams();
                    });
                    if (parsedInput != null)
                    {
                        bool validInput = false;

                        while (!validInput)
                            if (parsedInput >= 1 && parsedInput <= 12)
                            {
                                ChooseTeam(parsedInput.Value);
                                validInput = true;
                            }
                            else
                            {
                                PrintMessage(9);
                                Console.ReadLine();
                            }
                    }
                    break;
                default:
                    PrintMessage(9);
                    Console.ReadLine();
                    break;
            }
        }

        public void PrintMessage(int input)
        {
            switch (input)
            {
                case 0:
                    Console.WriteLine();
                    break;
                case 1:
                    elm.GetDivider(TextDividerType.Thick, "Football Processor");
                    break;
                case 2:
                    elm.GetDivider(TextDividerType.Double, " Current Standings");
                    Console.WriteLine();
                    break;
                case 11:
                    elm.GetDivider(TextDividerType.Double, " Simple Standings ");
                    Console.WriteLine();
                    break;
                case 3:
                    elm.GetDivider(TextDividerType.Double, "     All Teams    ");
                    Console.WriteLine();
                    break;
                case 4:
                    elm.GetDivider(TextDividerType.Double, "    Select Team   ");
                    break;
                case 5:
                    Console.WriteLine("Welcome to the Football Processor");
                    break;
                case 6:
                    Console.WriteLine("Please select an option:");
                    break;
                case 7:
                    Console.WriteLine("1. Current standings");
                    Console.WriteLine("2. Show all teams");
                    Console.WriteLine("3. Select a team");
                    break;
                case 10:
                    Console.WriteLine("1. Register round");
                    Console.WriteLine("2. Show simple standings");
                    Console.WriteLine("3. Show expanded standings");
                    break;
                case 8:
                    Console.WriteLine("Pos  Team          M W D L GF GA GD P Streak");
                    break;
                case 9:
                    Console.WriteLine("Not an available option. Please try again.");
                    break;
                default:
                    throw new ArgumentException("Invalid input", nameof(input));
            }
        }

        public void ChooseTeam(int input)
        {
            while (isRunning)
            {
                int? parsedInput = GetValidIntInput(() =>
                {
                    PrintMessage(4);
                    PrintMessage(0);
                    PrintMessage(6);
                    PrintMessage(10);
                });

                if (!isRunning)
                {
                    break;
                }

                Console.Clear();

                if (parsedInput != null)
                {
                    TeamOptions(input, parsedInput.Value);
                }

                Console.Clear();
            }
            /* teamsHandler */
            /* Console.WriteLine("Should there be a purpose to selecting a team?");
            Console.WriteLine($"In this case team {input} was selected.");
            Console.WriteLine("Insert code here.");
            Console.ReadLine(); */
        }

        public void TeamOptions(int id, int input)
        {
            switch (input)
            {
                case 1:
                    Console.WriteLine("Register round");
                    break;
                case 2:
                    PrintMessage(1);
                    PrintMessage(11);
                    teamsHandler.PrintSimpleStandings(id);
                    break;
                case 3:
                    Console.WriteLine("Expanded standings");
                    break;
                default:
                    throw new ArgumentException("Invalid input", nameof(input));
            }
        }

        private void PrintListOfTeams()
        {
            StringBuilder teamList = new StringBuilder();
            for (int i = 0; i < teamsHandler.teams.Count; i++)
            {
                teamList.AppendLine($"{i + 1}. {teamsHandler.teams[i].clubname}");
            }
            Console.WriteLine(teamList.ToString());
        }
    }
}