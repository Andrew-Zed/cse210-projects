using System;

/*
 * Scripture Memorizer Program
 * 
 * This program helps users memorize scripture passages by progressively hiding random words.
 * 
 * Core requirements implemented:
 * - Scripture storage with reference and text
 * - Support for both single verse and multi-verse references
 * - Proper display of scripture with reference
 * - Word hiding with underscores matching word length
 * - Program termination on "quit" or when all words are hidden
 * - Proper encapsulation with classes in separate files
 * 
 * Stretch Challenges Implemented:
 * 
 * 1. Only hiding words that are not already hidden
 *    The program only hides words that are not already hidden, by filtering
 *    visible words first and then randomly selecting from that filtered list.
 *    This ensures more efficient hiding and a better user experience as new words
 *    are hidden each time rather than potentially selecting already hidden words.
 *    This enhancement is implemented in the Scripture.HideRandomWords method.
 * 
 * 2. Scripture Library with JSON Storage
 *    The program loads multiple scriptures from a JSON file and randomly selects one
 *    for the user to memorize. This allows for variety and reuse without modifying
 *    the code. The JSON structure includes book, chapter, verse range, and text.
 *    A new ScriptureLibrary class handles loading and managing the scripture collection.
 *    
 * 3. User-friendly menu system
 *    Added a main menu that allows users to:
 *    - Get a random scripture to memorize
 *    - View information about the scripture library
 *    - Quit the program
 *    This enhances the user experience and makes the program more interactive.
 */

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Scripture Memorizer Program!");
        Console.WriteLine("==========================================");
        
        // Initialize the scripture library
        // Note: In a real app, we'd use a relative path or app settings
        string jsonFilePath = "Scriptures.json";
        ScriptureLibrary scriptureLibrary = new ScriptureLibrary(jsonFilePath);
        
        bool exitProgram = false;
        
        while (!exitProgram)
        {
            // Display main menu
            Console.Clear();
            Console.WriteLine("SCRIPTURE MEMORIZER - MAIN MENU");
            Console.WriteLine("===============================");
            Console.WriteLine("1. Memorize a random scripture");
            Console.WriteLine("2. View scripture library info");
            Console.WriteLine("3. Exit program");
            Console.WriteLine();
            Console.Write("Select an option (1-3): ");
            
            string choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1":
                    // Get a random scripture and practice memorizing it
                    MemorizeScripture(scriptureLibrary.GetRandomScripture());
                    break;
                    
                case "2":
                    // Show information about the scripture library
                    DisplayLibraryInfo(scriptureLibrary);
                    break;
                    
                case "3":
                    // Exit the program
                    exitProgram = true;
                    Console.WriteLine("Thank you for using the Scripture Memorizer. Goodbye!");
                    break;
                    
                default:
                    Console.WriteLine("Invalid option. Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
        }
    }
    
    static void MemorizeScripture(Scripture scripture)
    {
        // Number of words to hide each time
        int wordsToHideEachTime = 3;

        // Main memorization loop
        while (!scripture.IsCompletelyHidden())
        {
            // Clear the console and display the scripture
            Console.Clear();
            Console.WriteLine("MEMORIZE THE SCRIPTURE");
            Console.WriteLine("======================");
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine("Press Enter to continue, or type 'menu' to return to main menu:");
            
            // Get user input
            string input = Console.ReadLine();
            
            // Check if the user wants to quit
            if (input.ToLower() == "menu")
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
            Console.WriteLine("SCRIPTURE MEMORIZED!");
            Console.WriteLine("===================");
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine("Congratulations! You've memorized the entire scripture!");
            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
        }
    }
    
    static void DisplayLibraryInfo(ScriptureLibrary library)
    {
        Console.Clear();
        Console.WriteLine("SCRIPTURE LIBRARY INFORMATION");
        Console.WriteLine("============================");
        Console.WriteLine($"Total scriptures in library: {library.GetScriptureCount()}");
        Console.WriteLine();
        Console.WriteLine("The scripture library contains various verses from the Bible");
        Console.WriteLine("that are randomly selected for you to memorize.");
        Console.WriteLine();
        Console.WriteLine("Press any key to return to the main menu...");
        Console.ReadKey();
    }
}