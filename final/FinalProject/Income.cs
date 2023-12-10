class Income {
    
    private double _amount;

    public List<Income> incomeList = new List<Income>();

    public Income (double amount){
        _amount = amount;
    }

    public Income (){

    }

    public void SetIncome(){
        Console.Write("What is the amount of your income? $");
        _amount = double.Parse(Console.ReadLine());
    }

    public double GetIncome(){
        return _amount;
    }

    public double GetTotal(){
        double total = 0;
        foreach(Income income in incomeList){
            total += income._amount;
        }
        return total;
    }
    

    
}