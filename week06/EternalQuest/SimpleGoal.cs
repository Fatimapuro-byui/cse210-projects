public class SimpleGoal : Goal
{
    public SimpleGoal(string name, string description, int points) : base(name, description, points) { }

    public override int RecordEvent()
    {
        if (!IsComplete)
        {
            IsComplete = true;
            DateLastCompleted = DateTime.Now;
            return Points;
        }
        return 0; 
    }

    public override string GetDetailsString()
    {
        return $"{GetCompletionStatus()} {Name} ({Description})";
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{Name},{Description},{Points},{IsComplete},{DateLastCompleted?.ToString("o")}";
    }
}
