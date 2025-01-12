using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise2 Project.");

    



        
            
        Console.Write("Enter your grade percentage: ");
            int percentage = int.Parse(Console.ReadLine());

            
            string letter = "";

            
            if (percentage >= 90)
            {
                letter = "A";
            }
            else if (percentage >= 80)
            {
                letter = "B";
            }
            else if (percentage >= 70)
            {
                letter = "C";
            }
            else if (percentage >= 60)
            {
                letter = "D";
            }
            else
            {
                letter = "F";
            }

            
        Console.WriteLine($"Your letter grade is: {letter}");

            
            if (percentage >= 70)
            {
                Console.WriteLine("Congratulations, you passed the course!");
            }
            else
            {
                Console.WriteLine("Better luck next time, keep trying!");
            }

            
            string sign = "";
            if (letter != "F" && letter != "A")
            {
                int lastDigit = percentage % 10;

                if (lastDigit >= 7)
                {
                    sign = "+";
                }
                else if (lastDigit < 3)
                {
                    sign = "-";
                }
            }

            
            if (letter == "A" && percentage < 93)
            {
                sign = "-";
            }
            if (letter == "F")
            {
                sign = "";
            }

            
        Console.WriteLine($"Your final grade is: {letter}{sign}");
    }
}



    
