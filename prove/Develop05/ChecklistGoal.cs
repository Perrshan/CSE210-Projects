class ChecklistGoal: Goal{
    private int _bonusPoints;
    private int _totalTimes;
    private int _timesCompleted;
    private bool _isComplete;

    private ChecklistGoal(string name, string description, int possiblePoints, int bonusPoints, int totalTimes) 
     :base(name, description, possiblePoints){
        _bonusPoints = bonusPoints;
        _totalTimes = totalTimes;
        _timesCompleted = 0;
        _isComplete = false;
    }

    private ChecklistGoal(bool isComplete, string name, string description, int possiblePoints, int earnedPoints, int bonusPoints,
     int timesCompleted, int totalTimes) :base(name, description, possiblePoints, earnedPoints){
        _bonusPoints = bonusPoints;
        _totalTimes = totalTimes;
        _timesCompleted = timesCompleted;
        _isComplete = isComplete;
    }

    public static ChecklistGoal CreateChecklistGoal(){
        bool notInt = true;
        int possiblePoints = 0;
        int totalTimes = 0;
        int bonusPoints = 0;

        // used to check the individual int values in the while loop
        bool good1 = false;
        bool good2 = false;
        bool good3 = false;

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        // loops until all three responses have an integer entered
        while(notInt){
            try{
                if(!good1){
                    Console.Write("What is the amount of points associated with this goal? ");
                    possiblePoints = int.Parse(Console.ReadLine());
                    good1 = true;
                }
                if(!good2){
                    Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                    totalTimes = int.Parse(Console.ReadLine());
                    good2 = true;
                }
                if(!good3){
                    Console.Write("What is the bonus for accomplishing it that many times? ");
                    bonusPoints = int.Parse(Console.ReadLine());
                    good3 = true;
                }
                notInt = false;
            } catch (FormatException){
                Console.WriteLine("Invalid Entry. Please enter an integer.");
            }
        }
                            
        var goal = new ChecklistGoal(name, description, possiblePoints, bonusPoints, totalTimes);

        return goal;
    }

    public override void GetGoal(){
        string status;

        // marks an X if the goal has been completed
        if(_isComplete){
            status = "X";
        } else {
            status = " ";
        }

        Console.WriteLine($"[{status}] {_name} ({_description}) -- Currently completed: {_timesCompleted}/{_totalTimes}");
    }

    public override void RecordEvent(){
        _earnedPoints += _possiblePoints;
        _timesCompleted += 1;

        // checks to see if the goal has been completed and awards bonus points if so
        if(_timesCompleted == _totalTimes){
            _earnedPoints += _bonusPoints;
            _isComplete = true;
        }
    }

    public override int GetPoints(){
        return _earnedPoints;
    }

    public override string WriteFile(){
        string line = $"Checklist Goal~{_isComplete}~{_name}~{_description}~{_possiblePoints}~{_earnedPoints}~{_bonusPoints}~"
        + $"{_timesCompleted}~{_totalTimes}";
        return line;
    }

    public static ChecklistGoal ReadChecklistGoal(bool isComplete, string name, string description, int possiblePoints,
     int earnedPoints, int bonusPoints, int timesCompleted, int totalTimes){
        var goal = new ChecklistGoal(isComplete, name, description, possiblePoints, earnedPoints, bonusPoints, timesCompleted, totalTimes);
        return goal;
    }
}