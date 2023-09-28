using System;

class Program
{
    static void Main(string[] args)
    {

        //Creates new Job type called job1 and assigns values to the instances.
        Job job1 = new Job();
        job1._jobTitle = "Toilet Paper Manufacturer";
        job1._company = "Big Toilet Co.";
        job1._startYear = 1987;
        job1._endYear = 2023;

        //Creates new Job type called job2 and assigns values to the instances.
        Job job2 = new Job();
        job2._jobTitle = "Back End Developer";
        job2._company = "Apple";
        job2._startYear = 2023;
        job2._endYear = 2033;

        //Creates new Resume type called myResume and assigns a value to the instance.
        Resume myResume = new Resume();
        myResume._name = "Jeff Kevin Billy";

        //Adds the two job descriptions into the _jobs list within the Resume class.
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        //Displays all information.
        myResume.Display();

    }
}


/*
        var car1 = new Car();
        car1._make = "Honda";
        car1._model = "Civic";
        car1._mileage = 30;
        car1._gallonsOfFule = 10;

        car1.ReduceFuel(3);

        var miles = car1.RemainingMiles;

        Console.WriteLine($"{car1}");
        Console.WriteLine($"{miles}");




        //Creating a class creates a new type like int, sting, etc. It acts like the primitive types. 

        var cars = new List<Car>();
        cars.Add(car1);

        string[] carMake = "Honda";
        string[] carModel = "Civic";
        int[] carMileage = 33;
        
public class Car
{
    public string _make;
    public string _model;
    public int _mileage;
    public int _gallonsOfFule;

    int RemainingMiles();
    {
        return _gallonsOfFule * _mileage;
    }

    public void ReduceFuel(int amount)
    {
        _gallonsOfFuel -= amount;
    }

*/