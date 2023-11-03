class ReflectingActivity: Activity{

    private List<string> reflectingPrompts = new List<string> {
        "Think of a time when you stood up for someone else.", 
        "Think of a time when you did something really difficult.", 
        "Think of a time when you helped someone in need.", 
        "Think of a time when you did something truly selfless."
    };

    private List<string> reflectingQuestions = new List<string> {
        "Why was this experience meaningful to you?", 
        "Have you ever done anything like this before?", 
        "How did you get started?", 
        "How did you feel when it was complete?", 
        "What made this time different than other times when you were not as successful?", 
        "What is your favorite thing about this experience?", 
        "What could you learn from this experience that applies to other situations?", 
        "What did you learn about yourself through this experience?", 
        "How can you keep this experience in mind in the future?"
    };

    // calls the base constructor and assigns the unique reflecting _name and _description values
    public ReflectingActivity() : base("Reflecting", 
    "This activity will help you reflect on times in your life when you have shown strength and resilience. " 
    + "This will help you recognize the power you have and how you can use it in other aspects of your life."){
        
    }

    public void StartActivity(){
        DisplayBeginningMessages();

        // prints the prompt and waits for the user to push enter
        Console.WriteLine($"--- {GetRandomString(reflectingPrompts)} ---");
        Console.WriteLine();
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();
        
        Console.WriteLine("Now ponder on each of the following questions as they related to this experience.");
        Console.Write("You may begin in:  ");
        DisplayCountdown(5);
        Console.Clear();

        DateTime endTime = GetEndTime();


        // prints questions about the prompt until the end time is reached
        while(!_endTimeReached){
            Console.Write($"> {GetRandomString(reflectingQuestions)} ");
            DisplayAnimation(30);
            Console.WriteLine();
            SetEndTimeReached(CheckTime(endTime));

        }

        Console.WriteLine();

        DisplayEndingMessage();
        
    }

}