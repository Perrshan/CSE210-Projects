using System;
using System.IO;

//To exceed the requirements I added a try and catch to make sure that the user inputted an integer so as to not crash the switch case.
//I also added a saveCheck boolean variable to mimic what websites do when a user tries to exit before saving a file. 
//To make sure that no prompt is used more than 1 time, I added code that removes the prompt from the prompts list after it was used.
//I also added more prompts to the list along with the ones given in the abstraction.

class Program
{
    //Displays the menu and the prompt to choose one of the options.
    static void DisplayMenu()
    {
        Console.WriteLine("1: Write Entry");
        Console.WriteLine("2: Display");
        Console.WriteLine("3: Load");
        Console.WriteLine("4: Save");
        Console.WriteLine("5: Quit");

        Console.Write("Please choose one of the following options(1-5): ");
    }

    //Main function.
    static void Main(string[] args)
    {
        //Creates Datetime and string Variable for date.
        DateTime theCurrentTime = DateTime.Now;
        string dateText = theCurrentTime.ToShortDateString();

        //Creates the string and int variable to go through the menu and switch case.
        string menuResponseString;
        int menuResponseInt;

        //Creates a rnd Random variable.
        Random rnd = new Random();

        //Creates a string variable where user will input their answer to the prompt.
        string promptAnswer;

        //Creates a myJournal Journal variable.
        Journal myJournal = new Journal();

        //Creates a string variable for the file name they want to save it to.
        string fileName;

        //Creates a boolean variable to check if the user has saved their entries.
        bool saveCheck = false;
        string saveCheckResponse;

        //Creates a List for the prompts, and adds prompts to that list.
        List<string> prompts = new List<string>();
        prompts.Add("Who was the most interesting person I interacted with today?");
        prompts.Add("What was the best part of my day?");
        prompts.Add("How did I see the hand of the Lord in my life today?");
        prompts.Add("What was the strongest emotion I felt today?");
        prompts.Add("If I had one thing I could do over today, what would it be?");
        prompts.Add("What did I learn today? How can I apply this knowledge in the future?");
        prompts.Add("What challenges did I face today? How did I overcome them? What can I learn from these experiences?");
        prompts.Add("What did I do today that brought me joy or fulfillment? How can I incorporate more of these activities into my daily routine?");
        prompts.Add("What was a moment of joy, delight, or contentment today?");
        prompts.Add("What was a small detail I noticed today?");
        prompts.Add("What was the weather like today?");
        prompts.Add("What am I thankful for today?");
        prompts.Add("What could I have done differently today?");
        prompts.Add("How can I make tomorrow even better?");

        //Creates a boolean variable for the While loop condition.
        bool done = false;

        while (!done)
        {
            //Assigns a random value to randomInt.
            int randomInt = rnd.Next(0, prompts.Count - 1);

            //Creates an entry variable.
            Entry entry = new Entry();

            //Displays menu and creates a variable for their response.
            DisplayMenu();
            menuResponseString = Console.ReadLine();

            //Checks to see if the response can be converted into an int. If not makes response int -1 to trigger the default switch case.
            try
            {
                menuResponseInt = int.Parse(menuResponseString);
            }
            catch (FormatException)
            {
                menuResponseInt = -1;
            }

            //Defines cases.
            switch(menuResponseInt)
            {

                //Assigns variables to all Entry instances and gets the users response to the prompt. Adds Entry to the myJournal list.
                case 1:
                entry._date = $"{dateText}";
                entry._prompt = $"{prompts[randomInt]}";
                Console.WriteLine($"{prompts[randomInt]}");
                promptAnswer = Console.ReadLine();
                entry._entry = $"{promptAnswer}";

                myJournal._entryList.Add(entry);
                Console.WriteLine($"{myJournal._entryList}");

                //Removes the used prompt so that there are no repeats.
                prompts.RemoveAt(randomInt);
                break;

                //Clears Console for neatness and displays the myJournal list.
                case 2:
                Console.Clear();
                myJournal.Display();
                break;

                //Asks the user for the file they want to load. Calls the load function.
                case 3:
                Console.Write("Enter the file you want to load: ");
                fileName = Console.ReadLine();

                myJournal = myJournal.Load(fileName, myJournal);
                saveCheck = false;
                break;

                //Asks the user for the file they want to save their journal within. Calls the save function then clears the myJournal list.
                case 4:
                Console.Write("Enter the file you would like to save these entries within: ");
                fileName = Console.ReadLine();

                myJournal.Save(fileName);

                myJournal._entryList.Clear();
                saveCheck = true;
                break;

                //Changes the loop condition when user enters 5.
                case 5:

                //If the saveCheck variable is False and the _entrylist is empty then it will ask the user if they would like to save before 
                //quiting.
                if (saveCheck)
                {
                    done = true;
                    Console.WriteLine("Thanks for Journaling!");
                }
                else if (!saveCheck && myJournal._entryList.Count > 0)
                {
                    Console.Write("Would you like to save your journal entries?(y/n) ");
                    saveCheckResponse = Console.ReadLine();
                    if (saveCheckResponse == "y")
                    {
                        Console.Write("Enter the file you would like to save these entries within: ");
                        fileName = Console.ReadLine();

                        myJournal.Save(fileName);
                        done = true;
                        Console.WriteLine("Your entries have been saved!");
                        Console.WriteLine("Thanks for Journaling!");
                    }
                    else
                    {
                        done = true;
                        Console.WriteLine("Thanks for Journaling!");
                    }
                }
                else
                {
                    done = true;
                    Console.WriteLine("Thanks for Journaling!");
                }
                break;
                
                //If user enters an invalid switch value it will print error message and return to the top.
                default:
                Console.WriteLine("Invalid entry. Please enter a number 1-5.");
                break;
            }
        }
    }
}

