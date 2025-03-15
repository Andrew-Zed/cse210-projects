using System;
public class Entry
{
    private string _date;

    private string _promptText;

    private string _entryText;

    private string _mood;

    public Entry(string date, string promptText, string entry, string mood = "")
    {
        _date = date;
        _promptText = promptText;
        _entryText = entry;
        _mood = mood;

    }

    public string GetDate()
    {
        return _date;
    }

    public string GetPromptText()
    {
        return _promptText;
    }

    public string GetEntryText()
    {
        return _entryText;
    }

    public string GetMood()
    {
        return _mood;
    }

    public int GetWordCount()
    {
        if(string.IsNullOrWhiteSpace(_entryText))
        {
            return 0;
        }
        else
        {
            return _entryText.Split(new char[] {' ', '\t', '\n', '\r'},
            StringSplitOptions.RemoveEmptyEntries).Length;
        }
    }

    public void Display()
    {
      Console.WriteLine($"Date: {_date}");
      Console.WriteLine($"Prompt: {_promptText}");
      Console.WriteLine($"Entry: {_entryText}");
      if(!string.IsNullOrWhiteSpace(_mood))
      {
        Console.WriteLine($"Mood: {_mood}");
      }
      Console.WriteLine($"Word Count: {GetWordCount} words");
    }

}
