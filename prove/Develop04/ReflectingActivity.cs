class ReflectingActivity: Activity{

    public ReflectingActivity() : base("Reflecting", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life."){
        
    }

    public void StartActivity(){
        DisplayStartingMessage();
        DisplayDescription();
        SetDuration();
        GetDuration();
        DisplayEndingMessage();
        
    }
}