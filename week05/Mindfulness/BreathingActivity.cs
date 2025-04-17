using System;

class BreathingActivity : Activity
{
    public BreathingActivity(ActivityLog activityLog) : base(activityLog)
    {
        _name = "Breathing Activity";
        _description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
        _activityColor = ConsoleColor.Cyan;
    }

    public void Run()
    {
        DisplayStartingMessage();
        
        Console.WriteLine("Press ESC at any time to end the activity early.");
        Thread.Sleep(2000);
        
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);
        
        while (DateTime.Now < endTime && !_earlyExit)
        {
            // Enhanced breathing visualization
            Console.WriteLine();
            Console.Write("Breathe in");
            
            // Growing text for breathing in
            for (int i = 0; i < 10; i++)
            {
                if (CheckForEarlyExit())
                    break;
                    
                // Progressively larger dots
                string dots = new string('.', i + 1);
                Console.Write(dots);
                
                // Adjust speed to start fast and slow down
                int delay = 100 + (i * 30);
                Thread.Sleep(delay);
                
                // Erase dots to replace with more
                Console.Write(new string('\b', dots.Length));
            }
            
            Console.WriteLine();
            Console.Write("Breathe out");
            
            // Shrinking text for breathing out
            for (int i = 10; i > 0; i--)
            {
                if (CheckForEarlyExit())
                    break;
                    
                // Progressively smaller dots
                string dots = new string('.', i);
                Console.Write(dots);
                
                // Adjust speed to start slow and get faster
                int delay = 100 + ((10 - i) * 30);
                Thread.Sleep(delay);
                
                // Erase dots to replace with less
                Console.Write(new string('\b', dots.Length));
            }
            
            Console.WriteLine();
        }
        
        DisplayEndingMessage();
    }

}