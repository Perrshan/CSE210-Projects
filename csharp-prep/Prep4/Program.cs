using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep4 World!");

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

    }
}