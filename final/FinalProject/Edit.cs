using System.Collections;

class Edit{
    private int _i;
    private int _iList;

    public void RemoveBudget(List<Budgets> budgets, List<NormalExpenses> expenses){
        _i = 1;
        string response;
        foreach(var budget in budgets){
            Console.Write($"{_i}. ");
            Console.WriteLine(budget.GetName());
            _i++;
        }
        Console.Write("Which budget would you like to remove? ");
        _iList = int.Parse(Console.ReadLine());

        try{
            Console.Clear();
            Console.WriteLine("\t1. Delete Expenses");
            Console.WriteLine("\t2. Create New Budget");
            Console.Write($"What would you like to do with the expenses listed under {budgets[_iList - 1].GetName()}? ");
            response = Console.ReadLine();
            if(response == "1"){
                _i = 0;
                foreach(var expense in expenses){
                    if(expense.GetName() == budgets[_iList -1].GetName()){
                        expenses.RemoveAt(_i);
                    }
                    _i++;
                }
                budgets.RemoveAt(_iList - 1);
            } else if(response == "2"){
                var newBudget = Budgets.CreateBudget();
                budgets.Add(newBudget);
                foreach(var expense in expenses){
                    if(expense.GetName() == budgets[_iList -1].GetName()){
                        expense.SetName(newBudget.GetName());
                    }
                }
                budgets.RemoveAt(_iList - 1);

            } else {
                Console.Clear();
                Console.WriteLine("Invalid Entry.");
                Console.WriteLine("Budget not removed.");
                Thread.Sleep(1000);
            }
            
        } catch (ArgumentOutOfRangeException) {
            Console.Clear();
            Console.WriteLine("Budget not removed. ");
            Console.WriteLine($"Please enter a number within 1-{_i - 1}. ");
            Thread.Sleep(2000);
        } catch (FormatException) {
            Console.Clear();
            Console.WriteLine("New Budget not created. ");
            Console.WriteLine($"Please enter a number. ");
            Thread.Sleep(2000);
        }
    }

    public void ChangeBudget(List<Budgets> budgets, List<NormalExpenses> expenses){
        _i = 1;
        foreach(var budget in budgets){
            Console.Write($"{_i}. ");
            Console.WriteLine(budget.GetName());
            _i++;
        }
        Console.Write("Which budget would you like to change? ");
        try{
            _iList = int.Parse(Console.ReadLine());
            string oldName = budgets[_iList - 1].GetName();
            budgets[_iList-1].SetName();
            budgets[_iList-1].SetAmount();
            foreach(var expense in expenses){
                    if(expense.GetName() == oldName){
                        expense.SetName(budgets[_iList - 1].GetName());
                    }
            }
        } catch (ArgumentOutOfRangeException) {
            Console.Clear();
            Console.WriteLine("Budget not changed. ");
            Console.WriteLine($"Please enter a number within 1-{_i - 1}. ");
            Thread.Sleep(2000);
        } catch (FormatException) {
            Console.Clear();
            Console.WriteLine("Budget not changed. ");
            Console.WriteLine($"Please enter a number.");
            Thread.Sleep(2000);
        }
    }

    public void RemoveNormalExpense(List<NormalExpenses> expenses){
        _i = 1;
        foreach(var expense in expenses){
            Console.Write($"{_i}. ");
            Console.WriteLine($"{expense.GetName()} | ${expense.GetAmount()}");
            _i++;
        }
        Console.Write("Which expense would you like to remove? ");
        _iList = int.Parse(Console.ReadLine());
        expenses.RemoveAt(_iList - 1);
    }

    public void ChangeNormalExpense(List<NormalExpenses> expenses){
        _i = 1;
        foreach(var expense in expenses){
            Console.Write($"{_i}. ");
            Console.WriteLine($"{expense.GetName()} | ${expense.GetAmount()}");
            _i++;
        }
        Console.Write("Which expense would you like to change? ");
        _iList = int.Parse(Console.ReadLine());
        expenses[_iList-1].SetAmount();
    }

    public void RemoveFixedExpense(List<FixedExpenses> expenses){
        _i = 1;
        foreach(var expense in expenses){
            Console.Write($"{_i}. ");
            Console.WriteLine(expense.GetName());
            _i++;
        }
        Console.Write("Which expense would you like to remove? ");
        _iList = int.Parse(Console.ReadLine());
        expenses.RemoveAt(_iList - 1);
    }

    public void ChangeFixedExpense(List<FixedExpenses> expenses){
        _i = 1;
        foreach(var expense in expenses){
            Console.Write($"{_i}. ");
            Console.WriteLine(expense.GetName());
            _i++;
        }
        Console.Write("Which expense would you like to change? ");
        _iList = int.Parse(Console.ReadLine());
        expenses[_iList-1].SetAmount();
        expenses[_iList-1].SetName();
    }

    public void RemoveIncome(List<Income> incomeList){
        _i = 1;
        foreach(var income in incomeList){
            Console.Write($"{_i}. ");
            Console.WriteLine($"{income.GetDate()} | {income.GetIncome()}");
            _i++;
        }
        Console.Write("Which income would you like to remove? ");
        _iList = int.Parse(Console.ReadLine());
        incomeList.RemoveAt(_iList - 1);
    }

    public void ChangeIncome(List<Income> incomeList){
        _i = 1;
        foreach(var income in incomeList){
            Console.Write($"{_i}. ");
            Console.WriteLine($"{income.GetDate()} | {income.GetIncome()}");
            _i++;
        }
        Console.Write("Which income would you like to change? ");
        _iList = int.Parse(Console.ReadLine());
        incomeList[_iList-1].SetIncome();
    }

}
