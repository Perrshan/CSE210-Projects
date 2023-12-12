abstract class Expense {
    protected string name;
    protected double amount;

    public Expense (string nameStr, double amountDb){
        name = nameStr;
        amount = amountDb;
    }

    public Expense(string nameStr){
        name = nameStr;
    }

    public Expense (){

    }

    public double GetAmount(){
        return amount;
    }

    public void SetName(){
        Console.Write("What is the name of the expense? ");
        name = Console.ReadLine();
    }

    public virtual void SetAmount(){
        Console.Write("What is the amount of the expense? $");
        amount = double.Parse(Console.ReadLine());
    }

    public abstract double GetTotal();

    public string GetName(){
        return name;
    }

    public virtual string WriteFile(){
        string file = $"NE~{name}~{amount}";
        return file;
    }

}