using System;

// I took a good amount of time to make sure that I used the correct encapsulation rules in my code. Each activity has its own attributes
// and behaviors and any shared attributes or behaviors were stored within the Activity class. I added a try/catch statement to make sure
// that the duration entered was actually an integer. I also commented on all the more in-depth code to make sure that it could easily be
// understood and I took the time to format the code to look neat and professional.

class Program
{
    static void DisplayMenu()
    {
        Console.WriteLine("1: Start Breathing Activity");
        Console.WriteLine("2: Start Reflecting Activity");
        Console.WriteLine("3: Start Listing Activity");
        Console.WriteLine("4: Quit");

        Console.Write("Select a choice from the menu: ");
    }
    
    // main function
    static void Main(string[] args)
    {
        string menuResponse;
        bool done = false;
        while(!done){

            DisplayMenu();
            menuResponse = Console.ReadLine();
            Console.Clear();

            switch(menuResponse)
            {
                // initializes the breathing activity
                case "1":
                BreathingActivity breathing = new BreathingActivity();
                breathing.StartActivity();

                break;

                // initializes the Reflecting activity
                case "2":
                ReflectingActivity reflecting = new ReflectingActivity();
                reflecting.StartActivity();

                break;

                // initializes the Listing activity
                case "3":
                ListingActivity listing = new ListingActivity();
                listing.StartActivity();

                break;

                // ends the while loop
                case "4":
                done = true;
                break;

                // default case if the user does not enter a string of "1-4"
                default:
                Console.WriteLine("Invalid Entry. Please enter a number from 1-4.");
                break;
            }
        }
    }
}