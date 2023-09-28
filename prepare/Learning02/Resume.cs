using System;

//Stores the different jobs that are created within the Job class into the _jobs list and displays information.
public class Resume
{

    //Creates the two instances one being a list.
    public string _name;

    public List<Job> _jobs = new List<Job>();

    //A method that prints out the name of the person and calls the method in the Job.cs file to print the job description. 
    public void Display()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs: ");
        
        foreach (Job job in _jobs)
        {
            job.Display();
        }
    }

}