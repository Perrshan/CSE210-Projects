class NormalExpenses : Expense {

    public List<NormalExpenses> normalExpensesList = new List<NormalExpenses>();
    
    public NormalExpenses(string name) :base(name){
        
    }

    public NormalExpenses(){
        
    }

    public override double GetTotal()
    {
        double total = 0;
        foreach(NormalExpenses expense in normalExpensesList){
            total += expense._amount;
        }
        return total;
    }
}