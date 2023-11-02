class ListingActivity: Activity{

    public ListingActivity() : base("Listing", "This activity will help you reflect on good things in your life by having you list as many things as you can in a certain area."){
        
    }

    public void StartActivity(){
        DisplayStartingMessage();
        DisplayDescription();
        SetDuration();
        GetDuration();
        DisplayEndingMessage();
        
    }
}