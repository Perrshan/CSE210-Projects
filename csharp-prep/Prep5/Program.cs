using System;

class Program
{

    //Displays the welcome message.
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    //Asks the user for their username then returns it as a string.
    static string PromptUserName()
    {
        string username;

        Console.Write("What is your username? ");
        username = Console.ReadLine();

        return username;
    }

    //Asks the user for their favorite number then returns it as an int.
    static int PromptUserNumber()
    {
        string numberString;
        int numberInt;

        Console.Write("What is your favorite number? ");
        numberString = Console.ReadLine();
        numberInt = int.Parse(numberString);

        return numberInt;
    }

    //Takes a int as a parameter then sqaures it and returns the answer as an int.
    static int SqaureNumber(int number)
    {
        number = number*number;

        return number;
    }

    //Main function.
    static void Main(string[] args)
    {

        //Define variables.
        string username;
        int favNumber;
        int squareNumber;

        //Calls the welcome function.
        DisplayWelcome();

        //Calls the rest of the functions.
        username = PromptUserName();
        favNumber = PromptUserNumber();
        squareNumber = SqaureNumber(favNumber);

        //Prints final message.
        Console.WriteLine($"{username}, the sqaure of your number is: {squareNumber}");

    }
}