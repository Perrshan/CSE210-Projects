class BreathingActivity: Activity{

    public BreathingActivity() : base("Breathing", "This Activity will help you relax by walking through breathing in and out slowly. Clear your mind and focus on your breathing."){

    }

    public void StartActivity(){
        bool time = false;

        DisplayStartingMessage();
        DisplayDescription();
        SetDuration();

        Console.Clear();
        Console.WriteLine("Get ready...");
        DisplayAnimation();
        Console.WriteLine();

        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(_duration);

        while(!time){
            DisplayBreathingInstructions();
            time = CheckTime(futureTime);

        }
        
        DisplayEndingMessage();
        
    }

    public void DisplayBreathingInstructions(){
        int pauseTime = 1000;
        int breathInTime  = 4;
        int breathOutTime = 6;

        Console.Write("Breath in... ");
        while(breathInTime != 0){
            Console.Write("\b");
            Console.Write(breathInTime);
            Pause(pauseTime);
            
            breathInTime --;
        }

        Console.Write("\b");
        Console.Write(" ");
        Console.WriteLine();

        Console.Write("Breath out... ");
        while(breathOutTime != 0){
            Console.Write("\b");
            Console.Write(breathOutTime);
            Pause(pauseTime);
            
            breathOutTime --;
        }

        Console.Write("\b");
        Console.Write(" ");
        Console.WriteLine();
        Console.WriteLine();

    }

}