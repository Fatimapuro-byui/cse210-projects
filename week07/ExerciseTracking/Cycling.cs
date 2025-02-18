public class Cycling : Activity
{
    private double speed; 

    public Cycling(DateTime date, int lengthInMinutes, double speed)
        : base(date, lengthInMinutes)
    {
        this.speed = speed;
    }

    public override double GetSpeed()
    {
        return speed;
    }

    public override double GetDistance()
    {
        return (speed * LengthInMinutes) / 60; 
    }
}
