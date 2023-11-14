using System;

class Program
{
    static void DisplayMenu()
    {
        Console.WriteLine("Menu Options:");
        Console.WriteLine("\t1: Create New Goal");
        Console.WriteLine("\t2: List Goals");
        Console.WriteLine("\t3: Save Goals");
        Console.WriteLine("\t4: Load Goals");
        Console.WriteLine("\t5: Record Event");
        Console.WriteLine("\t6: Quit");

        Console.Write("Select a choice from the menu: ");
    }

    static void DisplayGoalTypes()
    {
        Console.WriteLine("The types of goals are:");
        Console.WriteLine("\t1: Simple Goal");
        Console.WriteLine("\t2: Eternal Goal");
        Console.WriteLine("\t3: Checklist Goal");
        
        Console.Write("Which type of goal would you like to create? ");
    }

    static void Main(string[] args)
    {
        // use a double delimiter when trying to split up data from the super class and the sub class. After it is split you can then split it again.
        var goal = new Goal();
        var simple = new SimpleGoal();
        var goals = new List<Goal>();

        Console.Clear();
        string menuResponse;
        string goalTypeResponse;
        bool done = false;
        while(!done){

            Console.WriteLine();
            goal.GetPoints();
            Console.WriteLine();

            DisplayMenu();
            menuResponse = Console.ReadLine();
            Console.Clear();

            switch(menuResponse){

                // Create New Goal
                case "1":
                    DisplayGoalTypes();
                    goalTypeResponse = Console.ReadLine();

                    string name;
                    string description;
                    int points;
                    int totalTimes;
                    int bonusPoints;


                    switch(goalTypeResponse){

                        case "1":
                            var simpleGoal = simple.CreateSimpleGoal();
                            goals.Add(simpleGoal);

                        break;

                        case "2":
                            Console.Write("What is the name of your goal? ");
                            name = Console.ReadLine();
                            Console.Write("What is a short description of it? ");
                            description = Console.ReadLine();
                            Console.Write("What is the amount of points associated with this goal? ");
                            points = int.Parse(Console.ReadLine());
                            
                            var eternal = new EternalGoal(name, description, points);
                            goals.Add(eternal);

                        break;

                        case "3":
                            Console.Write("What is the name of your goal? ");
                            name = Console.ReadLine();
                            Console.Write("What is a short description of it? ");
                            description = Console.ReadLine();
                            Console.Write("What is the amount of points associated with this goal? ");
                            points = int.Parse(Console.ReadLine());
                            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                            totalTimes = int.Parse(Console.ReadLine());
                            Console.Write("What is the bonus for accomplishing it that many times? ");
                            bonusPoints = int.Parse(Console.ReadLine());

                            
                            var checklist = new ChecklistGoal(name, description, points, bonusPoints, totalTimes);
                            goals.Add(checklist);

                        break;

                        default:
                        Console.WriteLine("Invalid Entry. Please enter a number 1-3");
                        break;
                    }

                break;

                // List Goals
                case "2":

                    foreach(Goal goalType in goals){
                        goalType.DisplayGoals();
                    }

                break;

                // Save Goals
                case "3":

                break;

                // Load Goals
                case "4":

                break;

                // Record Event
                case "5":

                break;

                // Quit
                case "6":
                    done = true;
                break;

                // default case if the user does not enter a string of "1-6"
                default:
                Console.WriteLine("Invalid Entry. Please enter a number from 1-4.");
                break;
            }
        }
    }
}