using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class ScriptureData
{
    public string Book { get; set; }
    public int Chapter { get; set; }
    public int StartVerse { get; set; }
    public int EndVerse { get; set; }
    public string Text { get; set; }
}

public class ScriptureLibraryData
{
    public List<ScriptureData> Scriptures { get; set; }
}

public class ScriptureLibrary
{
    private List<ScriptureData> _scriptures;
    private Random _random;

    public ScriptureLibrary(string jsonFilePath)
    {
        _random = new Random();
        LoadScripturesFromJson(jsonFilePath);
    }

    private void LoadScripturesFromJson(string filePath)
    {
        try
        {
            // Read the JSON file
            string jsonString = File.ReadAllText(filePath);
            
            // Deserialize the JSON into our object structure
            ScriptureLibraryData libraryData = JsonSerializer.Deserialize<ScriptureLibraryData>(jsonString);
            
            // Store the scriptures list
            _scriptures = libraryData.Scriptures;
            
            Console.WriteLine($"Successfully loaded {_scriptures.Count} scriptures from the library.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading scriptures from JSON: {ex.Message}");
            
            // Initialize with an empty list if there's an error
            _scriptures = new List<ScriptureData>();
        }
    }

    public Scripture GetRandomScripture()
    {
        if (_scriptures.Count == 0)
        {
            // If no scriptures are loaded, create a default one
            Reference defaultReference = new Reference("John", 3, 16);
            return new Scripture(defaultReference, "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.");
        }

        // Get a random scripture from the list
        int index = _random.Next(_scriptures.Count);
        ScriptureData scriptureData = _scriptures[index];
        
        // Create a Reference object
        Reference reference = new Reference(
            scriptureData.Book, 
            scriptureData.Chapter, 
            scriptureData.StartVerse, 
            scriptureData.EndVerse
        );
        
        // Create and return a Scripture object
        return new Scripture(reference, scriptureData.Text);
    }

    public int GetScriptureCount()
    {
        return _scriptures.Count;
    }
}