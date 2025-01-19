
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace JournalApp
{
    public class Journal
    {
        private List<Entry> entries = new List<Entry>();
        private List<string> prompts = new List<string>()
        {
            "What are three things I feel grateful for today?",
            "When did I feel the most at peace today, What brought me that peace?",
            "How did I see the hand of the Lord in my life today?",
            "Can I recall one positive moment from today, no matter how small it was?",
            "What personal strength did I rely on today?",
            "What am I grateful for today?", 
            "Who in my life make me feel supported and loved today?",
            "What is one thing I accomplished today that I am proud of?",
            "Did something make me laugh or smile today, what was it?", 
            "How did my faith in Jesus Christ guide me through the today's challenges?",
        };

        public void WriteNewEntry()
        {
            Random random = new Random();
            int index = random.Next(prompts.Count);
            string prompt = prompts[index];

            Console.WriteLine(prompt);
            Console.Write("Your response: ");
            string response = Console.ReadLine();

            Entry entry = new Entry()
            {
                Date = DateTime.Now.ToString("yyyy-MM-dd"),
                Prompt = prompt,
                Response = response
            };

            entries.Add(entry);
        }

        public void DisplayJournal()
        {
            if (entries.Count == 0)
            {
                Console.WriteLine("Journal is empty.");
                return;
            }

            foreach (Entry entry in entries)
            {
                Console.WriteLine(entry);
                Console.WriteLine("--------------------");
            }
        }

        public void SaveJournal(string filename)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filename))
                {
                    foreach (Entry entry in entries)
                    {
                        writer.WriteLine($"{entry.Date}~|~{entry.Prompt}~|~{entry.Response}");
                    }
                }
                Console.WriteLine("Journal saved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving journal: {ex.Message}");
            }
        }

        public void LoadJournal(string filename)
        {
            try
            {
                entries.Clear(); 
                using (StreamReader reader = new StreamReader(filename))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(new string[] { "~|~" }, StringSplitOptions.None);
                        if (parts.Length == 3)
                        {
                            entries.Add(new Entry() { Date = parts[0], Prompt = parts[1], Response = parts[2] });
                        }
                    }
                }
                Console.WriteLine("Journal loaded successfully.");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading journal: {ex.Message}");
            }
        }

        // Exceeds Requirements: Search functionality
        public void SearchByDate(string date)
        {
            var results = entries.Where(e => e.Date == date).ToList();

            if (results.Count == 0)
            {
                Console.WriteLine($"No entries found for {date}.");
            }
            else
            {
                Console.WriteLine($"Entries for {date}:");
                foreach (var entry in results)
                {
                    Console.WriteLine(entry);
                    Console.WriteLine("--------------------");
                }
            }
        }
    }
}
