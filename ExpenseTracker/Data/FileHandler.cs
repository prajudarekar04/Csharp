using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using ExpenseTracker.Models;

namespace ExpenseTracker.Data
{
    public static class FileHandler
    {
        private static readonly string filePath = "expenses.txt";

        // Save all expenses to file
        public static void SaveToFile(List<Expense> expenses)
        {
            using StreamWriter writer = new StreamWriter(filePath);
            foreach (var expense in expenses)
            {
                // Format: Id|yyyy-MM-dd|Category|Description|Amount
                string line = $"{expense.Id}|{expense.Date:yyyy-MM-dd}|{expense.Category}|{expense.Description}|{expense.Amount}";
                writer.WriteLine(line);
            }
        }

        // Load all expenses from file
        public static List<Expense> LoadFromFile()
        {
            var expenses = new List<Expense>();

            if (!File.Exists(filePath))
                return expenses;

            foreach (var line in File.ReadLines(filePath))
            {
                var parts = line.Split('|');
                if (parts.Length != 5)
                    continue;

                if (!int.TryParse(parts[0], out int id))
                    continue;

                if (!DateTime.TryParseExact(parts[1], "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
                    continue;

                if (!Enum.TryParse(parts[2], out Category category))
                    continue;

                string description = parts[3];

                if (!decimal.TryParse(parts[4], out decimal amount))
                    continue;

                expenses.Add(new Expense(id, date, category, description, amount));
            }

            return expenses;
        }
        
        public static void SaveReport(string fileName, List<string> lines)
        {
            File.WriteAllLines(fileName, lines);
        }
    }
}
// FileHandler.cs for saving/loading expenses!  This handles reading/writing expenses in a simple text file using | as delimiter.