class Income {
    
    private double _amount;
    private DateTime _date;

    public List<Income> incomeList = new List<Income>();

    public Income (double amount, DateTime date){
        _amount = amount;
        _date = date;
    }

    public Income (){

    }

    public void SetIncome(){
        Console.Write("What is the amount of your income? $");
        _amount = double.Parse(Console.ReadLine());
    }

    public void SetDate(){
        _date = DateTime.Now;
    }

    public double GetIncome(){
        return _amount;
    }

    public DateTime GetDate(){
        return _date;
    }

    public double GetTotal(){
        double total = 0;
        foreach(Income income in incomeList){
            total += income._amount;
        }
        return total;
    }
    
    public string WriteFile(){
        string file = $"I~{_amount}~{_date}";
        return file;
    }

    public Income ReadIncome(double amount, DateTime date){
        var income = new Income(amount, date);
        return income;
    }

    
}