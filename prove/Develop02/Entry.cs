using System;

//The Entry class defines the _prompt, _date, and _entry instances. Creates the Display and Save Methods.
public class Entry
{
    public string _date;
    public string _prompt;
    public string _entry;

    //Displays the instances in a neat format.
    public void Display()
    {
        Console.WriteLine(" ");
        Console.WriteLine($"{_date} - {_prompt}");
        Console.WriteLine($"{_entry}");
        Console.WriteLine(" ");
    }

    //Creates a concatenated version of the entries for easy reading.
    public string Save()
    {
        string fileLine = $"{_prompt}~{_date}~{_entry}~";
        return fileLine;
    }
}