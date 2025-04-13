using System;

class Program
{
    private static ActivityLog _activityLog = new ActivityLog();
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Mindfulness Project.");

        bool quit = false;

        while (!quit)
        {
            Console.Clear();
            DisplayHeader("MINDFULNESS PROGRAM");
            
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("1. Breathing Activity");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("2. Reflection Activity");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("3. Listing Activity");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("4. Visualization Activity");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("5. View Activity Statistics");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("6. Quit");
            Console.ResetColor();
            
            Console.Write("\nSelect a choice from the menu: ");
            
            string input = Console.ReadLine();
            
            switch (input)
            {
                case "1":
                    BreathingActivity breathingActivity = new BreathingActivity(_activityLog);
                    breathingActivity.Run();
                    break;
                case "2":
                    ReflectionActivity reflectionActivity = new ReflectionActivity(_activityLog);
                    reflectionActivity.Run();
                    break;
                case "3":
                    ListingActivity listingActivity = new ListingActivity(_activityLog);
                    listingActivity.Run();
                    break;
                case "4":
                    VisualizationActivity visualizationActivity = new VisualizationActivity(_activityLog);
                    visualizationActivity.Run();
                    break;
                case "5":
                    DisplayStatistics();
                    break;
                case "6":
                    quit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    Thread.Sleep(2000);
                    break;
            }
        }
    }
    
    static void DisplayHeader(string title)
    {
        string border = new string('=', title.Length + 4);
        Console.WriteLine(border);
        Console.WriteLine($"  {title}  ");
        Console.WriteLine(border);
        Console.WriteLine();
    }
    
    static void DisplayStatistics()
    {
        Console.Clear();
        DisplayHeader("ACTIVITY STATISTICS");
        
        var counts = _activityLog.GetActivityCounts();
        var durations = _activityLog.GetTotalDurations();
        
        if (counts.Count == 0)
        {
            Console.WriteLine("No activities have been performed yet.");
        }
        else
        {
            Console.WriteLine("Activity Counts:");
            Console.WriteLine("-----------------");
            foreach (var item in counts)
            {
                Console.WriteLine($"{item.Key}: {item.Value} times");
            }
            
            Console.WriteLine("\nTotal Duration (seconds):");
            Console.WriteLine("-----------------");
            foreach (var item in durations)
            {
                int totalMinutes = item.Value / 60;
                int remainingSeconds = item.Value % 60;
                Console.WriteLine($"{item.Key}: {totalMinutes} min, {remainingSeconds} sec");
            }
            
            Console.WriteLine("\nRecent Activities:");
            Console.WriteLine("-----------------");
            foreach (var record in _activityLog.Records.OrderByDescending(r => r.Timestamp).Take(5))
            {
                Console.WriteLine($"{record.Timestamp.ToString("MM/dd/yyyy HH:mm")}: {record.ActivityName} ({record.Duration} seconds)");
            }
        }
        
        Console.WriteLine("\nPress any key to return to the main menu...");
        Console.ReadKey();

    }
}