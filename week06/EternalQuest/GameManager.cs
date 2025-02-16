public class GameManager
{
    public int Score { get; set; }
    public List<Goal> Goals { get; set; } = new List<Goal>();
    public int Level { get; set; } = 1;

    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.WriteLine("  4. Negative Goal");
        Console.Write("Which type of goal would you like to create? ");

        if (int.TryParse(Console.ReadLine(), out int choice))
        {
            Console.Write("What is the name of your goal? ");
            string name = Console.ReadLine();

            Console.Write("What is a short description of it? ");
            string description = Console.ReadLine();

            Console.Write("What is the amount of points associated with this goal? ");
            if (!int.TryParse(Console.ReadLine(), out int points))
            {
                Console.WriteLine("Invalid points value. Goal creation aborted.");
                return;
            }

            switch (choice)
            {
                case 1:
                    Goals.Add(new SimpleGoal(name, description, points));
                    break;
                case 2:
                    Goals.Add(new EternalGoal(name, description, points));
                    break;
                case 3:
                    Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                    if (!int.TryParse(Console.ReadLine(), out int timesNeeded))
                    {
                        Console.WriteLine("Invalid times needed value. Goal creation aborted.");
                        return;
                    }

                    Console.Write("What is the bonus for accomplishing it that many times? ");
                    if (!int.TryParse(Console.ReadLine(), out int bonusPoints))
                    {
                        Console.WriteLine("Invalid bonus points value. Goal creation aborted.");
                        return;
                    }
                    Goals.Add(new ChecklistGoal(name, description, points, timesNeeded, bonusPoints));
                    break;
                case 4:
                    Goals.Add(new NegativeGoal(name, description, points));
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number.");
        }
    }

    public void RecordEvent()
    {
        if (Goals.Count == 0)
        {
            Console.WriteLine("No goals available. Create some goals first!");
            return;
        }

        Console.WriteLine("The goals are:");
        for (int i = 0; i < Goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {Goals[i].GetDetailsString()}");
        }

        Console.Write("Which goal did you accomplish? ");
        if (int.TryParse(Console.ReadLine(), out int choice))
        {
            if (choice > 0 && choice <= Goals.Count)
            {
                int pointsEarned = Goals[choice - 1].RecordEvent();
                Score += pointsEarned;
                Console.WriteLine($"You earned {pointsEarned} points!");
                CheckLevelUp(); 
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number.");
        }
    }

    public void DisplayGoals()
    {
        Console.WriteLine("Goals:");
        if (Goals.Count == 0)
        {
            Console.WriteLine("No goals created yet.");
        }
        else
        {
            foreach (Goal goal in Goals)
            {
                Console.WriteLine(goal.GetDetailsString());
            }
        }
    }

    public void DisplayScore()
    {
        Console.WriteLine($"Your score is {Score}");
        Console.WriteLine($"You are currently at Level {Level}"); 
    }

    public void SaveGoals()
    {
        Console.Write("Enter the filename to save to: ");
        string filename = Console.ReadLine();

        try
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                writer.WriteLine(Score); 
                foreach (Goal goal in Goals)
                {
                    writer.WriteLine(goal.GetStringRepresentation());
                }
            }
            Console.WriteLine("Goals saved successfully!");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error saving goals: {e.Message}");
        }
    }

    public void LoadGoals()
    {
        Console.Write("Enter the filename to load from: ");
        string filename = Console.ReadLine();

        try
        {
            Goals.Clear(); 
            using (StreamReader reader = new StreamReader(filename))
            {
                if (int.TryParse(reader.ReadLine(), out int score))
                {
                    Score = score;
                }
                else
                {
                    Console.WriteLine("Invalid score in file.");
                    return;
                }

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(':');
                    if (parts.Length > 1)
                    {
                        string[] data = parts[1].Split(',');
                        string type = parts[0];

                        switch (type)
                        {
                            case "SimpleGoal":
                                if (data.Length == 5 && bool.TryParse(data[3], out bool simpleIsComplete))
                                {
                                    SimpleGoal simpleGoal = new SimpleGoal(data[0], data[1], int.Parse(data[2]));
                                    simpleGoal.IsComplete = simpleIsComplete;
                                    
                                    if (DateTime.TryParse(data[4], out DateTime dateLastCompleted))
                                    {
                                        simpleGoal.DateLastCompleted = dateLastCompleted;
                                    }
                                    Goals.Add(simpleGoal);
                                }
                                break;
                            case "EternalGoal":
                                if (data.Length == 5 && bool.TryParse(data[3], out bool eternalIsComplete))
                                {
                                    EternalGoal eternalGoal = new EternalGoal(data[0], data[1], int.Parse(data[2]));
                                    eternalGoal.IsComplete = eternalIsComplete;
                                    
                                    if (DateTime.TryParse(data[4], out DateTime dateLastCompleted))
                                    {
                                        eternalGoal.DateLastCompleted = dateLastCompleted;
                                    }
                                    Goals.Add(eternalGoal);
                                }
                                break;
                            case "ChecklistGoal":
                                if (data.Length == 8 && bool.TryParse(data[3], out bool checklistIsComplete))
                                {
                                    ChecklistGoal checklistGoal = new ChecklistGoal(data[0], data[1], int.Parse(data[2]), int.Parse(data[4]), int.Parse(data[6]));
                                    checklistGoal.IsComplete = checklistIsComplete;
                                    checklistGoal.TimesNeeded = int.Parse(data[4]);
                                    checklistGoal.TimesCompleted = int.Parse(data[5]);
                                    
                                    if (DateTime.TryParse(data[7], out DateTime dateLastCompleted))
                                    {
                                        checklistGoal.DateLastCompleted = dateLastCompleted;
                                    }
                                    Goals.Add(checklistGoal);
                                }
                                break;
                            case "NegativeGoal":
                                if (data.Length == 5 && bool.TryParse(data[3], out bool negativeIsComplete))
                                {
                                    NegativeGoal negativeGoal = new NegativeGoal(data[0], data[1], int.Parse(data[2]));
                                    negativeGoal.IsComplete = negativeIsComplete;
                                    
                                    if (DateTime.TryParse(data[4], out DateTime dateLastCompleted))
                                    {
                                        negativeGoal.DateLastCompleted = dateLastCompleted;
                                    }
                                    Goals.Add(negativeGoal);
                                }
                                break;
                            default:
                                Console.WriteLine($"Unknown goal type: {type}");
                                break;
                        }
                    }
                }
            }
            Console.WriteLine("Goals loaded successfully!");
            CheckLevelUp(); 
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found.");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error loading goals: {e.Message}");
        }
    }
    
    public void CheckLevelUp()
    {
        
        int[] levelThresholds = { 0, 1000, 2500, 5000, 10000 }; 

        
        int newLevel = 1;
        for (int i = 1; i < levelThresholds.Length; i++)
        {
            if (Score >= levelThresholds[i])
            {
                newLevel = i + 1;
            }
            else
            {
                break; 
            }
        }

        
        if (newLevel > Level)
        {
            Console.WriteLine($"Congratulations! You've leveled up to Level {newLevel}!");
            Level = newLevel;
        }
    }
}
