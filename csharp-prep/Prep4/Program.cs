using System;

class Program
{
    static void Main(string[] args)
    {

        //Declare variables and list.
        string numberString;
        int numberInt = 1;
        List<int> myInts = new List<int>();
        int sum = 0;
        float average;
        int smallestNumber = 999999;

        //Asks the user for numbers until they enter 0.
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        while (numberInt != 0)
        {
            Console.Write("Enter number: ");
            numberString = Console.ReadLine();
            numberInt = int.Parse(numberString);

            if (numberInt != 0)
            {
                myInts.Add(numberInt);
            }
        }

        //Sorts the list.
        myInts.Sort();

        //Finds the sum and the smallest positive number.
        foreach (var i in myInts)
        {
            sum += i;

            if (i < smallestNumber && i > 0)
            {
                smallestNumber = i;
            }
        }

        //Finds the average.
        float myIntsLength = myInts.Count;
        average = sum / myIntsLength;

        //Prints all desired values including the new sorted list.
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {myInts[myInts.Count-1]}");
        Console.WriteLine($"The smallest positive number is: {smallestNumber}");

        Console.WriteLine("The sorted list is: ");
        for (int i = 0; i < myInts.Count; i++)
        {
            int number = myInts[i];
            Console.WriteLine(number);
        }

        /*
        //Primitive types
        //int i;
        string s;
        char c;
        float f;
        double d;
        byte b;

        //Lists = new keyword
        //int[] array
        List<int> myInts = new List<int>();
        myInts.Add(2);
        myInts.Add(55);
        myInts.Remove(1);
        myInts.Insert(0, 34);

        List<string> myStrings = new List<string>();
        myStrings.Add("Hello");

        //Iterate over items
        foreach (var i in myInts)
        {
            Console.WriteLine($"My int = {i}");
        }
        */
    }
}