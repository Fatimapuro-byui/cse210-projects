public class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity()
    {
        Name = "Breathing";
        Description = "This activity guides you through slow, mindful breathing to help you relax. Focus on each inhale and exhale, clearing your thoughts.";
    }

    public override void PerformActivity()
    {
        for (int i = 0; i < Duration; i += 2)
        {
            Console.WriteLine("Inhale...");
            System.Threading.Thread.Sleep(3000); 
            Console.WriteLine("Exhale...");
            System.Threading.Thread.Sleep(3000); 
        }
    }
}
