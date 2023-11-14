class SimpleGoal: Goal{
    private int _subpoints;
    private bool _isComplete;

    public SimpleGoal(string name, string description, int subpoints) :base(name, description){
        _subpoints = subpoints;
        _isComplete = false;
    }

    public SimpleGoal(){
        
    }

    public override void DisplayGoals(){
        string status;
        if(_isComplete){
            status = "X";
        } else {
            status = " ";
        }

        Console.WriteLine($"[{status}] {_name} ({_description})");
    }

    public SimpleGoal CreateSimpleGoal(){
        Console.Write("What is the name of your goal? ");
        _name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        _description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        _subpoints = int.Parse(Console.ReadLine());
                            
        var goal = new SimpleGoal(_name, _description, _subpoints);

        return goal;
    }
}