public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) : base(name, description, points) { }

    public override int RecordEvent()
    {
        DateLastCompleted = DateTime.Now;
        return Points;
    }

    public override string GetDetailsString()
    {
        return $"{GetCompletionStatus()} {Name} ({Description})";
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal:{Name},{Description},{Points},{IsComplete},{DateLastCompleted?.ToString("o")}";
    }
}
