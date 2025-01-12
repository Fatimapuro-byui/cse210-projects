using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise3 Project.");

        




    
        
        while (true)
        {
            
            Random rand = new Random();
            int magicNumber = rand.Next(1, 101);  
            
            
            int userGuess = -1;
            int guessCount = 0;

            
            Console.WriteLine("Welcome to Guess My Number!");
            Console.WriteLine("I have picked a magic number between 1 and 100.");
            Console.WriteLine("Try to guess the number!");

            
            while (userGuess != magicNumber)
            {
                
                Console.Write("What is your guess? ");
                userGuess = int.Parse(Console.ReadLine());
                guessCount++;

                
                if (userGuess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (userGuess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                    Console.WriteLine($"It took you {guessCount} guesses.");
                }
            }

            
            Console.Write("Do you want to play again? (yes/no): ");
            string playAgain = Console.ReadLine().ToLower();

            if (playAgain != "yes")
            {
                Console.WriteLine("Thanks for playing! Goodbye.");
                break;  
            }
        }
    }
}

    
