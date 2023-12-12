using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Schema;
using System.IO; 

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
            Console.WriteLine("\t4: Check Budgets");
            Console.WriteLine("\t5: Check Savings");
            Console.WriteLine("\t6: Edit Entries");
            Console.WriteLine("\t7: Save");
            Console.WriteLine("\t8: Load");
            Console.WriteLine("\t9: Quit");

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

        static string DisplayRemoveOrChange(string type)
        {
            string response;
            string article = "a";
            if(type == "Income" || type == "Expense"){
                article = "an";
            }
            Console.WriteLine($"Do you need to remove or change {article} {type}? ");
            Console.WriteLine($"\t1. Remove {type}");
            Console.WriteLine($"\t2. Change {type}");

            Console.Write("Select a choice from the menu: ");
            response = Console.ReadLine();
            return response;
        }

        static void DisplayErrorMessage(){
            Console.Clear();
            Console.WriteLine("Invalid Entry.");
            wait(1000);
        }

        static void wait(int time){
            Thread.Sleep(time);
        }

        bool done = false;
        int i;
        int choice;
        string response;
        string filename;

        // initilize classes
        var normalExpenses = new NormalExpenses();
        var fixedExpenses = new FixedExpenses();
        var edit = new Edit();
        var budget = new Budgets();
        var income = new Income();
        var savings = new Savings();

        while(!done){
            Console.Clear();
            DisplayMenu();
            string menuResponse = Console.ReadLine();

            switch(menuResponse){

                // create budget
                case "1":
                    Console.Clear();
                    try{
                        var newbudget = Budgets.CreateBudget();
                        budget.budgets.Add(newbudget);
                    } catch (FormatException) {
                        Console.Clear();
                        Console.WriteLine("New Budget Deleted");
                        Console.WriteLine("Please enter a number. ");
                        wait(2000);
                    }
                break;

                // create expense
                case "2":
                    Console.Clear();
                    DisplayExpenseType();
                    string expenseType = Console.ReadLine();
                    switch(expenseType){

                        // create normal expense
                        case "1":
                            i = 0;
                            try{

                                // prints out all budgets because normal expenses need to be named the same name as a budget
                                foreach(Budgets budgetName in budget.budgets){
                                    i++;
                                    Console.Write($"\t{i}. ");
                                    Console.WriteLine(budgetName.GetName());
                                }
                                i++;
                                Console.WriteLine($"\t{i}. New Budget");
                                Console.Write($"Please choose one of the budget options that the expense falls under or enter '{i}' to add a new budget: ");
                                choice =int.Parse(Console.ReadLine());
                                if(choice == i){
                                    var newExpenseBudget = Budgets.CreateBudget();
                                    budget.budgets.Add(newExpenseBudget);
                                }
                            } catch (FormatException){
                                Console.Clear();
                                Console.WriteLine("New Budget Deleted. ");
                                Console.WriteLine("Please Enter a number. ");
                                wait(2000);
                                break;
                            }
                            
                            try{
                                var newNormalExpense = new NormalExpenses(budget.budgets[choice-1].GetName());
                                // add new normal expense and adds to list
                                newNormalExpense.SetAmount();
                                normalExpenses.normalExpensesList.Add(newNormalExpense);
                            } catch (FormatException) {
                                Console.Clear();
                                Console.WriteLine("New Expense Deleted. ");
                                Console.WriteLine("Please enter a number. ");
                                wait(2000);
                            } catch (ArgumentOutOfRangeException) {
                                Console.Clear();
                                Console.WriteLine("New Expense not created. ");
                                Console.WriteLine($"Please enter a number within 1-{i}. ");
                                wait(2000);
                            }

                        break;

                        // create fixed expense
                        case "2":
                            i = 0;
                            try{
                                foreach(Expense expense in fixedExpenses.fixedExpensesList){
                                    i++;
                                    Console.Write($"\t{i}. ");
                                    Console.WriteLine(expense.GetName());
                                }
                                i++;
                                Console.WriteLine($"\t{i}. New Fixed Expense");
                                Console.Write($"Please choose one of the fixed expense options or enter '{i}' to add a new fixed expense: ");
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

                            } catch (FormatException) {
                                Console.Clear();
                                Console.WriteLine("New Expense Deleted. ");
                                Console.WriteLine("Please enter a number. ");
                                wait(2000);
                            } catch (ArgumentOutOfRangeException) {
                                Console.Clear();
                                Console.WriteLine("New Expense not created. ");
                                Console.WriteLine($"Please enter a number within 1-{i}. ");
                                wait(2000);
                            }
                            
                        break;

                        default:
                            DisplayErrorMessage();
                        break;
                    }
                break;

                // create income
                case "3":
                    Console.Clear();
                    try{
                        var newIncome = new Income();
                        newIncome.SetIncome();
                        income.incomeList.Add(newIncome);
                    } catch (FormatException){
                        Console.Clear();
                        Console.WriteLine("New Income Deleted");
                        Console.WriteLine("Please enter a number. ");
                        wait(2000);
                    }
                break;

                // check budget
                case "4":
                Console.Clear();
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
                Console.WriteLine();
                Console.WriteLine("Press Enter when ready.");
                Console.ReadLine();
                    
                break;
                
                // check savings
                case "5":
                    Console.Clear();
                    savings.CalculateSavings(income, normalExpenses, fixedExpenses);
                    Console.WriteLine();
                    Console.WriteLine("Press Enter when ready.");
                    Console.ReadLine();
                break;

                // Edit Entries
                case "6":
                    Console.Clear();
                    DisplayEditList();
                    string editType = Console.ReadLine();
                    switch(editType){

                        // edit budget
                        case "1":
                            response = DisplayRemoveOrChange("Budget");

                            if(response == "1"){
                                edit.RemoveBudget(budget.budgets, normalExpenses.normalExpensesList);

                            } else if(response == "2") {
                                edit.ChangeBudget(budget.budgets, normalExpenses.normalExpensesList);
                            } else {
                                DisplayErrorMessage();
                            }
                            
                        break;

                        // edit expense
                        case "2":
                            try{
                                response = DisplayRemoveOrChange("Expense");

                                // remove expense
                                if(response == "1"){
                                    Console.Clear();
                                    DisplayExpenseType();
                                    response = Console.ReadLine();

                                    // normal expense
                                    if(response == "1"){
                                        edit.RemoveNormalExpense(normalExpenses.normalExpensesList);
                                    
                                    // fixed expense
                                    } else if(response == "2") {
                                        edit.RemoveFixedExpense(fixedExpenses.fixedExpensesList);
                                    } else {
                                        DisplayErrorMessage();
                                    }
                                
                                // change expense
                                } else if(response == "2") {
                                    Console.Clear();
                                    DisplayExpenseType();
                                    response = Console.ReadLine();

                                    // normal expense
                                    if(response == "1"){
                                        edit.ChangeNormalExpense(normalExpenses.normalExpensesList);

                                    // fixed expense
                                    } else if(response == "2"){
                                        edit.ChangeFixedExpense(fixedExpenses.fixedExpensesList);
                                    } else {
                                        DisplayErrorMessage();
                                    }
                                } else {
                                    DisplayErrorMessage();
                                }
                            } catch (ArgumentOutOfRangeException) {
                                Console.Clear();
                                Console.WriteLine("Expense  not changed. ");
                                Console.WriteLine("Please enter a number within range. ");
                                wait(2000);
                            } catch (FormatException) {
                                Console.Clear();
                                Console.WriteLine("Expense  not changed. ");
                                Console.WriteLine("Please enter a number. ");
                                wait(2000);
                            }
                        break;

                        // edit income
                        case "3":
                            try{
                                response = DisplayRemoveOrChange("Income");
                                if(response == "1"){
                                    edit.RemoveIncome(income.incomeList);
                                } else if(response == "2") {
                                    edit.ChangeIncome(income.incomeList);
                                } else {
                                    DisplayErrorMessage();
                                }
                            } catch (FormatException) {
                                Console.Clear();
                                Console.WriteLine("Expense  not changed. ");
                                Console.WriteLine("Please enter a number. ");
                                wait(2000);
                            } catch (ArgumentOutOfRangeException) {
                                Console.Clear();
                                Console.WriteLine("Income not changed. ");
                                Console.WriteLine("Please enter a number within range. ");
                                wait(2000);
                            }
                        break;

                        default:
                            DisplayErrorMessage();
                        break;
                    }

                break;

                // save
                case "7":
                    Console.Clear();
                    Console.Write("What is the filename for the file? ");
                    filename = Console.ReadLine() + ".txt";

                    using (StreamWriter outputFile = new StreamWriter(filename))
                    {
                        // You can add text to the file with the WriteLine method
                        foreach(var budgetCategory in budget.budgets){
                            outputFile.WriteLine(budgetCategory.WriteFile());
                        }
                        foreach(var expense in normalExpenses.normalExpensesList){
                            outputFile.WriteLine(expense.WriteFile());
                        }
                        foreach(var expense in fixedExpenses.fixedExpensesList){
                            outputFile.WriteLine(expense.WriteFile());
                        }
                        foreach(var income1 in income.incomeList){
                            outputFile.WriteLine(income1.WriteFile());
                        }
                    }

                    budget.budgets.Clear();
                    normalExpenses.normalExpensesList.Clear();
                    fixedExpenses.fixedExpensesList.Clear();
                    income.incomeList.Clear();
                    
                break;

                // load
                case "8":
                    Console.Clear();
                    Console.Write("What is the filename for the file? ");
                    filename = Console.ReadLine() + ".txt";
                    try{
                        string[] lines = System.IO.File.ReadAllLines(filename);

                        foreach (string line in lines)
                        {
                            string[] parts = line.Split("~");

                            if(parts[0] == "B"){
                                budget.budgets.Add(budget.ReadBudget(parts[1], double.Parse(parts[2])));
                            }
                            else if(parts[0] == "NE"){
                                normalExpenses.normalExpensesList.Add(normalExpenses.ReadNormalExpense(parts[1], double.Parse(parts[2])));
                            }
                            else if(parts[0] == "FE"){
                                fixedExpenses.fixedExpensesList.Add(fixedExpenses.ReadFixedExpense(parts[1], double.Parse(parts[2]), double.Parse(parts[3])));
                            } else {
                                income.incomeList.Add(income.ReadIncome(double.Parse(parts[1]), DateTime.Parse(parts[2])));
                            }
                        }
                    } catch (FileNotFoundException){
                        Console.WriteLine($"Cannot find {filename} .");
                    }

                break;

                case "9":
                    done = true;
                break;


                default:
                    DisplayErrorMessage();
                break;
                
            }
        }

    }
}
