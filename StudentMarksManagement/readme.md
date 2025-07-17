# 🎓 **Student Marks Management System**

[![C#](https://img.shields.io/badge/Language-C%23-blue)](https://docs.microsoft.com/en-us/dotnet/csharp/)
![Status](https://img.shields.io/badge/Status-Completed-success)
![IDE](https://img.shields.io/badge/IDE-Visual%20Studio%20/VS%20Code-purple)

## 📌 **Overview**

The **Student Marks Management System** is a **C# console application** designed to manage student records efficiently.  
It demonstrates **C# OOP concepts, File Handling, Collections, and LINQ**, making it a great learning project for beginners.

---
## ✅ Features

- Add Student Records (ID, Name, Marks)
- View All Students
- Search Students by Name or Marks
- Update Marks by Student ID
- Delete Student by ID
- Sort Students by Marks (Ascending/Descending)
- Top 3 Students Report (using LINQ)
- Automatic File Handling (Data persists in `students.txt`)
- Input Validation & Interactive Menu
---
## 🗂 **Project Structure**

    StudentMarksManagement
    │
    ├── Program.cs                 → Entry point (menu system)
    │
    ├── Models
    │   └── Student.cs             → Student class (properties, constructor, ToString)
    │
    ├── Services
    │   └── StudentService.cs      → Core logic (CRUD + Sort + Top 3)
    │
    └── Data
        └── FileHandler.cs         → File I/O (load/save student records)
---
## ⚙ **Tech Stack**

- **Language**: C# (.NET 6 or later)  
- **Concepts**: OOP, Collections (`List<T>`), File I/O, LINQ  
- **Tools**: VS Code / Visual Studio
---
## ▶ **How to Run**

1. **Clone the Repository:**

       git clone https://github.com/your-username/StudentMarksManagement.git
       cd StudentMarksManagement

2. **Run the Project:**

       dotnet run

3. **Follow the Menu Options:**

       📌 STUDENT MARKS MANAGEMENT
       1. Add Student
       2. View All
       3. Search
       4. Update Marks
       5. Delete Student
       6. Sort Students
       7. Top 3 Students Report
       8. Exit

4. **Check Saved Data:**

       A file named 'students.txt' will be created automatically to store student records.
---

## 🚀 **Future Enhancements**

- Export Top 3 Students Report to a separate file.  
- Automatic Grade/Percentage calculation.  
- Convert into a **Web Application (ASP.NET Core)**.
---
