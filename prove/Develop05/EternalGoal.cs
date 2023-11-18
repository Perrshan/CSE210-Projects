class EternalGoal : Goal{

    private EternalGoal(string name, string description, int possiblePoints) :base(name, description, possiblePoints){
    
    }

    private EternalGoal(string name, string description, int possiblePoints, int earnedPoints) :base(name, description, possiblePoints,
     earnedPoints){

    }

    public static EternalGoal CreateEternalGoal(){
        bool notInt = true;
        int possiblePoints = 0;

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        // loops until an integer is entered.
        while(notInt){
            try{
                Console.Write("What is the amount of points associated with this goal? ");
                possiblePoints = int.Parse(Console.ReadLine());
                notInt = false;
            } catch (FormatException){
                Console.WriteLine("Invalid Entry. Please Enter an integer");
            }
        }
                            
        var goal = new EternalGoal(name, description, possiblePoints);

        return goal;
    }

    public override void GetGoal(){
        Console.WriteLine($"[ ] {_name} ({_description})");
    }

    public override void RecordEvent(){
        _earnedPoints += _possiblePoints;
    }

    public override string WriteFile(){
        string line = $"Eternal Goal~{_name}~{_description}~{_possiblePoints}~{_earnedPoints}";
        return line;
    }

    public static EternalGoal ReadEternalGoal(string name, string description, int possiblePoints, int earnedPoints){
        var goal = new EternalGoal(name, description, possiblePoints, earnedPoints);
        return goal;
    }
}