using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        // Split the text into words and create Word objects
        string[] wordArray = text.Split(' ');
        foreach (string wordText in wordArray)
        {
            _words.Add(new Word(wordText));
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        // Get a list of words that are not already hidden
        List<Word> visibleWords = _words.Where(w => !w.IsHidden).ToList();

        // If all words are already hidden, return
        if (visibleWords.Count == 0)
        {
            return;
        }

        // Make sure we don't try to hide more words than are available
        numberToHide = Math.Min(numberToHide, visibleWords.Count);

        // Create a random number generator
        Random random = new Random();

        // Hide the specified number of random words
        for (int i = 0; i < numberToHide; i++)
        {
            int index = random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }


    public string GetDisplayText()
    {
        string referenceText = _reference.GetDisplayText();
        
        // Join all the words with spaces
        string scriptureText = string.Join(" ", _words.Select(w => w.GetDisplayText()));
        
        return $"{referenceText}\n{scriptureText}";
    }

    public bool IsCompletelyHidden()
    {
        // Check if all words are hidden
        return _words.All(w => w.IsHidden);
    }


}