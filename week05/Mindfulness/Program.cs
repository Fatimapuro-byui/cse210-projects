class Program
{
    private static Dictionary<string, int> activityUsage = new Dictionary<string, int>
    {
        { "Breathing", 0 },
        { "Reflection", 0 },
        { "Listing", 0 },
        { "Gratitude Journaling", 0 }
    };

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Choose an activity:");
            Console.WriteLine("1. Breathing");
            Console.WriteLine("2. Reflection");
            Console.WriteLine("3. Listing");
            Console.WriteLine("4. Gratitude Journaling");
            Console.WriteLine("5. View Activity Statistics");
            Console.WriteLine("6. Exit");

            int choice = int.Parse(Console.ReadLine());
            MindfulnessActivity activity = choice switch
            {
                1 => new BreathingActivity(),
                2 => new ReflectionActivity(),
                3 => new ListingActivity(),
                4 => new GratitudeJournalingActivity(),
                5 => null,
                6 => null,
                _ => null
            };

            if (choice == 5)
            {
                ShowActivityStatistics();
                continue;
            }
            else if (activity == null) break;

            activity.Start();
            activity.PerformActivity();
            activity.End();

            activityUsage[activity.Name]++;
        }
    }

    private static void ShowActivityStatistics()
    {
        Console.WriteLine("Activity Usage Statistics:");
        foreach (var entry in activityUsage)
        {
            Console.WriteLine($"{entry.Key}: {entry.Value} times");
        }
   
   
   
  /* 
Exceeding Requirements:
-New Activity:Added GratitudeJournalingActivity to guide users in writing down things they are grateful for.
-Tracking Activity Usage Statistics:A dictionary is used to track the number of times each activity is performed.The program displays these statistics to the user upon request.
-Ensuring All Prompts/Questions Are Used Before Repeating:Implemented mechanisms in ReflectionActivity and ListingActivity to ensure all prompts/questions are used before repeating. 
  */ 
   
   
    }
}
