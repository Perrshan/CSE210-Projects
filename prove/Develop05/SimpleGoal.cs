class SimpleGoal: Goal{
    private bool _isComplete;

    private SimpleGoal(string name, string description, int possiblePoints) :base(name, description, possiblePoints){
        _isComplete = false;
    }

    private SimpleGoal(bool isComplete, string name, string description, int possiblePoints, int earnedPoints) 
     :base(name, description, possiblePoints, earnedPoints){
        _isComplete = isComplete;
    }

    public static SimpleGoal CreateSimpleGoal(){
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
                            
        var goal = new SimpleGoal(name, description, possiblePoints);

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

        Console.WriteLine($"[{status}] {_name} ({_description})");
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