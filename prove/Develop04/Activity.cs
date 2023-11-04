class Activity{

    private string _name;
    private string _description;
    private int _duration;
    protected bool _endTimeReached = false;

    // constructor to assign values to _name and _description
    protected Activity(string name, string description){
        _name = name;
        _description = description;
    }

    private void DisplayDescription(){
        Console.WriteLine(_description);
        Console.WriteLine();
    }

    private void DisplayStartingMessage(){
        Console.WriteLine($"Welcome to the {_name} Activity.");
        Console.WriteLine();
    }

    // sets a user value to _duration and has a try/catch statement to make sure an integer is entered
    private void SetDuration(){
        bool isInteger = false;
        int duration = 0;

        string durationString;
        while(!isInteger){
            Console.Write("How long, in seconds, would you like for your session? ");
            durationString = Console.ReadLine();
            try
                {
                    duration = int.Parse(durationString);
                    isInteger = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter an integer.");
                }
        }
        
        _duration = duration;
        
    }

    // combines the first methods into one method with some extra lines and animations printed
    protected void DisplayBeginningMessages(){
        DisplayStartingMessage();
        DisplayDescription();
        SetDuration();

        Console.Clear();
        Console.WriteLine("Get ready...");
        DisplayAnimation(10);
        Console.WriteLine();
    }

    protected void DisplayEndingMessage(){
        Console.WriteLine("Well Done!!");
        DisplayAnimation(10);
        Console.WriteLine();
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name} Activity.");
        DisplayAnimation(10);
        Console.Clear();
    }

    // takes in an int to determine how many miliseconds the program will pause
    // creates a Pause method so that Thread.Sleep did not need to be entered everytime
    private void Pause(int n){
        Thread.Sleep(n);
    }

    // takes in an int to determine how many times the character will change
    // iterates through a string[] to print the loading animation
    // when i is the same size as the string[] it gets set back to 0
    // the final character printed is replaced with a " " to clear the marks
    protected void DisplayAnimation(int numberOfChanges){
        string[] animations = {"|", "/", "-", "\\"}; 
        int i = 0;

        for(int count = 0; count < numberOfChanges; count++){

            Console.Write(animations[i]);
            Pause(500);
            Console.Write("\b");
            i ++;

            if(i == animations.Length){
                i = 0;
            }

        }

        Console.Write(" ");
    }

    // takes in an int to determine what second the countdown will start at
    // subtracts 1 from the time after printing then prints the new number on top of the previous one
    // the final character printed is replaced with a " " to clear the marks
    protected void DisplayCountdown(int time){
        int pauseTime = 1000;
        while(time != 0){
            Console.Write("\b");
            Console.Write(time);
            Pause(pauseTime);
            
            time --;
        }

        Console.Write("\b");
        Console.Write(" ");
        Console.WriteLine();
    }

    // takes in a list<string>
    // pulls out a random string from the list and returns the string
    protected string GetRandomString(List<string> list){
        Random rnd = new Random();
        int randomInt = rnd.Next(0, (list.Count) - 1);
        
        string randomString = list[randomInt];
        return randomString;
    }

    // sets the value of _endTimeReached
    protected void SetEndTimeReached(bool status){
        _endTimeReached = status;
    }

    // adds _duration to the startTime and returns the endTime of the activity
    protected DateTime GetEndTime(){
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        return endTime;
    }

    // takes in a DateTime variable to determine when the endTime has been reached
    // returns a boolean value depending on whether the time has been reached or not
    protected bool CheckTime(DateTime endTime){

        DateTime currentTime = DateTime.Now;
        
        if (currentTime < endTime)
        {
            return false;
        } else {
            return true;
        }
    }
        
}