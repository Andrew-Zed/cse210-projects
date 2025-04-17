using System;

public class ProgressiveGoal : Goal
{
    private int _currentValue;
    private int _targetValue;
    private int _pointsPerUnit;

    public ProgressiveGoal(string name, string description, int pointsPerUnit, int targetValue) 
        : base(name, description, 0) // Base points are calculated dynamically
    {
        _currentValue = 0;
        _targetValue = targetValue;
        _pointsPerUnit = pointsPerUnit;
    }

    // Constructor for loading from file
    public ProgressiveGoal(string name, string description, int pointsPerUnit, int targetValue, int currentValue) 
        : base(name, description, 0) // Base points are calculated dynamically
    {
        _currentValue = currentValue;
        _targetValue = targetValue;
        _pointsPerUnit = pointsPerUnit;
    }

    public override int RecordEvent()
    {
        Console.Write($"How much progress would you like to record for {_shortName}? ");
        int progress = int.Parse(Console.ReadLine());
        
        // Validate the progress
        if (progress <= 0)
        {
            Console.WriteLine("Progress must be greater than 0.");
            return 0;
        }
        
        // Calculate the new value, but don't exceed the target
        int newValue = _currentValue + progress;
        if (newValue > _targetValue)
        {
            progress = _targetValue - _currentValue;
            newValue = _targetValue;
        }
        
        // Update the current value
        _currentValue = newValue;
        
        // Calculate points earned
        int pointsEarned = progress * _pointsPerUnit;
        
        // Add bonus if goal is now complete
        if (IsComplete() && _currentValue == _targetValue)
        {
            int bonus = _pointsPerUnit * 5; // Bonus for completing
            Console.WriteLine($"You completed the progressive goal! Bonus: {bonus} points!");
            pointsEarned += bonus;
        }
        
        return pointsEarned;
    }

    public override bool IsComplete()
    {
        return _currentValue >= _targetValue;
    }

    public override string GetDetailsString()
    {
        string checkBox = IsComplete() ? "[X]" : "[ ]";
        double percentComplete = (double)_currentValue / _targetValue * 100;
        return $"{checkBox} {_shortName}: {_description} -- Progress: {_currentValue}/{_targetValue} ({percentComplete:F1}%)";
    }

    public override string GetStringRepresentation()
    {
        return $"ProgressiveGoal:{_shortName},{_description},{_pointsPerUnit},{_targetValue},{_currentValue}";
    }
}