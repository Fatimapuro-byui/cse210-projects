using System;
using System.Collections.Generic;

public abstract class MindfulnessActivity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Duration { get; set; }

    public virtual void Start()
    {
        Console.WriteLine($"Starting {Name} activity...");
        Console.WriteLine(Description);
        Console.Write("Enter the duration (in seconds): ");
        Duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        System.Threading.Thread.Sleep(3000); 
    }

    public virtual void End()
    {
        Console.WriteLine("Good job! You have completed the activity.");
        Console.WriteLine($"Activity: {Name}, Duration: {Duration} seconds");
        System.Threading.Thread.Sleep(3000);
    }

    public abstract void PerformActivity();
}
