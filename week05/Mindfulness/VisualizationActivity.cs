using System;

class VisualizationActivity : Activity
{

    private List<string> _scenes;
    private List<string> _guidanceSteps;
    private Queue<string> _sceneQueue;
    
    public VisualizationActivity(ActivityLog activityLog) : base(activityLog)
    {
        _name = "Visualization Activity";
        _description = "This activity will help you find peace through guided mental imagery. You'll visualize calming scenes and focus on details to clear your mind.";
        _activityColor = ConsoleColor.Magenta;
        
        _scenes = new List<string>
        {
            "A peaceful beach with gentle waves",
            "A quiet mountain meadow with colorful wildflowers",
            "A serene forest with dappled sunlight",
            "A cozy cabin during a gentle snowfall",
            "A beautiful garden with a bubbling fountain"
        };
        
        _guidanceSteps = new List<string>
        {
            "Notice the colors around you in this scene",
            "Feel the temperature and any sensations on your skin",
            "Listen for the sounds that might be present",
            "Observe any movements or changes in the scene",
            "Breathe deeply and feel yourself becoming part of this place",
            "Notice any scents or smells that might be present",
            "Imagine touching elements in this environment",
            "Find a comfortable spot within this scene to rest",
            "Observe how the light changes and plays across the scene"
        };
        
        // Initialize queue with shuffled scenes
        _sceneQueue = new Queue<string>(ShuffleList(_scenes));
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
        
        string scene = GetNextScene();
        
        // Display the scene with decorative elements
        Console.ForegroundColor = _activityColor;
        Console.WriteLine("~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~");
        Console.WriteLine($"Visualize: {scene}");
        Console.WriteLine("~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~");
        Console.ResetColor();
        
        Console.WriteLine("\nClose your eyes and begin to create this scene in your mind.");
        Console.WriteLine("I'll guide you through the visualization process.");
        
        Console.Write("\nStarting in: ");
        ShowCountDown(5);
        Console.WriteLine();
        
        // Randomly shuffle the guidance steps for this session
        List<string> shuffledGuidance = ShuffleList(_guidanceSteps);
        
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);
        
        int stepIndex = 0;
        while (DateTime.Now < endTime && !_earlyExit)
        {
            // Get the next guidance step, cycling through the list
            string guidance = shuffledGuidance[stepIndex % shuffledGuidance.Count];
            stepIndex++;
            
            // Display with soft transition
            Console.WriteLine();
            Console.ForegroundColor = _activityColor;
            Console.Write("» ");
            Console.ResetColor();
            
            // Display the guidance text character by character for a more calming effect
            foreach (char c in guidance)
            {
                if (CheckForEarlyExit())
                    break;
                    
                Console.Write(c);
                Thread.Sleep(20); // Slow typing effect
            }
            Console.WriteLine();
            
            // Allow time to visualize this aspect
            ShowSpinner(8);
        }
        
        Console.WriteLine("\nSlowly bring your awareness back to the room around you.");
        ShowSpinner(3);
        
        DisplayEndingMessage();
    }
    
    public string GetNextScene()
    {
        // If queue is empty, refill it with a newly shuffled list
        if (_sceneQueue.Count == 0)
        {
            _sceneQueue = new Queue<string>(ShuffleList(_scenes));
        }
        
        // Dequeue the next scene
        return _sceneQueue.Dequeue();
    }
    
}