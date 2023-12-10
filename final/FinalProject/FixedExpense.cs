class FixedExpenses : Expense {

    public double _total;
    public List<FixedExpenses> fixedExpensesList = new List<FixedExpenses>();

    public FixedExpenses(string name, double amount) :base(name, amount){
        _total = amount;
    }

    public FixedExpenses(){
        
    }

    public override void SetAmount()
    {
        Console.Write("What is the amount of the expense? $");
        double value = double.Parse(Console.ReadLine());
        _amount = value;
        _total = value;
    }

    public override void AddToTotal(){
        _total += _amount;
    }

    public override double GetTotal()
    {
        double total = 0;
        foreach(FixedExpenses expense in fixedExpensesList){
            total += expense._total;
        }
        return total;
    }

}