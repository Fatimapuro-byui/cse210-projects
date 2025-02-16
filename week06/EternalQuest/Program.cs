class Program
{
    static void Main(string[] args)
    {
        GameManager gameManager = new GameManager();

        string choice = "";
        while (choice != "6")
        {
            Console.WriteLine("\nEternal Quest Program");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. Record Event");
            Console.WriteLine("3. List Goals");
            Console.WriteLine("4. Display Score");
            Console.WriteLine("5. Save Goals");
            Console.WriteLine("6. Load Goals");
            Console.WriteLine("7. Quit");
            Console.Write("Select a choice from the menu: ");

            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    gameManager.CreateGoal();
                    break;
                case "2":
                    gameManager.RecordEvent();
                    break;
                case "3":
                    gameManager.DisplayGoals();
                    break;
                case "4":
                    gameManager.DisplayScore();
                    break;
                case "5":
                    gameManager.SaveGoals();
                    break;
                case "6":
                    gameManager.LoadGoals();
                    break;
                case "7":
                    Console.WriteLine("Exiting program...");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}

// Exceeding Requirements:
// 1. Added a "NegativeGoal" class where you lose points for bad habits.
// 2. Implemented leveling up based on score, displaying the current level.
// 3. Added a "DateLastCompleted" to each goal so the user can see when the last time they worked on the goal was
// 4. Added input validation
