using System;

public abstract class Activity
{
    private DateTime _date;
    private int _minutes;

    public DateTime GetDate()
    {
        return _date;
    }

    public void SetDate(DateTime date)
    {
        _date = date;
    }

    public int GetMinutes()
    {
        return _minutes;
    }

    public void SetMinutes(int minutes)
    {
        _minutes = minutes;
    }

    public Activity(DateTime date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public virtual string GetSummary()
    {
        return $"{GetDate().ToString("dd MMM yyyy")} {GetType().Name} ({GetMinutes()} min): " +
               $"Distance {GetDistance():F2} km, Speed: {GetSpeed():F2} kph, Pace: {GetPace():F2} min per km";
    }
}