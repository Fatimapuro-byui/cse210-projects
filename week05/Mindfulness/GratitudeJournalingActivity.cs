public class GratitudeJournalingActivity : MindfulnessActivity
{
    public GratitudeJournalingActivity()
    {
        Name = "Gratitude Journaling";
        Description = "This activity will help you reflect on the things you are grateful for by having you write them down.";
    }

    public override void PerformActivity()
    {
        Console.WriteLine("Start writing down things you are grateful for:");
        DateTime endTime = DateTime.Now.AddSeconds(Duration);
        while (DateTime.Now < endTime)
        {
            string item = Console.ReadLine();
            if (string.IsNullOrEmpty(item)) break;
            Console.WriteLine($"You wrote: {item}");
        }
    }
}
