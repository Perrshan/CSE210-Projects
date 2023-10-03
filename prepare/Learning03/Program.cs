using System;

class Program
{
    static bool RepeatedNumberCheck(List<int> randomInts, int randomInt)
    {
        bool repeat;

        for (int i = 0; i < randomInts.Count; i++)
        {
            int number = randomInts[i];

            if(number == randomInt)
            {
                repeat = true;
                return repeat;
            }
        }

        repeat = false;
        return repeat;
        
    }


    static void Main(string[] args)
    {
        List<int> randomInts = new List<int>();
        int randomInt;
        Random rnd = new Random();
        bool repeat = true;

        Console.WriteLine("Hello Learning03 World!");

        while(repeat)
        {
            randomInt = rnd.Next(0, 5);
            Console.WriteLine(randomInt);
            repeat = RepeatedNumberCheck(randomInts, randomInt);
        }

        randomInts.Add(randomInt);
        Console.WriteLine("you good!");

        
    }
}