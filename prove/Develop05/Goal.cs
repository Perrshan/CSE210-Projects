class Goal{
    protected string _name;
    protected string _description;
    private int _points;
    
    public Goal(){
        _name = "blank";
        _description = "blank";
    }
    public Goal(string name, string description){
        _name = name;
        _description = description;
    }

    public void GetPoints(){
        Console.WriteLine($"You have {_points} points.");
    }

    public virtual void RecordEvent(){

    }

    public virtual bool IsComplete(){
        return true;
    }

    public void WriteFile(){

    }

    public void ReadFile(){

    }

    public virtual void DisplayGoals(){

    }

    public void DisplayPoints(){

    }


}
