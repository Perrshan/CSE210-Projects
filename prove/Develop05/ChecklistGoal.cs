class ChecklistGoal: Goal{
    private int _subpoints;
    private int _bonusPoints;
    private int _totalTimes;
    private int _timesCompleted;
    private bool _isComplete;

    public ChecklistGoal(string name, string description, int subpoints, int bonusPoints, int totalTimes) :base(name, description){
        _subpoints = subpoints;
        _bonusPoints = bonusPoints;
        _totalTimes = totalTimes;
        _timesCompleted = 0;
        _isComplete = false;
    }

    public override void DisplayGoals(){
        string status;
        if(_isComplete){
            status = "X";
        } else {
            status = " ";
        }

        Console.WriteLine($"[{status}] {_name} ({_description}) -- Currently completed: {_timesCompleted}/{_totalTimes}");
    }

    public ChecklistGoal CreateChecklistGoal(){
        Console.Write("What is the name of your goal? ");
        _name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        _description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        _subpoints = int.Parse(Console.ReadLine());
        Console.Write("How many times does this goal need to be accomplished for a bonus? ");
        _totalTimes = int.Parse(Console.ReadLine());
        Console.Write("What is the bonus for accomplishing it that many times? ");
        _bonusPoints = int.Parse(Console.ReadLine());
                            
        var goal = new ChecklistGoal(_name, _description, _subpoints);

        return goal;
    }
}