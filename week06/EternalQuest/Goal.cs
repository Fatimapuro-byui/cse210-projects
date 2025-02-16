using System;
using System.Collections.Generic;
using System.IO;




public abstract class Goal
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Points { get; set; }
    public bool IsComplete { get; set; }
    public DateTime? DateLastCompleted { get; set; } = null; 

    public Goal(string name, string description, int points)
    {
        Name = name;
        Description = description;
        Points = points;
        IsComplete = false;
    }

    public abstract int RecordEvent();
    public abstract string GetDetailsString(); 
    public abstract string GetStringRepresentation(); 
    public virtual string GetCompletionStatus()
    {
        return IsComplete ? "[X]" : "[ ]";
    }
}
