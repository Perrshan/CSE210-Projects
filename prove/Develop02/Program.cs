using System;
using System.IO;

class Program
{
    /*static bool RepeatedNumberCheck(List<int> randomInts, int randomInt)
    {
        bool repeat;

        for (int i = 0; i < randomInts.Count; i++)
        {
            int number = randomInts[i];

            if(number == randomInt)
            {
                repeat = true;
                return repeat;
            }
        }

        repeat = false;
        return repeat;
        
    }*/

    static void Main(string[] args)
    {
        DateTime theCurrentTime = DateTime.Now;
        string dateText = theCurrentTime.ToShortDateString();

        string responseString;
        int responseInt;

        /*List<int> randomInts = new List<int>();
        randomInts.Add(-1);*/
        Random rnd = new Random();

        //bool repeat = true;
        bool done = false;

        string answer;
        Journal myJournal = new Journal();
        string fileName;

        List<string> prompts = new List<string>();
        prompts.Add("Who was the most interesting person I interacted with today?");
        prompts.Add("What was the best part of my day?");
        prompts.Add("How did I see the hand of the Lord in my life today?");
        prompts.Add("What was the strongest emotion I felt today?");
        prompts.Add("If I had one thing I could do over today, what would it be?");



        while (!done)
        {
            int randomInt = rnd.Next(0, prompts.Count - 1);
            //repeat = RepeatedNumberCheck(randomInts, randomInt);
            //Console.WriteLine(randomInt);

            //randomInts.Add(randomInt);
            Entry entry = new Entry();
            Console.WriteLine("1: Write Entry");
            Console.WriteLine("2: Display");
            Console.WriteLine("3: Load");
            Console.WriteLine("4: Save");
            Console.WriteLine("5: Quit");

            Console.Write("Please choose one of the following options(1-5): ");
            responseString = Console.ReadLine();
            responseInt = int.Parse(responseString);

            switch(responseInt)
            {
                case 1:
                entry._prompt = $"{prompts[randomInt]}"; //Need to make the prompt list
                entry._date = $"{dateText}"; //actually do the pull date function
                Console.WriteLine($"{prompts[randomInt]}"); //Print prompt for user to see
                answer = Console.ReadLine(); //Get user answer
                entry._entry = $"{answer}"; //Save answer in _entry

                myJournal._entryList.Add(entry); //Add entry to journal list
                Console.WriteLine($"{myJournal._entryList}");
                break;

                case 2:

                myJournal.Display();
                break;

                case 3:
                Console.Write("Enter the file you want to load: ");
                fileName = Console.ReadLine();

                myJournal = myJournal.Load(fileName, myJournal);
                break;

                case 4:

                Console.Write("Enter the file you would like to save these entries within: ");
                fileName = Console.ReadLine();

                myJournal.Save(fileName);

                myJournal._entryList.Clear();
                break;

                case 5:
                done = true;
                break;

                default:
                Console.WriteLine("Invalid entry.");
                break;
            }
        }
    }
}

