class EternalGoal : Goal{
    private int _possiblePoints;
    private int _earnedPoints;

    public EternalGoal(string name, string description, int possiblePoints) :base(name, description){
        _possiblePoints = possiblePoints;
    }

    public override void DisplayGoal(){

        Console.WriteLine($"[ ] {_name} ({_description})");
    }

    public static EternalGoal CreateEternalGoal(){
        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        int possiblePoints = int.Parse(Console.ReadLine());
                            
        var goal = new EternalGoal(name, description, possiblePoints);

        return goal;
    }

    public override int GetPoints(){
        return _earnedPoints;
    }

    public override void RecordEvent(){
        _earnedPoints += _possiblePoints;
    }
}