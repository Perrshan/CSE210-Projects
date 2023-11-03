class ListingActivity: Activity{

    private List<string> listingPrompts = new List<string> {
        "Who are people that you appreciate?", 
        "What are personal strengths of yours?", 
        "Who are people that you have helped this week?", 
        "When have you felt the Holy Ghost this month?", 
        "Who are some of your personal heroes?"
        };

    // calls the base constructor and assigns the unique listing _name and _description values
    public ListingActivity() : base("Listing", 
    "This activity will help you reflect on good things in your life by having you list as many things as you can in a certain area."){
        
    }

    public void StartActivity(){
        int count = 0;

        DisplayBeginningMessages();

        // prints prompt
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine($" ---{GetRandomString(listingPrompts)}--- ");

        Console.Write("You may begin in:  ");
        DisplayCountdown(5);

        DateTime endTime = GetEndTime();

        // the user continues to answer the prompt until the endTime is reached
        // a count of each response is recorded and printed after the endTime is reached
        while(!_endTimeReached){
            Console.Write($"> ");
            Console.ReadLine();
            count ++;
            SetEndTimeReached(CheckTime(endTime));

            if(_endTimeReached){
                Console.WriteLine($"You listed {count} items!");
            }

        }

        Console.WriteLine();

        DisplayEndingMessage();
        
    }
}