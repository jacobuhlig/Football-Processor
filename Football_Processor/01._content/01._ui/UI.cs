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
            bool isRunning = true;

            while (isRunning)
            {
                int input = PromptUser("Football Processor", 1);

                ChooseMain(input);
            }
        }

        public void ChooseMain(int input)
        {
            switch (input)
            {
                case 1:
                    int choice = PromptUser("Choose Team", 2);
                    ChooseTeam(choice);
                    Console.Clear();
                    break;
                case 2:
                    PrintMessage(3);
                    resultsHandler.PrintList();
                    Console.Clear();
                    break;
                case 3:
                    PromptUser("Choose Team", 4);
                    Console.Clear();
                    break;
                default:
                    throw new ArgumentException("Invalid input", nameof(input));
            }
        }

        public void ChooseTeam(int input)
        {
            if (input >= 1 && input <= 12)
            {
                Console.WriteLine("Should there be a purpose to selecting a team?");
                Console.WriteLine($"In this case team {input} was selected.");
                Console.WriteLine("Insert code here.");
                Console.ReadLine();
            }
            else
            {
                throw new ArgumentException("Invalid input", nameof(input));
            }
        }

        public int PromptUser(string header, int message)
        {
            elm.GetDivider(TextDividerType.Basic, header);
            PrintMessage(message);

            return GetInput<int>();
        }

        public T GetInput<T>()
        {
            var input = Console.ReadLine();

            if (!int.TryParse(input, out int result))
            {
                throw new ArgumentException("Input is not a number.");
            }

            Console.Clear();

            return (T)Convert.ChangeType(result, typeof(T));
        }

        public void PrintMessage(int input)
        {
            switch (input)
            {
                case 1:
                    Console.WriteLine("Welcome to the Football Processor");
                    Console.WriteLine("Please select an option:");
                    Console.WriteLine("1. Show/Select a team");
                    Console.WriteLine("2. Current standings");
                    Console.WriteLine("3. Show teams");
                    break;
                case 2:
                    Console.WriteLine("Please select an option:");
                    Console.WriteLine(GenerateListOfTeams());
                    break;
                case 3:
                    Console.WriteLine("Pos  Team          M W D L GF GA GD P Streak");
                    break;
                case 4:
                    Console.WriteLine(GenerateListOfTeams());
                    break;
                default:
                    throw new ArgumentException("Invalid input", nameof(input));
            }
        }

        private string GenerateListOfTeams()
        {
            StringBuilder teamList = new StringBuilder();
            for (int i = 0; i < teamsHandler.teams.Count; i++)
            {
                teamList.AppendLine($"{i + 1}. {teamsHandler.teams[i].clubname}");
            }
            return teamList.ToString();
        }
    }
}
