class SimpleGoal: Goal{
    private int _possiblePoints;
    private int _earnedPoints;
    private bool _isComplete;

    public SimpleGoal(string name, string description, int possiblePoints) :base(name, description){
        _possiblePoints = possiblePoints;
        _isComplete = false;
    }

    public SimpleGoal(bool isComplete, string name, string description, int possiblePoints, int earnedPoints) :base(name, description){
        _isComplete = isComplete;
        _possiblePoints = possiblePoints;
        _earnedPoints = earnedPoints;
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
        bool notInt = true;
        int possiblePoints = 0;

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        while(notInt){
            try{
                Console.Write("What is the amount of points associated with this goal? ");
                possiblePoints = int.Parse(Console.ReadLine());
                notInt = false;
            } catch (FormatException){
                Console.WriteLine("Invalid Entry. Please Enter an integer");
            }
        }
                            
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

    public override string WriteFile(){
        string line = $"Simple Goal~{_isComplete}~{_name}~{_description}~{_possiblePoints}~{_earnedPoints}";
        return line;
    }

    public static SimpleGoal ReadSimpleGoal(bool isComplete, string name, string description, int possiblePoints, int earnedPoints){
        var goal = new SimpleGoal(isComplete, name, description, possiblePoints, earnedPoints);
        return goal;
    }
}