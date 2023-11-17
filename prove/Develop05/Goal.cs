abstract class Goal{
    protected string _name;
    protected string _description;
    
    public Goal(string name, string description){
        _name = name;
        _description = description;
    }

    public void DisplayGoalName(){
        Console.WriteLine(_name);
    }

    public abstract int GetPoints();

    public abstract string WriteFile();

    public abstract void DisplayGoal();

    public abstract void RecordEvent();


}
