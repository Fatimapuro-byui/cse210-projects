using System;
using System.Collections.Generic;
using System.IO;

namespace JournalApp
{
    class Program
    {
        // Exceeds Requirements: Added a feature to allow users to search for entries by date.
        static void Main(string[] args)
        {
            Journal journal = new Journal();
            bool running = true;

            while (running)
            {
                Console.WriteLine("\nJournal App Menu:");
                Console.WriteLine("1. Write a new entry");
                Console.WriteLine("2. Display the journal");
                Console.WriteLine("3. Save the journal to a file");
                Console.WriteLine("4. Load the journal from a file");
                Console.WriteLine("5. Search entries by date"); // New Feature
                Console.WriteLine("6. Exit");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        journal.WriteNewEntry();
                        break;
                    case "2":
                        journal.DisplayJournal();
                        break;
                    case "3":
                        Console.Write("Enter filename to save: ");
                        string saveFilename = Console.ReadLine();
                        journal.SaveJournal(saveFilename);
                        break;
                    case "4":
                        Console.Write("Enter filename to load: ");
                        string loadFilename = Console.ReadLine();
                        journal.LoadJournal(loadFilename);
                        break;
                    case "5": // New Feature Implementation
                        Console.Write("Enter date to search (YYYY-MM-DD): ");
                        string searchDate = Console.ReadLine();
                        journal.SearchByDate(searchDate);
                        break;
                    case "6":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}


    





    
