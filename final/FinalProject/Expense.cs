class Expense {
    protected string _name;
    protected double _amount;

    public Expense (string name, double amount){
        _name = name;
        _amount = amount;
    }

    public Expense(string name){
        _name = name;
    }

    public Expense (){

    }

    public double GetAmount(){
        return _amount;
    }

    public void SetName(){
        Console.Write("What is the name of the expense? ");
        _name = Console.ReadLine();
    }

    public virtual void SetAmount(){
        Console.Write("What is the amount of the expense? $");
        _amount = double.Parse(Console.ReadLine());
    }

    public virtual double GetTotal(){
        return 0;
    }

    public virtual void AddToTotal(){

    }

    public string GetName(){
        return _name;
    }

    public virtual string WriteFile(){
        string file = $"NE~{_name}~{_amount}";
        return file;
    }

}