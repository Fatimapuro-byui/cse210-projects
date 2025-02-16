public class ChecklistGoal : Goal
{
    public int TimesNeeded { get; set; }
    public int TimesCompleted { get; set; }
    public int BonusPoints { get; set; }

    public ChecklistGoal(string name, string description, int points, int timesNeeded, int bonusPoints) : base(name, description, points)
    {
        TimesNeeded = timesNeeded;
        TimesCompleted = 0;
        BonusPoints = bonusPoints;
    }

    public override int RecordEvent()
    {
        if (TimesCompleted < TimesNeeded)
        {
            TimesCompleted++;
            DateLastCompleted = DateTime.Now;

            if (TimesCompleted == TimesNeeded)
            {
                IsComplete = true;
                return Points + BonusPoints;
            }
            return Points;
        }
        return 0; 
    }

    public override string GetDetailsString()
    {
        return $"{GetCompletionStatus()} {Name} ({Description}) -- Completed: {TimesCompleted}/{TimesNeeded}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{Name},{Description},{Points},{IsComplete},{TimesNeeded},{TimesCompleted},{BonusPoints},{DateLastCompleted?.ToString("o")}";
    }
    public override string GetCompletionStatus()
    {
        if (TimesCompleted == TimesNeeded)
        {
            return "[X]";
        }
        return "[ ]";
    }
}
