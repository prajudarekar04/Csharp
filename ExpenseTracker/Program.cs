using System;
using ExpenseTracker.Models;
using ExpenseTracker.Services;

namespace ExpenseTracker
{
    class Program
    {
        static ExpenseService service = new ExpenseService();

        static void Main(string[] args)
        {
            // Subscribe to ExpenseAdded event
            service.ExpenseAdded += OnExpenseAddedNotification;

            while (true)
            {
                ShowMenu();
                Console.Write("\nEnter your choice: ");
                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": AddExpense(); break;
                    case "2": service.ViewAllExpenses(); break;
                    case "3": SearchExpenses(); break;
                    case "4": UpdateExpense(); break;
                    case "5": DeleteExpense(); break;
                    case "6": SortExpenses(); break;
                    case "7": TotalExpensesInRange(); break;
                    case "8": service.CategorySummary(); break;
                    case "9": service.Top3Expenses(); break;
                    case "10": service.ExportTop3Expenses("Top3ExpensesReport.txt"); break;
                    case "0":
                        Console.WriteLine("Exiting... Goodbye!");
                        return;
                    default:
                        Console.WriteLine("⚠ Invalid choice, please try again.");
                        break;
                }

                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
                Console.Clear();
            }
        }
        static void ShowMenu()
        {
            Console.WriteLine("=== Expense Tracker Menu ===");
            Console.WriteLine("1. Add Expense");
            Console.WriteLine("2. View All Expenses");
            Console.WriteLine("3. Search Expenses");
            Console.WriteLine("4. Update Expense");
            Console.WriteLine("5. Delete Expense");
            Console.WriteLine("6. Sort Expenses");
            Console.WriteLine("7. Total Expenses in Date Range");
            Console.WriteLine("8. Expense Summary by Category");
            Console.WriteLine("9. Top 3 Highest Expenses");
            Console.WriteLine("10. Export Top 3 Expenses Report");
            Console.WriteLine("0. Exit");
        }

        static void AddExpense()
        {
            Console.Write("Enter Date (yyyy-MM-dd): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime date))
            {
                Console.WriteLine("⚠ Invalid date format.");
                return;
            }

            Console.WriteLine("Available categories:");
            foreach (var cat in Enum.GetValues(typeof(Category)))
                Console.WriteLine($"- {cat}");

            Console.Write("Enter Category (choose exactly): ");
            string? categoryInput = Console.ReadLine();
            if (!Enum.TryParse(categoryInput, true, out Category category))
            {
                Console.WriteLine("⚠ Invalid category.");
                return;
            }

            Console.Write("Enter Description: ");
            string? description = Console.ReadLine() ?? "";

            Console.Write("Enter Amount: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal amount) || amount <= 0)
            {
                Console.WriteLine("⚠ Invalid amount.");
                return;
            }

            service.AddExpense(date, category, description.Trim(), amount);
        }

        static void SearchExpenses()
        {
            Console.Write("Enter keyword to search (category or description): ");
            string? keyword = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(keyword))
            {
                Console.WriteLine("⚠ Search keyword cannot be empty.");
                return;
            }

            service.SearchExpenses(keyword.Trim());
        }

        static void UpdateExpense()
        {
            Console.Write("Enter Expense ID to update: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("⚠ Invalid ID.");
                return;
            }

            Console.Write("Enter new Date (yyyy-MM-dd): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime date))
            {
                Console.WriteLine("⚠ Invalid date format.");
                return;
            }

            Console.WriteLine("Available categories:");
            foreach (var cat in Enum.GetValues(typeof(Category)))
                Console.WriteLine($"- {cat}");

            Console.Write("Enter new Category: ");
            string? categoryInput = Console.ReadLine();
            if (!Enum.TryParse(categoryInput, true, out Category category))
            {
                Console.WriteLine("⚠ Invalid category.");
                return;
            }

            Console.Write("Enter new Description: ");
            string? description = Console.ReadLine() ?? "";

            Console.Write("Enter new Amount: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal amount) || amount <= 0)
            {
                Console.WriteLine("⚠ Invalid amount.");
                return;
            }

            service.UpdateExpense(id, date, category, description.Trim(), amount);
        }

        static void DeleteExpense()
        {
            Console.Write("Enter Expense ID to delete: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("⚠ Invalid ID.");
                return;
            }

            service.DeleteExpense(id);
        }

        static void SortExpenses()
        {
            Console.WriteLine("Sort by: 1. Date  2. Amount");
            Console.Write("Enter choice: ");
            string? choice = Console.ReadLine();

            bool sortByDate = choice == "1";

            Console.Write("Sort order: 1. Ascending  2. Descending\nEnter choice: ");
            string? orderChoice = Console.ReadLine();
            bool ascending = orderChoice == "1";

            service.SortExpenses(sortByDate, ascending);
        }

        static void TotalExpensesInRange()
        {
            Console.Write("Enter Start Date (yyyy-MM-dd): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime start))
            {
                Console.WriteLine("⚠ Invalid start date.");
                return;
            }

            Console.Write("Enter End Date (yyyy-MM-dd): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime end))
            {
                Console.WriteLine("⚠ Invalid end date.");
                return;
            }

            if (end < start)
            {
                Console.WriteLine("⚠ End date must be after start date.");
                return;
            }

            service.TotalExpensesInRange(start, end);
        }

        static void OnExpenseAddedNotification(Expense expense)
        {
            Console.WriteLine($"\n🚨 Notification: High expense added! Amount: {expense.Amount:C} in category {expense.Category}");
        }
    }
}