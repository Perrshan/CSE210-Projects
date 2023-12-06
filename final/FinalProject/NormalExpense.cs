class NormalExpense : Expense {
    
    public NormalExpense(string type, double amount) :base(type, amount){
        
    }

    public NormalExpense(){
        
    }

    public override double GetTotal()
    {
        double total = 0;
        foreach(Expense expense in expenses){
            total += _amount;
        }
        return total;
    }
}