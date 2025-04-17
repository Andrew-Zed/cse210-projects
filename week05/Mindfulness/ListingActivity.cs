using System;

class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts;
    private Queue<string> _promptQueue;
    
    public ListingActivity(ActivityLog activityLog) : base(activityLog)
    {
        _name = "Listing Activity";
        _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
        _activityColor = ConsoleColor.Yellow;
        
        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
        
        // Initialize queue with shuffled prompts
        _promptQueue = new Queue<string>(ShuffleList(_prompts));
    }
    
    private List<T> ShuffleList<T>(List<T> list)
    {
        List<T> shuffledList = new List<T>(list);
        
        // Fisher-Yates shuffle
        Random random = new Random();
        int n = shuffledList.Count;
        
        for (int i = n - 1; i > 0; i--)
        {
            int j = random.Next(0, i + 1);
            T temp = shuffledList[i];
            shuffledList[i] = shuffledList[j];
            shuffledList[j] = temp;
        }
        
        return shuffledList;
    }
    
    public void Run()
    {
        DisplayStartingMessage();
        
        Console.WriteLine("Press ESC at any time to end the activity early.");
        Thread.Sleep(2000);
        
        string prompt = GetNextPrompt();
        
        // Display the prompt with a nice border
        Console.ForegroundColor = _activityColor;
        Console.WriteLine("╔" + new string('═', 50) + "╗");
        
        // Split the prompt to fit within the box width
        string[] words = prompt.Split(' ');
        string currentLine = "";
        foreach (string word in words)
        {
            if (currentLine.Length + word.Length + 1 > 48) // Allow for margins
            {
                Console.WriteLine("║ " + currentLine.PadRight(48) + " ║");
                currentLine = word;
            }
            else
            {
                if (currentLine.Length > 0)
                    currentLine += " ";
                currentLine += word;
            }
        }
        // Print the last line
        if (currentLine.Length > 0)
            Console.WriteLine("║ " + currentLine.PadRight(48) + " ║");
            
        Console.WriteLine("╚" + new string('═', 50) + "╝");
        Console.ResetColor();
        
        Console.Write("\nYou may begin in: ");
        ShowCountDown(5);
        Console.WriteLine();
        
        Console.WriteLine("Start listing items (press Enter after each item):");
        
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);
        
        _count = 0;
        List<string> items = GetListFromUser(endTime);
        
        if (!_earlyExit)
        {
            // Display the items with numbering and highlighting
            Console.WriteLine("\nYou listed the following items:");
            Console.WriteLine("------------------------------");
            
            for (int i = 0; i < items.Count; i++)
            {
                Console.ForegroundColor = _activityColor;
                Console.Write($"{i + 1}. ");
                Console.ResetColor();
                Console.WriteLine(items[i]);
            }
            
            Console.WriteLine($"\nTotal: {items.Count} items!");
        }
        
        DisplayEndingMessage();
    }
    
    public string GetNextPrompt()
    {
        // If queue is empty, refill it with a newly shuffled list
        if (_promptQueue.Count == 0)
        {
            _promptQueue = new Queue<string>(ShuffleList(_prompts));
        }
        
        // Dequeue the next prompt
        return _promptQueue.Dequeue();
    }
    
    public List<string> GetListFromUser(DateTime endTime)
    {
        List<string> items = new List<string>();
        
        // Display a live timer
        DateTime currentTime = DateTime.Now;
        int remainingSeconds = (int)(endTime - currentTime).TotalSeconds;
        int lastSecondDisplayed = remainingSeconds;
        
        Console.WriteLine($"Time remaining: {remainingSeconds} seconds");
        
        while (DateTime.Now < endTime && !_earlyExit)
        {
            // Update timer display every second
            currentTime = DateTime.Now;
            remainingSeconds = (int)(endTime - currentTime).TotalSeconds;
            
            if (remainingSeconds != lastSecondDisplayed)
            {
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                Console.Write($"Time remaining: {remainingSeconds} seconds".PadRight(30));
                Console.SetCursorPosition(0, Console.CursorTop + 1);
                lastSecondDisplayed = remainingSeconds;
            }
            
            // Check for early exit
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Escape)
                {
                    _earlyExit = true;
                    break;
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    // Get input for item
                    Console.Write("> ");
                    string item = Console.ReadLine();
                    
                    if (!string.IsNullOrWhiteSpace(item))
                    {
                        items.Add(item);
                        
                        // Visual feedback
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
                        Console.Write("✓ ");
                        Console.ResetColor();
                        Console.WriteLine(item);
                    }
                }
            }
        }
        
        return items;
    }

}