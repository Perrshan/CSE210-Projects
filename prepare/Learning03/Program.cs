using System;

// main class
class Program
{
    // main program
    static void Main(string[] args)
    {
        // initilizes variables
        int top;
        int bottom;

        // creates a function using the no argument constructor
        Fraction f1 = new Fraction();
        Console.WriteLine(f1.GetFractionString());
        Console.WriteLine(f1.GetDecimalValue());

        // creates a fraction using the top argument constructor
        Fraction f2 = new Fraction(5);
        Console.WriteLine(f2.GetFractionString());
        Console.WriteLine(f2.GetDecimalValue());

        // creates a fraction using the top and bottom argument constructor
        Fraction f3 = new Fraction(3, 4);
        Console.WriteLine(f3.GetFractionString());
        Console.WriteLine(f3.GetDecimalValue());

        Fraction f4 = new Fraction(1, 3);
        Console.WriteLine(f4.GetFractionString());
        Console.WriteLine(f4.GetDecimalValue());

        // the rest of the code uses the getter and setter variables to define a fifth fraction
        Fraction f5 = new Fraction();

        Console.Write("Enter the top number: ");
        top = int.Parse(Console.ReadLine());

        Console.Write("Enter the bottom number: ");
        bottom = int.Parse(Console.ReadLine());

        f5.SetFractionTop(top);
        f5.SetFractionBottom(bottom);

        top = f5.GetFractionTop();
        bottom = f5.GetFractionBottom();

        Console.WriteLine($"The top number is: {top}");
        Console.WriteLine($"The bottom number is: {bottom}");

        Console.WriteLine(f5.GetFractionString());
        Console.WriteLine(f5.GetDecimalValue());
    }
}