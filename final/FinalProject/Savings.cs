class Savings {
    
    public void CalculateSavings(Income income, NormalExpenses normExpenses, FixedExpenses fixExpenses){
        Console.WriteLine($"Total Income: ${income.GetTotal()}");
        Console.WriteLine($"Total Expenses: ${normExpenses.GetTotal() + fixExpenses.GetTotal()}");
        Console.WriteLine($"Balance: ${income.GetTotal() - (normExpenses.GetTotal() + fixExpenses.GetTotal())}");
    }
}