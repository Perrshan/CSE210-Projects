class Expense {
    protected string _type;
    protected double _amount;

    public Expense (string type, double amount){
        _type = type;
        _amount = amount;
    }

    public double GetAmount(){
        return _amount;
    }

    public string GetTypeString(){
        return _type;
    }



}