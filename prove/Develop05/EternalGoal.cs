class EternalGoal : Goal{
    private int _subpoints;

    public EternalGoal(string name, string description, int subpoints) :base(name, description){
        _subpoints = subpoints;
    }

    public override void DisplayGoals(){

        Console.WriteLine($"[ ] {_name} ({_description})");
    }

    public EternalGoal CreateEternalGoal(){
        Console.Write("What is the name of your goal? ");
        _name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        _description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        _subpoints = int.Parse(Console.ReadLine());
                            
        var goal = new EternalGoal(_name, _description, _subpoints);

        return goal;
    }
}