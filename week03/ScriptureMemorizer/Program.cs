using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the ScriptureMemorizer Project.");

        // Create a scripture (you can change this to any scripture you want to memorize)
        Reference reference = new Reference("John ", 3, 16, 17);
        string scriptureText = "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life. For God sent not his Son into the world to condemn the world; but that the world through him might be saved.";
        Scripture scripture = new Scripture(reference, scriptureText);

        // Number of words to hide each time
        int wordsToHideEachTime = 3;

        // Main program loop
        while (!scripture.IsCompletelyHidden())
        {
            // Clear the console and display the scripture
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine("Press Enter to continue or type 'quit' to exit:");
            
            // Get user input
            string input = Console.ReadLine();
            
            // Check if the user wants to quit with the world "quit" or with character "q"
            if (input.ToLower() == "quit" || input.ToLower() == "q")
            {
                break;
            }
            
            // Hide more words
            scripture.HideRandomWords(wordsToHideEachTime);
        }

        // Display the final state (all words hidden) if we didn't quit early
        if (scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine("All words are now hidden. Great job memorizing!");
            Console.WriteLine("Press Enter to exit.");
            Console.ReadLine();
        }

    }
}