using System;

namespace ExpenseTracker.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Category Category { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal Amount { get; set; }

        public Expense() { }

        public Expense(int id, DateTime date, Category category, string description, decimal amount)
        {
            Id = id;
            Date = date;
            Category = category;
            Description = description;
            Amount = amount;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Date: {Date:yyyy-MM-dd}, Category: {Category}, Description: {Description}, Amount: {Amount:C}";
        }
    }
}