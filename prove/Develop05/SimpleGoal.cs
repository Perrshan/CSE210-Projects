class SimpleGoal: Goal{
    private int _possiblePoints;
    private int _earnedPoints;
    private bool _isComplete;

    public SimpleGoal(string name, string description, int possiblePoints) :base(name, description){
        _possiblePoints = possiblePoints;
        _isComplete = false;
    }

    public override void DisplayGoal(){
        string status;
        if(_isComplete){
            status = "X";
        } else {
            status = " ";
        }

        Console.WriteLine($"[{status}] {_name} ({_description})");
    }

    public static SimpleGoal CreateSimpleGoal(){
        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        int possiblePoints = int.Parse(Console.ReadLine());
                            
        var goal = new SimpleGoal(name, description, possiblePoints);

        return goal;
    }

    public override int GetPoints(){
        return _earnedPoints;
    }

    public override void RecordEvent(){
        _earnedPoints += _possiblePoints;
        _isComplete = true;
    }
}