using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2024, 12, 15), 45, 5.0),
            new Cycling(new DateTime(2024, 12, 15), 45, 10.0),
            new Swimming(new DateTime(2024, 12, 15), 45, 18)
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
