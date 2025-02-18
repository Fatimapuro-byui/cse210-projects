public class Swimming : Activity
{
    private int laps; 

    
    public Swimming(DateTime date, int lengthInMinutes, int laps)
        : base(date, lengthInMinutes)
    {
        this.laps = laps;
    }

    
    public override double GetDistance()
    {
        return laps * 50 / 1000.0 * 0.62; 
    }

    public override double GetSpeed()
    {
        return (GetDistance() / LengthInMinutes) * 60; 
    }

    public override double GetPace()
    {
        return LengthInMinutes / GetDistance(); 
    }
}
