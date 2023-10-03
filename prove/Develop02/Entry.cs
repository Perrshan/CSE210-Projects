using System;

public class Entry
{
    public string _prompt;
    public string _date;
    public string _entry;

    public void Display()
    {
        Console.WriteLine($"{_prompt} {_date} {_entry}");
    }

    public string Save()
    {
        string fileLine = $"{_prompt} ~ {_date} ~ {_entry}";
        return fileLine;
    }
}