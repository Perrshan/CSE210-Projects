// to exceed the requirements I added comments to my code, and I added a way for the user to input their own scripture. I don't think I added any
// more than that because this develop assignment really pushed me. I would love to talk with you sometime to learn more about how classes 
// can interact with eachother.

using System;

class Program
{
    // main code
    static void Main(string[] args)
    {
        // make beginning variables
        bool done = false;
        string scripture;

        // create two objects from the Reference and Scripture classes
        Reference scriptureReference = new Reference();
        Scripture memorizeScripture = new Scripture();

        // this checks to see if the user wants to input their own scripture or just use the Proverbs example.
        Console.WriteLine("Do you want to use a scripture other than Proverbs 3:5-6?(y or n) ");
        string stringResponse = Console.ReadLine();
        
        if(stringResponse == "n")
        {
            // if the answer is "n" then the blank constructor will be called
            scriptureReference = new Reference();
            scripture = "Trust in the LORD with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.";
            
        } else {

            // if another answer is given then it will ask the user to input all of the needed data and use a three variable constructor in the
            // Reference class
            Console.WriteLine("What is the book of your scripture? ");
            string book = Console.ReadLine();
            Console.WriteLine("What is the chapter of your scripture? ");
            string chapter = Console.ReadLine();
            Console.WriteLine("What is/are the verse(s) of your scripture? (x) or (x-y) ");
            string verse = Console.ReadLine();
            scriptureReference = new Reference(book, chapter, verse);

            // gets the new scripture text
            Console.WriteLine("Copy the text of the scripture on this line: ");
            scripture = Console.ReadLine();
        }

        // creates a list of all the words within the scripture string then assigns them all to a one variable constructor in the Word class
        string[] scriptureWords = scripture.Split(" ");
        
        foreach(string text in scriptureWords)
        {
        Word word = new Word($"{text}");
        memorizeScripture.AddWordList(word);
        }

        Console.Clear();

        // displays reference and scripture text before any words are hidden
        scriptureReference.Display();
        memorizeScripture.GetRenderedList();

        while(!done)
        {
            Console.WriteLine("Press enter to continue or type 'quit' to finish:");
            string answer = Console.ReadLine();
            if(answer == "")
            {
                Console.Clear();


                // hides up to 3 words
                memorizeScripture.HideWords();

                // displays new list
                scriptureReference.Display();
                memorizeScripture.GetRenderedList();
            } else if(answer == "quit") {

                Console.WriteLine();
                Console.WriteLine("Thank you for memorizing!");
                done = true;
            } else {

                Console.WriteLine("Invalid Response.");
            }
            
            if(!done)
            {
            // checks to see if all words are hidden
            done = memorizeScripture.IsCompletelyHidden();
            }
        }
    }
}