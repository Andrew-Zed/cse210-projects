using System;
using System.Xml.Linq;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Journal Program");

        Journal journal = new Journal();

        PromptGenerator promptGenerator = new PromptGenerator();

        bool running = true;

        while (running)
        {
            Console.WriteLine("\nPlease select one of the following choices");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit the program");
            Console.Write("What will you like to do? ");

            string choice = Console.ReadLine();

            switch(choice)
            {
                case "1":
                    WriteNewEntry(journal, promptGenerator);
                    break;
                case "2":
                    journal.DisplayAll();
                    break;
                case "3":
                    SaveJournal(journal);
                    break;
                case "4":
                    LoadJournal(journal);
                    break;
                case "5":
                    running = false;
                    Console.WriteLine("Thank you for using the Journal Program. GoodBye!");
                    break;
                default:
                    Console.WriteLine("Invalid Choice. Please try again");
                    break;
            }

        }

    }

    static void WriteNewEntry(Journal journal, PromptGenerator promptGenerator)
    {
        string prompt = promptGenerator.GetRandomPrompt();

        Console.WriteLine($"\nPrompt: {prompt}");

        Console.WriteLine("Please write your response (type on a single line):");

        string response = Console.ReadLine();

        string date = DateTime.Now.ToShortDateString();

        Entry entry = new Entry(date, prompt, response);

        journal.AddEntry(entry);
        Console.WriteLine("Entry added successfully!");    
    }

    static void SaveJournal(Journal journal)
    {
        Console.Write("\nEnter the filename to save to: ");
        string filename = Console.ReadLine();
        
        journal.SaveToFile(filename);
    }

    static void LoadJournal(Journal journal)
    {
        Console.Write("\nEnter the filename to load from: ");
        string filename = Console.ReadLine();
        
        if (File.Exists(filename))
        {
            journal.LoadFromFile(filename);
        }
        else
        {
            Console.WriteLine($"File not found: {filename}");
        }
    }

}