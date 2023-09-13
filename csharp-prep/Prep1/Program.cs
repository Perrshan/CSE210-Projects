using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep1 World!");

        //String interpolation
        int myInt = 5;
        Console.WriteLine("my int equals" + myInt);
        Console.WriteLine($"my int equals {myInt}");

        //ReadLine
        Console.Write("What is your name?");
        string name = Console.ReadLine();
        Console.WriteLine($"name = {name}");

        //Conditionals
        if (name == "Xave")
        {
            Console.WriteLine("Hey that's me");
        }
        else
        {
            Console.WriteLine($"Hi there {name}");
        }

    }
}