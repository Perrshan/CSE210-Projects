class ChecklistGoal: Goal{
    private int _possiblePoints;
    private int _earnedPoints;
    private int _bonusPoints;
    private int _totalTimes;
    private int _timesCompleted;
    private bool _isComplete;

    public ChecklistGoal(string name, string description, int possiblePoints, int bonusPoints, int totalTimes) :base(name, description){
     _possiblePoints = possiblePoints;
        _bonusPoints = bonusPoints;
        _totalTimes = totalTimes;
        _timesCompleted = 0;
        _isComplete = false;
    }

    public override void DisplayGoal(){
        string status;
        if(_isComplete){
            status = "X";
        } else {
            status = " ";
        }

        Console.WriteLine($"[{status}] {_name} ({_description}) -- Currently completed: {_timesCompleted}/{_totalTimes}");
    }

    public static ChecklistGoal CreateChecklistGoal(){
        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        int possiblePoints = int.Parse(Console.ReadLine());
        Console.Write("How many times does this goal need to be accomplished for a bonus? ");
        int totalTimes = int.Parse(Console.ReadLine());
        Console.Write("What is the bonus for accomplishing it that many times? ");
        int bonusPoints = int.Parse(Console.ReadLine());
                            
        var goal = new ChecklistGoal(name, description, possiblePoints, bonusPoints, totalTimes);

        return goal;
    }

    public override int GetPoints(){
        return _earnedPoints;
    }

    public override void RecordEvent(){
        _earnedPoints += _possiblePoints;
        _timesCompleted += 1;
        if(_timesCompleted == _totalTimes){
            _earnedPoints += _bonusPoints;
            _isComplete = true;
        }
    }
}