class Goal{
    protected string _name;
    protected string _description;
    
    public Goal(string name, string description){
        _name = name;
        _description = description;
    }

    public virtual int GetPoints(){
        return 0;
    }

    public virtual bool IsComplete(){
        return true;
    }

    public void WriteFile(){

    }

    public void ReadFile(){

    }

    public virtual void DisplayGoal(){
    
    }

    public void DisplayGoalNames(){
        Console.WriteLine(_name);
    }

    public virtual void RecordEvent(){

    }


}
