using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep3 World!");


        //Prep 3
        

        Console.Write("Give me a random number: ");
        String randomNumberString = Console.ReadLine();
        int randomNumber = int.Parse(randomNumberString);

        Console.Write("Guess the number: ");
        string guessNumberString = Console.ReadLine();
        int guessNumber = int.Parse(guessNumberString);

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

    }
}