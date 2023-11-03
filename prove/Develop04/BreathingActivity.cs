class BreathingActivity: Activity{

    // calls the base constructor and assigns the unique breathing _name and _description values
    public BreathingActivity() : base("Breathing", 
    "This Activity will help you relax by walking through breathing in and out slowly. Clear your mind and focus on your breathing."){

    }

    public void StartActivity(){
        DisplayBeginningMessages();

        DateTime endTime = GetEndTime();

        // repeats the breathing instructions until the endTime is reached
        while(!_endTimeReached){
            DisplayBreathingInstructions();
            SetEndTimeReached(CheckTime(endTime));

        }
        
        DisplayEndingMessage();
        
    }

    // prints breath in and breath out with a countdown
    private void DisplayBreathingInstructions(){
        Console.Write("Breath in... ");
        DisplayCountdown(4);
        Console.Write("Breath out... ");
        DisplayCountdown(6);
        Console.WriteLine();
    }

}