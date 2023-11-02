class Activity{

    private string _name;
    private string _description;
    protected int _duration;

    public Activity(string name, string description){
        _name = name;
        _description = description;
    }

    public void DisplayDescription(){
        Console.WriteLine(_description);
        Console.WriteLine();
    }

    public void DisplayStartingMessage(){
        Console.WriteLine($"Welcome to the {_name} Activity.");
        Console.WriteLine();
    }

    public void DisplayEndingMessage(){
        Console.WriteLine("Well Done!!");
        DisplayAnimation();
        Console.WriteLine();
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name} Activity.");
        DisplayAnimation();
        Console.Clear();
    }
    
    public void SetDuration(){
        string durationString;
        Console.Write("How long, in seconds, would you like for your session? ");
        durationString = Console.ReadLine();
        int duration = int.Parse(durationString);
        _duration = duration;
        Console.WriteLine();
        
    }

    public void GetDuration(){
        Console.WriteLine(_duration);
    }

    public void Pause(int n){
        Thread.Sleep(n);
    }

    public void DisplayAnimation(){
        string[] animations = {"|", "/", "-", "\\"}; 
        int i = 0;

        for(int count = 0; count < 12; count++){

            Console.Write(animations[i]);
            Pause(500);
            Console.Write("\b\b");
            i ++;

            if(i == animations.Length){
                i = 0;
            }

        }

        Console.Write("\b\b");
        Console.Write(" ");
    }

    public bool CheckTime(DateTime endTime){

        DateTime currentTime = DateTime.Now;
        
        if (currentTime < endTime)
        {
            return false;
        } else {
            return true;
        }
    }
        
}