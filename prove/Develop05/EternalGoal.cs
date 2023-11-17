class EternalGoal : Goal{
    private int _possiblePoints;
    private int _earnedPoints;

    public EternalGoal(string name, string description, int possiblePoints) :base(name, description){
        _possiblePoints = possiblePoints;
    }

    public EternalGoal(string name, string description, int possiblePoints, int earnedPoints) :base(name, description){
        _possiblePoints = possiblePoints;
        _earnedPoints = earnedPoints;
    }

    public override void DisplayGoal(){

        Console.WriteLine($"[ ] {_name} ({_description})");
    }

    public static EternalGoal CreateEternalGoal(){
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
                            
        var goal = new EternalGoal(name, description, possiblePoints);

        return goal;
    }

    public override int GetPoints(){
        return _earnedPoints;
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