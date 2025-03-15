using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{

    private List<Entry> _entries;

    public Journal()
    {
        _entries = new List<Entry>();
    }


    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries in the journal.");
            return;
        }

        Console.WriteLine("\n === Journal Entries ====");
        foreach (Entry entry in _entries)
        {
            entry.Display();
            Console.WriteLine();
        }

    }

    public void SaveToFile(string file)
    {
        try
        {
            using (StreamWriter outputFile = new StreamWriter(file))
            {
                foreach (Entry entry in _entries)
                {
                    outputFile.WriteLine($"{entry.GetDate()}~|~{entry.GetPromptText()}~|~{entry.GetPromptText()}");
                }
            }
            Console.WriteLine($"Journal save to {file}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving journal to file: {ex.Message}");
        }
    }

    public void LoadFromFile(string file)
    {
        try
        {
            _entries.Clear();

            string[] lines = File.ReadAllLines(file);

            foreach (string line in lines)
            {
                string[] parts = line.Split("~|~");

                if (parts.Length >= 3)
                {
                    string date = parts[0];
                    string promptText = parts[1];
                    string entryText = parts[2];

                    Entry newEntry = new Entry(date, promptText, entryText);
                    _entries.Add(newEntry);
                }
            }
            Console.WriteLine($"Journal loaded from {file}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading journal from file: {ex.Message}");
        }
    }

}