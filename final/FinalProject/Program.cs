using System;

class Program
{
    static void Main(string[] args)
    {
        static void DisplayMenu()
        {
            Console.WriteLine("Menu Options:");
            Console.WriteLine("\t1: Create Budget");
            Console.WriteLine("\t2: Record Expense");
            Console.WriteLine("\t3: Record Income");
            Console.WriteLine("\t4: Check Budget");
            Console.WriteLine("\t5: Load Goals");
            Console.WriteLine("\t6: Record Event");
            Console.WriteLine("\t7: Quit");

            Console.Write("Select a choice from the menu: ");
        }

        static void DisplayExpenseType()
        {
            Console.WriteLine("Is the expense Fixed or Normal?");
            Console.WriteLine("\t1: Normal Expense");
            Console.WriteLine("\t2: Fixed Expense");

            Console.Write("Select a choice from the menu: ");
        }

        bool done = false;
        int i;
        int choice;

        var normalExpenses = new NormalExpenses();
        var fixedExpenses = new FixedExpenses();
        var budget = new Budgets();
        var income = new Income();

        while(!done){
            Console.WriteLine(fixedExpenses.GetTotal() + normalExpenses.GetTotal());
            Console.WriteLine(income.GetTotal());
            Console.WriteLine(budget.GetTotal());
            DisplayMenu();
            string menuResponse = Console.ReadLine();

            switch(menuResponse){
                case "1":
                    var newbudget = Budgets.CreateBudget();
                    budget.budgets.Add(newbudget);
                break;
                case "2":
                    DisplayExpenseType();
                    string expenseType = Console.ReadLine();
                    switch(expenseType){
                        case "1":
                            i = 0;
                            foreach(Budgets budgetName in budget.budgets){
                                i++;
                                Console.Write($"\t{i}. ");
                                Console.WriteLine(budgetName.GetName());
                            }
                            i++;
                            Console.WriteLine($"\t{i}. New Budget");
                            Console.WriteLine($"Please choose one of the budget options that the expense falls under or enter '{i}' to add a new budget. ");
                            choice =int.Parse(Console.ReadLine());
                            if(choice == i){
                                var newExpenseBudget = Budgets.CreateBudget();
                                budget.budgets.Add(newExpenseBudget);
                            }
                            Console.WriteLine(choice-1);
                            var newNormalExpense = new NormalExpenses(budget.budgets[choice-1].GetName());
                            // add new normal expense and adds to list
                            newNormalExpense.SetAmount();
                            normalExpenses.normalExpensesList.Add(newNormalExpense);

                        break;
                        case "2":

                            i = 0;
                            foreach(Expense expense in fixedExpenses.fixedExpensesList){
                                i++;
                                Console.Write($"\t{i}. ");
                                Console.WriteLine(expense.GetName());
                            }
                            i++;
                            Console.WriteLine($"\t{i}. New Fixed Expense");

                            Console.WriteLine($"Please choose one of the fixed expense options or enter '{i}' to add a new fixed expense. ");
                            choice = int.Parse(Console.ReadLine());
                            if(choice == i){
                                var newFixedExpense = new FixedExpenses();
                                // add new fixed expense and adds to list
                                newFixedExpense.SetName();
                                newFixedExpense.SetAmount();
                                fixedExpenses.fixedExpensesList.Add(newFixedExpense);

                            } else {
                                // increase the total times that the fixed amount has been used.
                                fixedExpenses.fixedExpensesList[choice-1].AddToTotal();
                            }
                        break;

                        default:
                            Console.WriteLine("Invalid Entry");
                        break;
                    }
                break;

                // record income
                case "3":
                    var newIncome = new Income();
                    newIncome.SetIncome();
                    income.incomeList.Add(newIncome);
                break;
                // check budget
                case "4":
                break;
                
                case "5":
                break;
                default:
                    Console.WriteLine("Invalid Entry.");
                break;
                
            }
        }

    }
}
