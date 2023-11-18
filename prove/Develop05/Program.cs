using System;
using System.IO; 

// I spent a lot of time on this assignment to make sure that it is bug proof if the user enters in an incorrect value. I commented some of
// the more confusing parts of code. I added a remove option that will remove a goal from the list, but also saves any points that were
// associated with that goal. I added a feature to make sure that the user saved their data if they want to. 

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

    // displays either a list of most of the attributes of the goals, or just the name of the goals
    static void DisplayList(List<Goal> goals, string method)
    {
        int lineNumber = 1;
        foreach(Goal goalType in goals){
            Console.Write($"{lineNumber}. ");
            if(method == "GetGoal"){
                goalType.GetGoal();
            } else {
                goalType.GetGoalName();
            }
            lineNumber++;
        }
    }

    static void SaveGoals(List<Goal> goals, int deletedPoints){
        Console.Write("What file would you like to save to? ");
        string filename = Console.ReadLine() + ".txt";
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine("// Deleted Points:");
            outputFile.WriteLine(deletedPoints);
            outputFile.WriteLine("// Goals List:");

            foreach(Goal goalType in goals){
                outputFile.WriteLine(goalType.WriteFile());
            }
        }
        goals.Clear();
    }

    static void Main(string[] args)
    {
        var goals = new List<Goal>();

        int iGoal;

        // deleted points will keep track of the points of goals that have been removed from the list
        int deletedPoints = 0;

        bool done = false;

        bool saveCheck = false;

        Console.Clear();
        while(!done){

            // totalPoints is calculated in every loop by summing up the earned points in each goal class. it starts off as eqaual to the 
            // deleted points
            int totalPoints = deletedPoints;

            Console.WriteLine();
            foreach(Goal goalType in goals){
                totalPoints += goalType.GetPoints();
            }

            Console.WriteLine($"You have {totalPoints} points.");
            Console.WriteLine();

            DisplayMenu();
            string menuResponse = Console.ReadLine();
            Console.Clear();

            switch(menuResponse){
                // Create New Goal
                case "1":
                    DisplayGoalTypes();
                    string goalTypeResponse = Console.ReadLine();
                    saveCheck = false;

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
                    DisplayList(goals, "GetGoal");

                break;

                // Remove Goal
                case "3":

                    // checks to see if their are any goals in the list
                    if(goals.Count == 0){
                        Console.WriteLine("You have no goals to remove.");

                    } else { 
                        DisplayList(goals, "GetGoalName");

                        Console.Write("Which goal would you like to remove? (Type any letter to cancel) ");

                        // makes sure that the number entered can be converted to an integer and is in range of the list
                        try {
                            iGoal = int.Parse(Console.ReadLine()) -1;

                            // finds the goal at iGoal and adds the earned points of that goal into deletedPoints
                            int i = 0;
                            foreach(Goal goalType in goals){
                                if(i == iGoal){
                                    deletedPoints += goalType.GetPoints();
                                    break;
                                }
                                i++;
                            }
                            goals.RemoveAt(iGoal);
                            saveCheck = false;

                        } catch (FormatException) {
                            Console.WriteLine("Remove Goal canceled.");
                        } catch (ArgumentOutOfRangeException){
                            Console.WriteLine($"Invalid Entry. Please enter a number 1-{goals.Count}");
                        }
                    }
                break;

                // Save Goals
                case "4":
                    SaveGoals(goals, deletedPoints);
                    deletedPoints = 0;
                    saveCheck = true;
                    
                break;

                // Load Goals
                case "5":
                    Console.Write("What is the filename for the goals file? ");
                    string filename = Console.ReadLine() + ".txt";
                    try{
                        string[] lines = System.IO.File.ReadAllLines(filename);
                        deletedPoints += int.Parse(lines[1]);

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
                                goals.Add(ChecklistGoal.ReadChecklistGoal(Convert.ToBoolean(parts[1]), parts[2], parts[3],
                                 int.Parse(parts[4]), int.Parse(parts[5]), int.Parse(parts[6]), int.Parse(parts[7]), int.Parse(parts[8])));
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
                    // checks to see if there is anything in the goals list
                    if(goals.Count == 0){
                        Console.WriteLine("You have no goals to record.");

                    } else {
                        DisplayList(goals, "GetGoalName");

                        Console.Write("Which goal did you accomplish? ");

                        // makes sure that the number entered can be converted to an integer and is in range of the list
                        try{
                            iGoal = int.Parse(Console.ReadLine()) - 1;
                            goals[iGoal].RecordEvent();
                            saveCheck = false;
                        } catch (FormatException){
                            Console.WriteLine($"Invalid Entry. Please enter a number 1-{goals.Count}");
                        } catch (ArgumentOutOfRangeException){
                            Console.WriteLine($"Invalid Entry. Please enter a number 1-{goals.Count}");
                        }
                        
                    }

                break;

                // Quit
                case "7":
                    if (saveCheck){
                        done = true;
                    }
                    else if (!saveCheck && goals.Count > 0)
                    {
                        Console.Write("Would you like to save your progress?(y/n) ");
                        string saveCheckResponse = Console.ReadLine();
                        if (saveCheckResponse == "y"){
                            SaveGoals(goals, deletedPoints);
                            done = true;
                            Console.WriteLine("Your progress has been saved!");
                        } 
                        else if(saveCheckResponse == "n"){
                            done = true;
                        } else {
                            Console.WriteLine("Invalid Entry. Quit canceled.");
                        }
                    }
                    else
                    {
                        done = true;
                    }

                    if(done){
                        Console.WriteLine("“I am so thoroughly convinced that if we don't set goals in our life and learn how to master the"
                        + " techniques of living to reach our goals, we can reach a ripe old age and look back on our life only to see that" 
                        + "we reached but a small part of our full potential.");
                        Console.WriteLine("~President Ballard");
                    }
                    break;

                // default case if the user does not enter a string of "1-7"
                default:
                    Console.WriteLine("Invalid Entry. Please enter a number from 1-7.");
                break;
            }
        }
    }
}