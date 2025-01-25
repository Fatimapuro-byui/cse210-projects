using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    public Reference Reference { get; private set; }
    public List<Word> Words { get; private set; }

    public Scripture(Reference reference, string text)
    {
        Reference = reference;
        Words = text.Split(' ').Select(word => new Word(word)).ToList();
    }


    public void HideRandomWord()
    {
         
         List<Word> nonHiddenWords = Words.Where(word => !word.IsHidden).ToList();
         if (nonHiddenWords.Count > 0)
            {
              Random random = new Random();
              int index = random.Next(nonHiddenWords.Count);
              nonHiddenWords[index].Hide();
            }

    }


    public bool AllWordsHidden()
    {
        return Words.All(word => word.IsHidden);
    }

    public void Display()
    {
        Console.Write($"{Reference} ");
        foreach (Word word in Words)
        {
            Console.Write(word + " ");
        }
        Console.WriteLine();
    }
}
