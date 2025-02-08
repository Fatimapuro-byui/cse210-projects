public class ListingActivity : MindfulnessActivity
{
    private static readonly List<string> Prompts = new List<string>
    {
        "What skills or abilities do you rely on most?",
        "What are some of your best character traits?",
        "What are your key talents and abilities?",
        "What are you naturally good at doing?",
        "What qualities do you admire in yourself?",
        "In what ways have you been helpful to others recently?",
        "How have you contributed positively to someone else's life this week?",
        "When did you experience a strong feeling of hope or positivity this month?",
        "Who inspires you to be a better person?",
        "Whose actions or achievements do you admire most?"
    };

    private List<string> usedPrompts = new List<string>();

    public ListingActivity()
    {
        Name = "Listing";
        Description = "Explore the richness of your experiences by listing everything you can think of within a chosen area of strength or positivity.";
    }

    public override void PerformActivity()
    {
        string prompt = GetRandomItem(Prompts, ref usedPrompts);
        Console.WriteLine(prompt);
        System.Threading.Thread.Sleep(3000); 
        Console.WriteLine("Start listing items:");

        int count = 0;
        DateTime endTime = DateTime.Now.AddSeconds(Duration);
        while (DateTime.Now < endTime)
        {
            string item = Console.ReadLine();
            if (string.IsNullOrEmpty(item)) break;
            count++;
        }

        Console.WriteLine($"You listed {count} items.");
    }

    private string GetRandomItem(List<string> items, ref List<string> usedItems)
    {
        Random random = new Random();
        if (usedItems.Count == items.Count) usedItems.Clear();
        string item;
        do
        {
            item = items[random.Next(items.Count)];
        } while (usedItems.Contains(item));
        usedItems.Add(item);
        return item;
    }
}
