using System;

class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;
    protected ConsoleColor _activityColor;
    protected ActivityLog _activityLog;
    protected bool _earlyExit;
    
    public Activity(ActivityLog activityLog)
    {
        _name = "Activity";
        _description = "This is a base activity.";
        _duration = 0;
        _activityColor = ConsoleColor.White;
        _activityLog = activityLog;
        _earlyExit = false;
    }
    
    public void DisplayStartingMessage()
    {
        Console.Clear();
        
        // Display fancy header
        string header = $"Welcome to the {_name}";
        string border = new string('=', header.Length);
        
        Console.ForegroundColor = _activityColor;
        Console.WriteLine(border);
        Console.WriteLine(header);
        Console.WriteLine(border);
        Console.ResetColor();
        
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        
        _duration = GetValidDuration();
        
        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
    }

    public void DisplayEndingMessage()
    {
        if (_earlyExit)
        {
            Console.WriteLine();
            Console.WriteLine("Activity ended early.");
            return;
        }
        
        // Log the completed activity
        _activityLog.AddRecord(_name, _duration);
        
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Well done!!");
        Console.ResetColor();
        ShowSpinner(3);
        Console.WriteLine();
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name}.");
        ShowSpinner(3);
    }

    public void ShowSpinner(int seconds)
    {
        List<string> spinnerStrings = new List<string> { "⠋", "⠙", "⠹", "⠸", "⠼", "⠴", "⠦", "⠧", "⠇", "⠏" };
        
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);
        
        int i = 0;
        
        Console.ForegroundColor = _activityColor;
        while (DateTime.Now < endTime && !CheckForEarlyExit())
        {
            string s = spinnerStrings[i];
            Console.Write(s);
            Thread.Sleep(80);
            Console.Write("\b \b");
            
            i++;
            if (i >= spinnerStrings.Count)
            {
                i = 0;
            }
        }
        Console.ResetColor();
    }

    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            if (CheckForEarlyExit())
                return;
                
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
            Console.ResetColor();
        }
    }

   protected bool CheckForEarlyExit()
    {
        // Check if Escape key is pressed to exit early
        if (Console.KeyAvailable)
        {
            var key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.Escape)
            {
                _earlyExit = true;
                return true;
            }
        }
        return false;
    }

    protected int GetValidDuration()
    {
        int duration = 0;
        bool validInput = false;
        
        while (!validInput)
        {
            Console.Write("How long, in seconds, would you like for your session? ");
            string input = Console.ReadLine();
            
            if (int.TryParse(input, out duration) && duration > 0)
            {
                validInput = true;
            }
            else
            {
                Console.WriteLine("Please enter a valid positive number of seconds.");
            }
        }
        
        return duration;
    }

    protected void DisplayCustomTimer(int seconds)
    {
        int maxWidth = Console.WindowWidth - 10;
        for (int i = 0; i < seconds; i++)
        {
            if (CheckForEarlyExit())
                return;
                
            int progressBarLength = (int)((float)i / seconds * maxWidth);
            
            Console.Write("[");
            Console.ForegroundColor = _activityColor;
            Console.Write(new string('■', progressBarLength));
            Console.ResetColor();
            Console.Write(new string(' ', maxWidth - progressBarLength));
            Console.Write($"] {i}/{seconds}s");
            Console.SetCursorPosition(0, Console.CursorTop);
            
            Thread.Sleep(1000);
        }
        Console.WriteLine(new string(' ', maxWidth + 10)); // Clear the line
    } 

}