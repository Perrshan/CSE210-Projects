class Budget {
    private string _name;
    private double _amount;
    private bool _isOverBudget;

    public List<Budget> budgets = new List<Budget>();

    public Budget(string name, double amount){
        _name = name;
        _amount = amount;
        _isOverBudget = false;
    }

    public Budget(){

    }

    public void SetName(){
        Console.Write("What is the name of the budget? ");
        _name = Console.ReadLine();
    }

    public void SetAmount(){
        Console.Write("What is the amount of the budget? ");
        _amount = double.Parse(Console.ReadLine());
    }

    public double GetAmount(){
        return _amount;
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

    public double GetTotal(){
        double total = 0;
        foreach(Budget budget in budgets){
            total += _amount;
        }
        return total;
    }


}