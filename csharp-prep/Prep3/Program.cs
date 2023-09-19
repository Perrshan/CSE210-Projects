using System;

class Program
{
    static void Main(string[] args)
    {
        //Prep 3

        //Declare Variables.
        int guessNumber = -1;
        bool done = false;

        //Outer Loop that checks if the player is done or not.
        while (!done)
        {

            //Gets random number and asks the user to begin guessing. The inner loops has them continually guess until the
            //correct number is guessed.
            int count = 0;
            Random rnd = new Random();
            int randomNumber = rnd.Next(1,100);
            while (randomNumber != guessNumber)
            {
                Console.Write("Guess the number: ");
                string guessNumberString = Console.ReadLine();
                guessNumber = int.Parse(guessNumberString);

                if (guessNumber > randomNumber)
                {
                    Console.WriteLine("You guessed too high!");
                }
                else if (guessNumber < randomNumber)
                {
                    Console.WriteLine("You guess too low!");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                }
                count++;
            }

            //Tells the player how many guesses it took to find the correct answer and asks if they want to play again.
            Console.WriteLine($"It took you {count} tries!");
            Console.Write("Do you want to play again? (y/n): ");
            string donePlaying = Console.ReadLine();

            if (donePlaying == "y")
            {
                Console.WriteLine("Good luck!");
            }
            else
            {
                Console.WriteLine("Thanks for playing!");
                done = true;
            }
        }

        /*
        //While loop
        var count = 0;
        while (count < 5)
        {
            Console.WriteLine("Still going");
            if (count > 5)
            {
                break;
            }
            ++count;
        }

        //Do while loop
        count = 0;
        do
        {
            Console.WriteLine("hit");
            count++;
            Console.WriteLine($"count = {count}");
        }
        while(count < 5);

        //For loop
        for (var i =0; i<5; ++i)
        {
            Console.WriteLine($"i = {i}");
        }

        //Foreach loop
        var myInts = new int[]{1,2,3,4,5};
        for(var i = 0; i < myInts.Length; ++i)
        {
            Console.WriteLine($"i = {myInts[i]}");
        }
        */

    }
}