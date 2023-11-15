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
        
        var goals = new List<Goal>();
        int lineNumber;

        Console.Clear();
        string menuResponse;
        string goalTypeResponse;
        bool done = false;
        while(!done){

            int totalPoints = 0;

            Console.WriteLine();
            foreach(Goal goalType in goals){
                        totalPoints += goalType.GetPoints();
                    }
            Console.WriteLine($"You have {totalPoints} points.");
            Console.WriteLine();

            DisplayMenu();
            menuResponse = Console.ReadLine();
            Console.Clear();

            switch(menuResponse){

                // Create New Goal
                case "1":
                    DisplayGoalTypes();
                    goalTypeResponse = Console.ReadLine();

                    switch(goalTypeResponse){

                        case "1":
                            goals.Add(SimpleGoal.CreateSimpleGoal());

                        break;

                        case "2":
                            goals.Add(EternalGoal.CreateEternalGoal());

                        break;

                        case "3":
                            goals.Add(ChecklistGoal.CreateChecklistGoal());

                        break;

                        default:
                        Console.WriteLine("Invalid Entry. Please enter a number 1-3");
                        break;
                    }

                break;

                // List Goals
                case "2":
                    lineNumber = 1;
                    foreach(Goal goalType in goals){
                        Console.Write($"{lineNumber}. ");
                        goalType.DisplayGoal();
                        lineNumber++;
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
                    if(goals.Count == 0){

                        Console.WriteLine("You have no goals to record.");

                    } else {
                        lineNumber = 1;
                        foreach(Goal goalType in goals){
                            Console.Write($"{lineNumber}. ");
                            goalType.DisplayGoalNames();
                            lineNumber++;
                        }

                        Console.Write("Which goal did you accomplish? ");
                        int iGoal = int.Parse(Console.ReadLine()) - 1;
                        goals[iGoal].RecordEvent();
                        
                    }

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