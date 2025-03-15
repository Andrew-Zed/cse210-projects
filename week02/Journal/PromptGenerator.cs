public class PromptGenerator
{
    public List<string> _prompts;

    public PromptGenerator()
    {
        _prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?", 
            "What was something new I learned today?",
            "What am I grateful for today?",
            "What challenge did I overcome today?",
            "What made me laugh today?",
            "What is something I want to remember about today?",
            "How did I help someone else today?",
            "What was the most beautiful thing I saw today?",
            "What did I do today that was out of my comfort zone?",
            "What am I looking forward to tomorrow?",
            "What is something I'm proud of accomplishing today?"
        };

    }

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }

}