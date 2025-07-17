# 💰 **Expense Tracker**

[![C#](https://img.shields.io/badge/Language-C%23-blue)](https://docs.microsoft.com/en-us/dotnet/csharp/)
![Status](https://img.shields.io/badge/Status-Completed-success)
![IDE](https://img.shields.io/badge/IDE-Visual%20Studio%20/VS%20Code-purple)

---
## 📌 **Overview**

The **Expense Tracker** is a **C# console-based application** designed to manage daily expenses efficiently.  
It demonstrates **C# OOP concepts, File Handling, Collections, LINQ, Delegates, and Events** while keeping the console interaction intuitive and user-friendly.

You can:  
- Record daily expenses with date, category, description, and amount.  
- Search, sort, and analyze expenses.  
- Automatically save data to a file and generate summary reports.  
- Receive instant notifications for high-value expenses using **events**.
---
## ✅ **Features**

- Add, View, Update, and Delete Expenses  
- Search Expenses by **Category** or **Description**  
- Sort Expenses by **Date** or **Amount** (Ascending/Descending)  
- View Total Expenses within a **Date Range**  
- Automatic **File Handling** (data persists in `expenses.txt`)  
- **Enums** for Predefined Categories (Food, Transport, Shopping, etc.)  
- **Event Notification** for High-Value Expenses  
- Expense Summary by **Category** (using LINQ)  
- Top 3 Highest Expenses Report (View & Export to `Top3ExpensesReport.txt`)
---
## 🗂 **Project Structure**

    ExpenseTracker  
    │  
    ├── **Program.cs** → Entry point (Menu system & Event subscription)  
    │  
    ├── **Models**  
    │   ├── Expense.cs → Expense model (Properties, Constructor, ToString)  
    │   └── Category.cs → Enum for predefined categories  
    │  
    ├── **Services**  
    │   └── ExpenseService.cs → Core logic (CRUD, Search, Sort, Reports, Events)  
    │  
    └── **Data**  
        └── FileHandler.cs → File I/O (Save/Load expenses & reports)
---
## ⚙ **Tech Stack**

- **Language**: C# (.NET 6 or later)  
- **Concepts Used**: OOP, Collections (`List<T>`), File Handling, LINQ, Delegates & Events, Enums  
- **Tools & IDEs**: Visual Studio / VS Code  
- **Data Storage**: Text file (`expenses.txt`) for persistent data
---
## ▶ **How to Run**

1. **Clone the Repository:**

       git clone https://github.com/prajudarekar04/ExpenseTracker.git
       cd ExpenseTracker

2. **Run the Project:**

       dotnet run

3. **Follow the Menu Options:**

       === Expense Tracker Menu ===
       1. Add Expense
       2. View All Expenses
       3. Search Expenses
       4. Update Expense
       5. Delete Expense
       6. Sort Expenses
       7. Total Expenses in Date Range
       8. Expense Summary by Category
       9. Top 3 Highest Expenses
       10. Export Top 3 Expenses Report
       0. Exit

4. **Data Storage:**

       All expenses are saved automatically in 'expenses.txt'.
       Exported Top 3 report is saved as 'Top3ExpensesReport.txt'.
---
## 🚀 **Future Enhancements**

- Add Monthly & Yearly Expense Graphs (using console charts or UI libraries)  
- Auto-Backup & Restore of Expense Data  
- Multi-User Support with Separate Files  
- Convert into a **Desktop** or **Web Application (ASP.NET Core)**  
- Export Reports to **PDF/Excel**
---
