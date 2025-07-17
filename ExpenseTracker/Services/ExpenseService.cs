using System;
using System.Collections.Generic;
using System.Linq;
using ExpenseTracker.Data;
using ExpenseTracker.Models;

namespace ExpenseTracker.Services
{
    public class ExpenseService
    {
        private List<Expense> expenses;

        public delegate void ExpenseAddedHandler(Expense expense);
        public event ExpenseAddedHandler? ExpenseAdded;

        private const decimal NotificationThreshold = 1000m; // example threshold

        public ExpenseService()
        {
            expenses = FileHandler.LoadFromFile();
        }

        // Add new expense
        public void AddExpense(DateTime date, Category category, string description, decimal amount)
        {
            int newId = expenses.Any() ? expenses.Max(e => e.Id) + 1 : 1;
            var expense = new Expense(newId, date, category, description, amount);
            expenses.Add(expense);
            FileHandler.SaveToFile(expenses);
            Console.WriteLine("✅ Expense added successfully!");

            // Trigger event if amount > threshold
            if (amount > NotificationThreshold)
            {
                ExpenseAdded?.Invoke(expense);
            }
        }

        // View all expenses
        public void ViewAllExpenses()
        {
            if (!expenses.Any())
            {
                Console.WriteLine("⚠ No expenses recorded yet.");
                return;
            }

            Console.WriteLine("\n📋 All Expenses:");
            foreach (var exp in expenses.OrderBy(e => e.Date))
                Console.WriteLine(exp);
        }

        // Search by category or description keyword (case insensitive)
        public void SearchExpenses(string keyword)
        {
            var results = expenses.Where(e =>
                e.Category.ToString().Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                e.Description.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                .OrderBy(e => e.Date)
                .ToList();

            if (!results.Any())
            {
                Console.WriteLine($"⚠ No expenses found matching '{keyword}'.");
                return;
            }

            Console.WriteLine($"\n🔍 Search results for '{keyword}':");
            foreach (var exp in results)
                Console.WriteLine(exp);
        }

        // Update an expense by ID
        public void UpdateExpense(int id, DateTime date, Category category, string description, decimal amount)
        {
            var expense = expenses.FirstOrDefault(e => e.Id == id);
            if (expense == null)
            {
                Console.WriteLine($"⚠ Expense with ID {id} not found.");
                return;
            }

            expense.Date = date;
            expense.Category = category;
            expense.Description = description;
            expense.Amount = amount;

            FileHandler.SaveToFile(expenses);
            Console.WriteLine("✅ Expense updated successfully!");
        }

        // Delete expense by ID
        public void DeleteExpense(int id)
        {
            var expense = expenses.FirstOrDefault(e => e.Id == id);
            if (expense == null)
            {
                Console.WriteLine($"⚠ Expense with ID {id} not found.");
                return;
            }

            expenses.Remove(expense);
            FileHandler.SaveToFile(expenses);
            Console.WriteLine("✅ Expense deleted successfully!");
        }

        // Sort expenses by date or amount
        public void SortExpenses(bool sortByDate = true, bool ascending = true)
        {
            IEnumerable<Expense> sorted;

            if (sortByDate)
            {
                sorted = ascending ? expenses.OrderBy(e => e.Date) : expenses.OrderByDescending(e => e.Date);
            }
            else
            {
                sorted = ascending ? expenses.OrderBy(e => e.Amount) : expenses.OrderByDescending(e => e.Amount);
            }

            Console.WriteLine("\n📊 Sorted Expenses:");
            foreach (var exp in sorted)
                Console.WriteLine(exp);
        }

        // Total expenses in date range
        public void TotalExpensesInRange(DateTime start, DateTime end)
        {
            var total = expenses.Where(e => e.Date >= start && e.Date <= end).Sum(e => e.Amount);
            Console.WriteLine($"\n💰 Total expenses from {start:yyyy-MM-dd} to {end:yyyy-MM-dd}: {total:C}");
        }

        // Category-wise expense summary
        public void CategorySummary()
        {
            var summary = expenses.GroupBy(e => e.Category)
                .Select(g => new { Category = g.Key, Total = g.Sum(e => e.Amount) })
                .OrderByDescending(s => s.Total);

            Console.WriteLine("\n📂 Expense Summary by Category:");
            foreach (var item in summary)
            {
                Console.WriteLine($"{item.Category}: {item.Total:C}");
            }
        }

        // Top 3 highest expenses
        public void Top3Expenses()
        {
            var top3 = expenses.OrderByDescending(e => e.Amount).Take(3).ToList();

            if (!top3.Any())
            {
                Console.WriteLine("⚠ No expenses recorded yet.");
                return;
            }

            Console.WriteLine("\n🏆 Top 3 Highest Expenses:");
            foreach (var exp in top3)
                Console.WriteLine(exp);
        }

        public void ExportTop3Expenses(string fileName)
        {
            var top3 = expenses.OrderByDescending(e => e.Amount).Take(3).ToList();
            var lines = new List<string> { "Top 3 Highest Expenses:" };
            lines.AddRange(top3.Select(e => e.ToString()));

            FileHandler.SaveReport(fileName, lines);
            Console.WriteLine($"✅ Report exported to {fileName}");
        }
    }
}