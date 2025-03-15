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

        Console.WriteLine("\n ==== Journal Entries ====");
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
                    outputFile.WriteLine($"{entry.GetDate()}~|~{entry.GetPromptText()}~|~{entry.GetPromptText()}~|~{entry.GetMood}");
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
                    string mood = parts.Length >= 4 ? parts[3] : "";
                                                     
                    Entry newEntry = new Entry(date, promptText, entryText, mood);
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

    public void DisplaySatistics()
    {
        if(_entries.Count == 0)
        {
            Console.WriteLine("No entries to analze");
            return;
        }
        Console.WriteLine("\n=== Journal Statistics ===");

        Console.WriteLine($"Total Entries: {_entries.Count}");

        DateTime firstDate = DateTime.Parse(_entries.Min(e => e.GetDate()));
        DateTime lastDate = DateTime.Parse(_entries.Max(e => e.GetDate()));
        Console.WriteLine($"Date Range: {firstDate.ToShortDateString()} to {lastDate.ToShortDateString()}");

        int totalWords = _entries.Sum(e => e.GetWordCount());
        Console.WriteLine($"Total Words Written: {totalWords}");

        double avgWords = (double)totalWords / _entries.Count;
        Console.WriteLine($"Average Words Per Entry: {avgWords:F1}");

        var moods = _entries
            .Where(e => !string.IsNullOrWhiteSpace(e.GetMood()))
            .GroupBy(e => e.GetMood().ToLower())
            .OrderByDescending(g => g.Count());

        if(moods.Any())
        {
            Console.WriteLine("\nMood Tracking:");
            foreach (var mood in moods.Take(3))
            {
                Console.WriteLine($"- {mood.Key}: {mood.Count()} entries");
            }
        }

    }
}