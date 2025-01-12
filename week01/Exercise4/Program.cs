using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise4 Project.");

        
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        int number;
        do
        {
            Console.Write("Enter number: ");
            string input = Console.ReadLine();
            if (!int.TryParse(input, out number))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                continue;
            }

            if (number != 0)
            {
                numbers.Add(number);
            }
        } while (number != 0);

        if (numbers.Count == 0)
        {
            Console.WriteLine("No numbers were entered.");
            return;
        }

        int sum = numbers.Sum();
        double average = (double)sum / numbers.Count;
        int max = numbers.Max();

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");

        // Stretch Challenges
        int smallestPositive = int.MaxValue;
        foreach (int num in numbers)
        {
            if (num > 0 && num < smallestPositive)
            {
                smallestPositive = num;
            }
        }
        if (smallestPositive == int.MaxValue)
        {
            Console.WriteLine("There are no positive numbers in the list.");
        }
        else
        {
            Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        }


        numbers.Sort();
        Console.WriteLine("The sorted list is:");
        foreach (int num in numbers)
        {
            Console.WriteLine(num);
        }
    }
}
    
