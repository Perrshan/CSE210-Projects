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

        // Budgeting Program/ banking program
        // Enter in a budget
        // Also enter the income that has been earned and show how much money was saved for that pay period. It will ask if you've paid tithing.
        // Expense/ income.
        // description, amount, 
        // divide the budget into the seperate categories to see which subbudgets went over the amount they should have.Be able to adjust individual budgets incase it is failed frequently.
        // Display total amount of money spent compared to the budget
        // Display amounts of money per category of spending
        // Writes and Reads data into the system.
        // Divide the data by month and year and have a way to compare previous months data to current data.
        // Be able to edit previous datas numbers incase there were any mistakes.
        // Grocery, Dates, Gas, Tithing, Investments(School), Medical, Pet, Miscelenous
        // Include which day it was purchased

        double totalExpenses = 0;
        double totalBudget = 0;
        double totalIncome = 0;
        bool done = false;

        var budgets = new List<Budget>();
        var expenses = new List<Expense>();
        var income = new List<Income>();
        var budgetThing = new Budget();

        var expense1 = new NormalExpense("gas", 80);
        var expense2 = new FixedExpense("tithing", 400);

        var budget1 = new Budget("ur mom", 100);
        var budget2 = new Budget("ur mom", 100);

        var Income1 = new Income(1000);
        var Income2 = new Income(980);

        expenses.Add(expense1);
        expenses.Add(expense2);

        budgets.Add(budget1);
        budgets.Add(budget2);

        income.Add(Income1);
        income.Add(Income2);

        while(!done){
            foreach(Expense expense in expenses){
                totalExpenses += expense.GetAmount();
            }

            foreach(Budget budget in budgets){
                totalBudget += budget.GetBudget();
            }

            foreach(Income incomeThing in income){
                totalIncome += incomeThing.GetIncome();
            }

            budgetThing.CheckBudget(totalExpenses > totalBudget);

            double leftOver = totalIncome - totalExpenses;
            
            Console.WriteLine(totalExpenses);
            DisplayMenu();
            string menuResponse = Console.ReadLine();

            switch(menuResponse){
                case "1":
                    var budget = Budget.CreateBudget();
                    budgets.Add(budget);
                break;
                case "2":
                    DisplayExpenseType();
                    string expenseType = Console.ReadLine();
                    switch(expenseType){
                        case "1":
                            // create a new normal expense
                        break;
                        case "2":
                            int i = 0;
                            foreach(Expense fixedExpense in expenses){
                                if(fixedExpense.ToString() == "FixedExpense"){
                                    i++;
                                    Console.Write($"{i}. ");
                                    Console.WriteLine(fixedExpense.GetTypeString());
                                }
                            }
                            i++;
                            Console.WriteLine($"{i}. New Fixed Expense");

                            Console.WriteLine($"Please choose one of the fixed expense options or enter '{i}' to add a new fixed expense. ");
                            int choice = int.Parse(Console.ReadLine());
                            if(choice == i){
                                // create new fixed value
                            } else {
                                foreach(Expense fixedExpense in expenses){
                                    int j = 0;
                                    if(fixedExpense.ToString() == "FixedExpense"){
                                        j++;
                                        if(j == i){
                                            totalExpenses += fixedExpense.GetAmount();
                                        }
                                    }
                                }
                            }
                        break;
                        default:
                            Console.WriteLine("Invalid Entry");
                        break;
                    }
                break;
                // record income
                case "3":
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
