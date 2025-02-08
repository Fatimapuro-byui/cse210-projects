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
        ShowSpinner(3); 
    }

    
    public virtual void End()
    {
        Console.WriteLine("Good job! You have completed the activity.");
        Console.WriteLine($"Activity: {Name}, Duration: {Duration} seconds");
        ShowSpinner(3); 
    }

    
    public abstract void PerformActivity();

    
    protected void ShowSpinner(int duration)
    {
        var spinnerChars = new[] { '/', '-', '\\', '|' };
        var originalX = Console.CursorLeft;
        var originalY = Console.CursorTop;

        for (var i = 0; i < duration * 10; i++)
        {
            Console.SetCursorPosition(originalX, originalY);
            Console.Write(spinnerChars[i % spinnerChars.Length]);
            System.Threading.Thread.Sleep(100);
        }

        Console.SetCursorPosition(originalX, originalY);
        Console.Write(' '); 
    }
}
