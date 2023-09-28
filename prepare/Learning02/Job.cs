using System;

//Creates instances about job information and prints that description.
public class Job
{

    //Define the 4 instances.
    public string _company;
    public string _jobTitle;
    public int _startYear;
    public int _endYear;

    //A method that prints the Job Descriptions.
    public void Display()
    {
        Console.WriteLine($"{_jobTitle} ({_company}) {_startYear}-{_endYear}");
    }
}