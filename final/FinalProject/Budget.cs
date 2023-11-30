class Budget {
    private string _name;
    private double _budget;
    private bool _isOverBudget;

    public Budget(string name, double budget){
        _name = name;
        _budget = budget;
        _isOverBudget = false;
    }

    public Budget(){

    }

    public double GetBudget(){
        return _budget;
    }

    public void CheckBudget(bool isOver){
        _isOverBudget = isOver;

        if(_isOverBudget){
            Console.WriteLine("its over my guy");
        }
    }

    public static Budget CreateBudget(){
        Console.Write("What is the name of the budget? ");
        string name = Console.ReadLine();
        Console.Write("What is the amount of the budget? ");
        double amount = double.Parse(Console.ReadLine());

        var budget = new Budget(name, amount); 
        return budget;
        
    }


}