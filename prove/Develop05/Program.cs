using System;
using System.IO; 

class Program
{
    static void DisplayMenu()
    {
        Console.WriteLine("Menu Options:");
        Console.WriteLine("\t1: Create New Goal");
        Console.WriteLine("\t2: List Goals");
        Console.WriteLine("\t3: Remove Goal");
        Console.WriteLine("\t4: Save Goals");
        Console.WriteLine("\t5: Load Goals");
        Console.WriteLine("\t6: Record Event");
        Console.WriteLine("\t7: Quit");

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

    static void DisplayList(List<Goal> goals, string method)
    {
        int lineNumber = 1;
        foreach(Goal goalType in goals){
            Console.Write($"{lineNumber}. ");
            if(method == "DisplayGoal"){
                goalType.DisplayGoal();
            } else {
                goalType.DisplayGoalName();
            }
            lineNumber++;
        }
    }

    static void Main(string[] args)
    {
        var goals = new List<Goal>();

        int iGoal;
        int deletedPoints = 0;
        string filename;
        string menuResponse;
        string goalTypeResponse;
        bool done = false;

        Console.Clear();
        while(!done){

            int totalPoints = deletedPoints;

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
                    DisplayList(goals, "DisplayGoal");

                break;

                // Remove Goal
                case "3":
                    if(goals.Count == 0){
                        Console.WriteLine("You have no goals to remove.");

                    } else { 
                        DisplayList(goals, "DisplayGoalName");

                        Console.Write("Which goal would you like to remove? (Type any letter to cancel) ");

                        try {
                            iGoal = int.Parse(Console.ReadLine()) -1;
                            int i = 0;
                            foreach(Goal goalType in goals){
                                if(i == iGoal){
                                    deletedPoints += goalType.GetPoints();
                                    break;
                                }
                                i++;
                        
                                goals.RemoveAt(iGoal);
                            }
                        } catch (FormatException) {
                            Console.WriteLine("Remove Goal canceled.");
                        } catch (ArgumentOutOfRangeException){
                            Console.WriteLine($"Invalid Entry. Please enter a number 1-{goals.Count}");
                        }
                    }
                break;

                // Save Goals
                case "4":
                    Console.Write("What file would you like to save to? ");
                    filename = Console.ReadLine() + ".txt";
                    using (StreamWriter outputFile = new StreamWriter(filename))
                    {
                        outputFile.WriteLine(deletedPoints);
                        foreach(Goal goalType in goals){
                            outputFile.WriteLine(goalType.WriteFile());
                        }
                    }
                    goals.Clear();
                    deletedPoints = 0;
                    
                break;

                // Load Goals
                case "5":
                    Console.Write("What is the filename for the goals file? ");
                    filename = Console.ReadLine() + ".txt";
                    try{
                        string[] lines = System.IO.File.ReadAllLines(filename);
                        deletedPoints += int.Parse(lines[0]);

                        foreach (string line in lines)
                        {
                            string[] parts = line.Split("~");

                            if(parts[0] == "Simple Goal"){
                                goals.Add(SimpleGoal.ReadSimpleGoal(Convert.ToBoolean(parts[1]), parts[2], parts[3], int.Parse(parts[4]), 
                                int.Parse(parts[5])));
                            } 
                            else if(parts[0] == "Eternal Goal"){
                                goals.Add(EternalGoal.ReadEternalGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4])));
                            } 
                            else if(parts[0] == "Checklist Goal"){
                                goals.Add(ChecklistGoal.ReadChecklistGoal(Convert.ToBoolean(parts[1]), parts[2], parts[3], int.Parse(parts[4]), 
                                int.Parse(parts[5]), int.Parse(parts[6]), int.Parse(parts[7]), int.Parse(parts[8])));
                            }
                            else{
                                // do nothing.
                            }
                        }
                    } catch (FileNotFoundException){
                        Console.WriteLine($"Cannot find {filename} .");
                    }

                break;

                // Record Event
                case "6":
                    if(goals.Count == 0){
                        Console.WriteLine("You have no goals to record.");
                    } else {
                        DisplayList(goals, "DisplayGoalName");

                        Console.Write("Which goal did you accomplish? ");
                        try{
                            iGoal = int.Parse(Console.ReadLine()) - 1;
                            goals[iGoal].RecordEvent();
                        } catch (FormatException){
                            Console.WriteLine($"Invalid Entry. Please enter a number 1-{goals.Count}");
                        } catch (ArgumentOutOfRangeException){
                            Console.WriteLine($"Invalid Entry. Please enter a number 1-{goals.Count}");
                        }
                        
                    }

                break;

                // Quit
                case "7":
                    done = true;
                break;

                // default case if the user does not enter a string of "1-6"
                default:
                    Console.WriteLine("Invalid Entry. Please enter a number from 1-7.");
                break;
            }
        }
    }
}