using System;

class Program
{
    static void Main(string[] args)
    {
        //Prep 2 assignment
        
        //Declare Variables.
        string gradeString;
        int gradeInt;
        string letter;
        int remainder;
        string sign = " ";

        //Get grade percentage and convert the string to an int.
        Console.Write("What is your grade percentage? ");
        gradeString = Console.ReadLine();
        gradeInt = int.Parse(gradeString);

        //Uses conditionals to find what letter their grade percentage corresponds to.
        if (gradeInt >= 90)
        {
            letter = "A";
        }
        else if (gradeInt >= 80)
        {
            letter = "B";
        }
        else if (gradeInt >= 70)
        {
            letter = "C";
        }
        else  if (gradeInt >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        //Uses the modulus operater to find a remainder which is then used to find the sing that corresponds with their letter.
        remainder = gradeInt % 10;
        if (remainder >= 7 && gradeInt < 97 && gradeInt >= 67)
        {
            sign = "+";
        }
        else if (remainder < 3 && gradeInt >= 60)
        {
            sign = "-";
        }

        //Prints their letter and sign.
        Console.WriteLine($"Your grade is a(n) {letter}{sign}");

        //Checks to see if the student passed the class or not. 
        if (gradeInt >= 70)
        {
            Console.WriteLine("Great job you passed the class!");
        }
        else
        {
            Console.WriteLine("Better luck next time.");
        }
    }
}