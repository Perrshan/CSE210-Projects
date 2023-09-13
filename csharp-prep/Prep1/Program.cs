using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep1 World!");

        //Prep 1 Assignment

        //Get first name
        Console.Write("What is your first name? ");
        string firstName = Console.ReadLine();

        //Get last name
        Console.Write("What is your last name? ");
        string lastName = Console.ReadLine();

        //Print James Bond line
        Console.WriteLine($"Your name is {lastName}, {firstName} {lastName}.");



        /*Notes from Class Sept 13, 2023

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
        */

    }
}