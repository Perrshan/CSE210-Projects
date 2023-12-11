class NormalExpenses : Expense {

    public List<NormalExpenses> normalExpensesList = new List<NormalExpenses>();
    
    public NormalExpenses(string name, double amount) :base(name, amount){
        
    }

    public NormalExpenses(string name) :base(name){
        
    }

    public NormalExpenses(){
        
    }

    public void SetName(string name){
        _name = name;
    }

    public override double GetTotal()
    {
        double total = 0;
        foreach(NormalExpenses expense in normalExpensesList){
            total += expense._amount;
        }
        return total;
    }

    public NormalExpenses ReadNormalExpense(string name, double amount){
        var expense = new NormalExpenses(name, amount);
        return expense;
    }
}