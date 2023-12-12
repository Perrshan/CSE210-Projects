class NormalExpenses : Expense {

    public List<NormalExpenses> normalExpensesList = new List<NormalExpenses>();
    
    private NormalExpenses(string name, double amount) :base(name, amount){
        
    }

    public NormalExpenses(string name) :base(name){
        
    }

    public NormalExpenses(){
        
    }

    public void SetName(string nameStr){
        name = nameStr;
    }

    public override double GetTotal()
    {
        double total = 0;
        foreach(NormalExpenses expense in normalExpensesList){
            total += expense.amount;
        }
        return total;
    }

    public NormalExpenses ReadNormalExpense(string name, double amount){
        var expense = new NormalExpenses(name, amount);
        return expense;
    }
}