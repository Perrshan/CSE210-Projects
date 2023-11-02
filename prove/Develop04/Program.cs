using System;

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
                case "1":
                BreathingActivity breathing = new BreathingActivity();
                breathing.StartActivity();

                break;

                case "2":
                ReflectingActivity reflecting = new ReflectingActivity();
                reflecting.StartActivity();

                break;

                case "3":
                ListingActivity listing = new ListingActivity();
                listing.StartActivity();

                break;

                case "4":
                done = true;
                break;

                default:
                Console.WriteLine("Invalid Entry.");
                break;
            }
        }
    }
}