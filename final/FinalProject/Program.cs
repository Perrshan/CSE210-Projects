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

        bool done = false;
        int i;

        var normalExpense = new NormalExpense();
        var fixedExpense = new FixedExpense();
        var budget = new Budget();
        var income = new Income();

        /*
        normalExpense.SetName();
        normalExpense.SetAmount();
        normalExpense.expenses.Add(normalExpense);
    
        fixedExpense.SetName();
        fixedExpense.SetAmount();
        fixedExpense.expenses.Add(fixedExpense);

        budget.SetName();
        budget.SetAmount();
        budget.budgets.Add(budget);

        income.SetIncome();
        income.incomeList.Add(income);

        Console.WriteLine(normalExpense.GetTotal());
        Console.WriteLine(fixedExpense.GetTotal());
        Console.WriteLine(budget.GetTotal());
        Console.WriteLine(income.GetTotal());

        */

        while(!done){
            Console.WriteLine(fixedExpense.GetTotal());
            
            DisplayMenu();
            string menuResponse = Console.ReadLine();

            switch(menuResponse){
                case "1":
                    budget = Budget.CreateBudget();
                    budget.budgets.Add(budget);
                break;
                case "2":
                    DisplayExpenseType();
                    string expenseType = Console.ReadLine();
                    switch(expenseType){
                        case "1":
                            // create a new normal expense
                        break;
                        case "2":

                            i = 0;
                            foreach(Expense expense in fixedExpense.expenses){
                                i++;
                                Console.Write($"{i}. ");
                                Console.WriteLine(fixedExpense.GetName());
                            }
                            i++;
                            Console.WriteLine($"{i}. New Fixed Expense");

                            Console.WriteLine($"Please choose one of the fixed expense options or enter '{i}' to add a new fixed expense. ");
                            int choice = int.Parse(Console.ReadLine());
                            if(choice == i){
                                // add new fixed response and adds to list
                                fixedExpense.SetName();
                                fixedExpense.SetAmount();
                                fixedExpense.expenses.Add(fixedExpense);

                            } else {
                                // increase the total times that the fixed amount has been used.
                                fixedExpense.expenses[choice-1].AddToTotal();
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
