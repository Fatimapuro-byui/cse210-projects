public class ReflectionActivity : MindfulnessActivity
{
    private static readonly List<string> Prompts = new List<string>
    {
        "Think about a time you were a voice for someone who couldn't speak for themselves.",
        "Reflect on an instance where you protected or supported someone against adversity.",
        "Recall a challenge you overcame through perseverance and determination.",
        "Think about a time you conquered a fear or overcame a major hardship.",
        "Reflect on a moment when you achieved something you initially thought was impossible",
        "Describe a situation where you offered your time or resources to alleviate someone's suffering.",
        "Think about a time you made a positive difference in someone's life through your actions.",
        "Recall a moment when you acted without any expectation of reward or recognition."
    };

    private static readonly List<string> Questions = new List<string>
    {
        "What made this experience significant in your life?",
        "What values or beliefs did this experience reinforce?",
        "What did you gain from this experience that you treasure?",
        "Did this experience feel familiar, or was it something entirely new for you?",
        "What were your first steps in this process?",
        "What were the circumstances that led you to get involved?",
        "What emotions did you experience after the event concluded?",
        "How did you feel once you had achieved your goal or overcome the obstacle?",
        "Did you feel a sense of accomplishment, relief, or something else entirely?",
        "What factors contributed to your success this time that were absent in previous attempts?",
        "What mindset or attitude helped you overcome challenges this time around?",
        "What aspect of this experience brings you the most joy or satisfaction?",
        "What makes this experience particularly special or memorable?",
        "How can you apply the knowledge gained to other areas of your life?",
        " What did you discover about your capabilities or limitations?"
    };

    private List<string> usedPrompts = new List<string>();
    private List<string> usedQuestions = new List<string>();

    public ReflectionActivity()
    {
        Name = "Reflection";
        Description = "This mindful practice focuses on recognizing your past successes in overcoming adversity. Recalling these experiences will empower you to face current challenges with newfound strength and resilience.";
    }

    public override void PerformActivity()
    {
        string prompt = GetRandomItem(Prompts, ref usedPrompts);
        Console.WriteLine(prompt);
        System.Threading.Thread.Sleep(3000); 

        for (int i = 0; i < Duration; i += 10)
        {
            string question = GetRandomItem(Questions, ref usedQuestions);
            Console.WriteLine(question);
            System.Threading.Thread.Sleep(10000); 
        }
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
