using System;

public class Activity
{
    private DateTime date;
    private int lengthInMinutes; 

    public Activity(DateTime date, int lengthInMinutes)
    {
        this.date = date;
        this.lengthInMinutes = lengthInMinutes;
    }

    public DateTime Date => date;
    public int LengthInMinutes => lengthInMinutes;

    public virtual double GetDistance()
    {
        return 0; 
    }

    public virtual double GetSpeed()
    {
        return (GetDistance() / lengthInMinutes) * 60; 
    }

    public virtual double GetPace()
    {
        return lengthInMinutes / GetDistance(); 
    }

    public virtual string GetSummary()
    {
        return $"{date.ToShortDateString()} {GetType().Name} ({lengthInMinutes} min) - Distance: {GetDistance():F1} miles, Speed: {GetSpeed():F1} mph, Pace: {GetPace():F1} min per mile";
    }
}
