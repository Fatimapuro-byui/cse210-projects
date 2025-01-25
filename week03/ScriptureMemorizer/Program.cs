using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    
    static List<Scripture> _scriptures = new List<Scripture>();

    static void Main(string[] args)
    {
        LoadScripturesFromFile("scriptures.txt");
         Random random = new Random();
        Scripture scripture = _scriptures[random.Next(_scriptures.Count)];

        
        Console.Clear();
        scripture.Display();


        while (!scripture.AllWordsHidden())
        {
             Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit:");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                return;
            }

            scripture.HideRandomWord();

            Console.Clear();
            scripture.Display();
           
        }
        Console.WriteLine("All words hidden. Program completed.");

    }

    
     static void LoadScripturesFromFile(string filename)
    {
          try
        {
             string[] lines = File.ReadAllLines(filename);
            foreach (string line in lines)
            {
                string[] parts = line.Split("|");
                if (parts.Length != 3)
                {
                    Console.WriteLine($"Invalid line format: {line}");
                    continue;
                }

                 string referencePart = parts[0].Trim();
                string text = parts[2].Trim();
                  
                
                string[] referenceParts = referencePart.Split(' ');
                if(referenceParts.Length < 2){
                     Console.WriteLine($"Invalid reference format: {referencePart}");
                     continue;

                }
                string book = referenceParts[0].Trim();

                
                string[] chapterVerse = referenceParts[1].Trim().Split(":");
                if(chapterVerse.Length != 2)
                {
                    Console.WriteLine($"Invalid chapter/verse format: {referencePart}");
                    continue;
                }
                int chapter = int.Parse(chapterVerse[0].Trim());
                string[] verses = chapterVerse[1].Trim().Split("-");
                Reference reference;

                if (verses.Length == 1)
                {
                     int verse = int.Parse(verses[0].Trim());
                    reference = new Reference(book, chapter, verse);
                }
                else if (verses.Length == 2)
                {
                     int startVerse = int.Parse(verses[0].Trim());
                     int endVerse = int.Parse(verses[1].Trim());
                    reference = new Reference(book, chapter, startVerse, endVerse);
                }
                else{
                    Console.WriteLine($"Invalid verse format: {referencePart}");
                    continue;

                }
                   

                Scripture scripture = new Scripture(reference, text);
                _scriptures.Add(scripture);
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"Error: File '{filename}' not found.");
           
        }
        catch (Exception ex)
        {
           Console.WriteLine($"An error occurred: {ex.Message}");
        }
     }

    /*
    * **Exceeds Requirements:**
    *    1. **Scripture Library:** Instead of a single hardcoded scripture, the program now loads scriptures from a file ("scriptures.txt") into a library of scriptures at startup. It then chooses one randomly for the user.
    *    2. **Loading From a File:** Scriptures are read from the "scriptures.txt" file, allowing users to add or change scriptures easily without modifying the code. This file stores each scripture on a new line in the format "Reference| |Scripture Text". For example: "John 3:16 | |For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."
     *   3. **Word Selection:**  It now uses a more advanced word selection approach, only choosing words that have not been hidden yet.
    */
}
