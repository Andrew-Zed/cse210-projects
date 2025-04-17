using System;

// Reflection Activity - inherits from Activity
class ReflectionActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;
    private Queue<string> _promptQueue;
    private Queue<string> _questionQueue;

    public ReflectionActivity(ActivityLog activityLog) : base(activityLog)
    {
        _name = "Reflection Activity";
        _description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
        _activityColor = ConsoleColor.Green;
        
        _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };
        
        _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };
        
        // Initialize queues with shuffled lists to ensure all prompts/questions are used
        InitializeQueues();
    }
    
    private void InitializeQueues()
    {
        // Shuffle the prompts and create a queue
        _promptQueue = new Queue<string>(ShuffleList(_prompts));
        
        // Shuffle the questions and create a queue
        _questionQueue = new Queue<string>(ShuffleList(_questions));
    }
    
    private List<T> ShuffleList<T>(List<T> list)
    {
        // Create a new list from the original
        List<T> shuffledList = new List<T>(list);
        
        // Implement Fisher-Yates shuffle
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
        DisplayPrompt(prompt);
        
        Console.WriteLine("Now ponder on each of the following questions as they related to this experience.");
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.WriteLine();
        
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);
        
        while (DateTime.Now < endTime && !_earlyExit)
        {
            string question = GetNextQuestion();
            
            // Display question with color highlighting
            Console.ForegroundColor = _activityColor;
            Console.Write(">> ");
            Console.ResetColor();
            Console.WriteLine(question);
            
            ShowSpinner(10); // Pause for reflection
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
    
    public string GetNextQuestion()
    {
        // If queue is empty, refill it with a newly shuffled list
        if (_questionQueue.Count == 0)
        {
            _questionQueue = new Queue<string>(ShuffleList(_questions));
        }
        
        // Dequeue the next question
        return _questionQueue.Dequeue();
    }
    
    public void DisplayPrompt(string prompt)
    {
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();
        
        // Create a decorated box around the prompt
        string border = new string('*', prompt.Length + 6);
        
        Console.ForegroundColor = _activityColor;
        Console.WriteLine(border);
        Console.WriteLine($"*  {prompt}  *");
        Console.WriteLine(border);
        Console.ResetColor();
        
        Console.WriteLine();
    }

}