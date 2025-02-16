public class NegativeGoal : Goal
{
    public NegativeGoal(string name, string description, int points) : base(name, description, points) { }

    public override int RecordEvent()
    {
        DateLastCompleted = DateTime.Now;
        return -Points; 
    }

    public override string GetDetailsString()
    {
        return $"{GetCompletionStatus()} {Name} ({Description})";
    }

    public override string GetStringRepresentation()
    {
        return $"NegativeGoal:{Name},{Description},{Points},{IsComplete},{DateLastCompleted?.ToString("o")}";
    }
}
