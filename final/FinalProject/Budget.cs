class Budgets {
    private string _name;
    private double _amount;

    public List<Budgets> budgets = new List<Budgets>();

    public Budgets(string name, double amount){
        _name = name;
        _amount = amount;
    }

    public Budgets(){

    }

    public void SetName(){
        Console.Write("What is the name of the budget? ");
        _name = Console.ReadLine();
    }

    public string GetName(){
        return _name;
    }

    public void SetAmount(){
        Console.Write("What is the amount of the budget? $");
        _amount = double.Parse(Console.ReadLine());
    }

    public double GetAmount(){
        return _amount;
    }

    public static Budgets CreateBudget(){
        Console.Write("What is the name of the budget? ");
        string name = Console.ReadLine();
        Console.Write("What is the amount of the budget? $");
        double amount = double.Parse(Console.ReadLine());

        var budget = new Budgets(name, amount); 
        return budget;  
    }

    public double GetTotal(){
        double total = 0;
        foreach(Budgets budget in budgets){
            total += budget._amount;
        }
        return total;
    }

    public string WriteFile(){
        string file = $"B~{_name}~{_amount}";
        return file;
    }

    public Budgets ReadBudget(string name, double amount){
        var budget = new Budgets(name, amount);
        return budget;
    }


}