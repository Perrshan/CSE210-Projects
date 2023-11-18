abstract class Goal{
    protected string _name;
    protected string _description;
    protected int _possiblePoints;
    protected int _earnedPoints;
    
    protected Goal(string name, string description, int possiblePoints){
        _name = name;
        _description = description;
        _possiblePoints = possiblePoints;
    }

    protected Goal(string name, string description, int possiblePoints, int earnedPoints){
        _name = name;
        _description = description;
        _possiblePoints = possiblePoints;
        _earnedPoints = earnedPoints;
    }

    public void GetGoalName(){
        Console.WriteLine(_name);
    }

    public int GetPoints(){
        return _earnedPoints;
    }

    public abstract string WriteFile();

    public abstract void GetGoal();

    public abstract void RecordEvent();


}
