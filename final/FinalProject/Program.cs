using System;
using System.Xml.Schema;

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
            Console.WriteLine("\t5: Check Savings");
            Console.WriteLine("\t6: Edit Entries");
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

        static void DisplayEditList()
        {
            Console.WriteLine("What do you need to edit? ");
            Console.WriteLine("\t1: Budget");
            Console.WriteLine("\t2: Expense");
            Console.WriteLine("\t3: Income");

            Console.Write("Select a choice from the menu: ");
        }

        static void DisplayRemoveOrChange(string type)
        {
            string article = "a";
            if(type == "Income" || type == "Expense"){
                article = "an";
            }
            Console.WriteLine($"Do you need to remove or change {article} {type}? ");
            Console.WriteLine($"\t1. Remove {type}");
            Console.WriteLine($"\t2. Change {type}");

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
                foreach(Budgets budgetCategory in budget.budgets){
                    double total = 0;
                    foreach(NormalExpenses normalExpenses1 in normalExpenses.normalExpensesList){
                        if(budgetCategory.GetName() == normalExpenses1.GetName()){
                            total += normalExpenses1.GetAmount();
                        }
                    }
                    Console.WriteLine($"{budgetCategory.GetName()} Total Budget: ${budgetCategory.GetAmount()}");
                    Console.WriteLine($"Balance: ${budgetCategory.GetAmount() - total}");
                    Console.WriteLine();
                }
                break;
                
                // check savings
                case "5":
                    Console.WriteLine($"Total Income: ${income.GetTotal()}");
                    Console.WriteLine($"Total Expenses: ${normalExpenses.GetTotal() + fixedExpenses.GetTotal()}");
                    Console.WriteLine($"Balance: ${income.GetTotal() - (normalExpenses.GetTotal() + fixedExpenses.GetTotal())}");
                break;

                // Edit Entries
                case "6":
                    DisplayEditList();
                    string editType = Console.ReadLine();
                    switch(editType){
                        // edit budget
                        case "1":
                            DisplayRemoveOrChange("Budget");
                        break;

                        // edit expense
                        case "2":
                            DisplayRemoveOrChange("Expense");
                        break;

                        // edit income
                        case "3":
                            DisplayRemoveOrChange("Income");
                        break;
                    }



                break;
                default:
                    Console.WriteLine("Invalid Entry.");
                break;
                
            }
        }

    }
}
