using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private int _level;
    private List<string> _achievements;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
        _level = 1;
        _achievements = new List<string>();
    }
    
    // Helper method to check for level up and achievements
    private void CheckForLevelUpAndAchievements(int pointsEarned)
    {
        // Level up logic - every 1000 points
        int newLevel = (_score / 1000) + 1;
        if (newLevel > _level)
        {
            Console.WriteLine($"\n*** LEVEL UP! ***");
            Console.WriteLine($"You advanced from Level {_level} to Level {newLevel}!");
            _level = newLevel;
            
            // Add level-based achievements
            if (_level == 5)
            {
                AddAchievement("Dedicated Quester - Reached Level 5");
            }
            else if (_level == 10)
            {
                AddAchievement("Goal Master - Reached Level 10");
            }
        }
        
        // Achievement for first goal completed
        if (pointsEarned > 0 && !_achievements.Contains("First Step - Completed your first goal"))
        {
            AddAchievement("First Step - Completed your first goal");
        }
        
        // Achievement for reaching certain point thresholds
        if (_score >= 5000 && !_achievements.Contains("Milestone - Earned 5000 points"))
        {
            AddAchievement("Milestone - Earned 5000 points");
        }
    }
    
    private void AddAchievement(string achievement)
    {
        if (!_achievements.Contains(achievement))
        {
            _achievements.Add(achievement);
            Console.WriteLine($"\n*** NEW ACHIEVEMENT UNLOCKED! ***");
            Console.WriteLine($"You earned: {achievement}");
        }
    }

    public void Start()
    {
        bool quit = false;
        
        while (!quit)
        {
            Console.WriteLine("\n=== Eternal Quest Menu ===");
            Console.WriteLine($"You have {_score} points.");
            Console.WriteLine($"Current Level: {_level}");
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. View Player Info and Achievements");
            Console.WriteLine("  7. Quit");
            Console.Write("Select a choice from the menu: ");
            
            string choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    DisplayPlayerInfo();
                    break;
                case "7":
                    quit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have {_score} points.");
        Console.WriteLine($"Current Level: {_level}");
        
        if (_achievements.Count > 0)
        {
            Console.WriteLine("Achievements Earned:");
            foreach (string achievement in _achievements)
            {
                Console.WriteLine($"  - {achievement}");
            }
        }
    }

    public void ListGoalNames()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("You have no goals yet!");
            return;
        }
        
        Console.WriteLine("Your goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Goal goal = _goals[i];
            Console.WriteLine($"{i + 1}. {goal.GetName()}");
        }
    }

    public void ListGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("You have no goals yet!");
            return;
        }
        
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Goal goal = _goals[i];
            Console.WriteLine($"{i + 1}. {goal.GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.WriteLine("  4. Progressive Goal");
        Console.Write("Which type of goal would you like to create? ");
        
        string choice = Console.ReadLine();
        
        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        
        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());
        
        Goal goal;
        
        switch (choice)
        {
            case "1":
                goal = new SimpleGoal(name, description, points);
                break;
            case "2":
                goal = new EternalGoal(name, description, points);
                break;
            case "3":
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int target = int.Parse(Console.ReadLine());
                
                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonus = int.Parse(Console.ReadLine());
                
                goal = new ChecklistGoal(name, description, points, target, bonus);
                break;
            case "4":
                Console.Write("What is the target value to reach? ");
                int progressTarget = int.Parse(Console.ReadLine());
                
                Console.Write("How many points for each unit of progress? ");
                int pointsPerUnit = int.Parse(Console.ReadLine());
                
                goal = new ProgressiveGoal(name, description, pointsPerUnit, progressTarget);
                break;
            default:
                Console.WriteLine("Invalid choice. Creating a Simple Goal by default.");
                goal = new SimpleGoal(name, description, points);
                break;
        }
        
        _goals.Add(goal);
        Console.WriteLine("Goal created successfully!");
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("You have no goals yet!");
            return;
        }
        
        Console.WriteLine("The goals are:");
        ListGoalNames();
        
        Console.Write("Which goal did you accomplish? ");
        int goalIndex = int.Parse(Console.ReadLine()) - 1;
        
        if (goalIndex >= 0 && goalIndex < _goals.Count)
        {
            Goal goal = _goals[goalIndex];
            int pointsEarned = goal.RecordEvent();
            _score += pointsEarned;
            
            Console.WriteLine($"Congratulations! You have earned {pointsEarned} points!");
            Console.WriteLine($"You now have {_score} points.");
            
            // Check for level ups and achievements
            CheckForLevelUpAndAchievements(pointsEarned);
        }
        else
        {
            Console.WriteLine("Invalid goal number!");
        }
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();
        
        using (StreamWriter writer = new StreamWriter(filename))
        {
            // First line is the score and level
            writer.WriteLine($"{_score},{_level}");
            
            // Second line contains achievements, separated by |
            writer.WriteLine(string.Join("|", _achievements));
            
            // Then write each goal
            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
        
        Console.WriteLine("Goals saved successfully!");
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();
        
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found!");
            return;
        }
        
        // Clear existing goals
        _goals.Clear();
        
        using (StreamReader reader = new StreamReader(filename))
        {
            // First line is the score and level
            string scoreLine = reader.ReadLine();
            string[] scoreData = scoreLine.Split(',');
            _score = int.Parse(scoreData[0]);
            _level = int.Parse(scoreData[1]);
            
            // Second line contains achievements
            string achievementsLine = reader.ReadLine();
            _achievements = new List<string>();
            if (!string.IsNullOrEmpty(achievementsLine))
            {
                string[] achievements = achievementsLine.Split('|');
                foreach (string achievement in achievements)
                {
                    if (!string.IsNullOrEmpty(achievement))
                    {
                        _achievements.Add(achievement);
                    }
                }
            }
            
            // Read each goal
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(':');
                string goalType = parts[0];
                string goalData = parts[1];
                
                string[] dataParts = goalData.Split(',');
                
                Goal goal = null;
                
                switch (goalType)
                {
                    case "SimpleGoal":
                        goal = new SimpleGoal(
                            dataParts[0], 
                            dataParts[1], 
                            int.Parse(dataParts[2]), 
                            bool.Parse(dataParts[3])
                        );
                        break;
                    case "EternalGoal":
                        goal = new EternalGoal(
                            dataParts[0], 
                            dataParts[1], 
                            int.Parse(dataParts[2])
                        );
                        break;
                    case "ChecklistGoal":
                        goal = new ChecklistGoal(
                            dataParts[0], 
                            dataParts[1], 
                            int.Parse(dataParts[2]), 
                            int.Parse(dataParts[3]), 
                            int.Parse(dataParts[4]), 
                            int.Parse(dataParts[5])
                        );
                        break;
                    case "ProgressiveGoal":
                        goal = new ProgressiveGoal(
                            dataParts[0],
                            dataParts[1],
                            int.Parse(dataParts[2]),
                            int.Parse(dataParts[3]),
                            int.Parse(dataParts[4])
                        );
                        break;
                }
                
                if (goal != null)
                {
                    _goals.Add(goal);
                }
            }
        }
        
        Console.WriteLine("Goals loaded successfully!");
    }
}