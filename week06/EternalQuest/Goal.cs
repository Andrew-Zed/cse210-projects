using System;

public abstract class Goal
{
    protected string _shortName;
    protected string _description;
    protected int _points;

    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    // Abstract methods that must be implemented by derived classes
    public abstract int RecordEvent();
    public abstract bool IsComplete();
    
    // Virtual method with default implementation
    public virtual string GetDetailsString()
    {
        string checkBox = IsComplete() ? "[X]" : "[ ]";
        return $"{checkBox} {_shortName}: {_description}";
    }

    public string GetName()
{
    return _shortName;
}

    // Abstract method for saving to file
    public abstract string GetStringRepresentation();
}