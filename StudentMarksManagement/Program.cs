using System;
using StudentMarksManagement.Services;

class Program
{
    static void Main()
    {
        StudentService service = new StudentService();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n📌 STUDENT MARKS MANAGEMENT");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. View All");
            Console.WriteLine("3. Search");
            Console.WriteLine("4. Update Marks");
            Console.WriteLine("5. Delete Student");
            Console.WriteLine("6. Sort Students");
            Console.WriteLine("7. Top 3 Students Report");
            Console.WriteLine("8. Exit");
            Console.Write("Enter your choice: ");

            string? choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    int id = GetValidInt("Enter ID: ");
                    string name = GetValidString("Enter Name: ");
                    int marks = GetValidInt("Enter Marks: ");
                    service.AddStudent(id, name, marks);
                    break;

                case "2":
                    service.ViewAll();
                    break;

                case "3":
                    string keyword = GetValidString("Enter Name or Marks to search: ");
                    service.SearchStudent(keyword);
                    break;

                case "4":
                    int uid = GetValidInt("Enter ID to update: ");
                    int newMarks = GetValidInt("Enter New Marks: ");
                    service.UpdateMarks(uid, newMarks);
                    break;

                case "5":
                    int delId = GetValidInt("Enter ID to delete: ");
                    service.DeleteStudent(delId);
                    break;

                case "6":
                    Console.Write("Sort Ascending? (y/n): ");
                    string? sortChoice = Console.ReadLine();
                    bool asc = sortChoice != null && sortChoice.ToLower() == "y";
                    service.SortStudents(asc);
                    break;

                case "7":
                    service.Top3Students();
                    break;

                case "8":
                    running = false;
                    break;

                default:
                    Console.WriteLine("⚠ Invalid choice!");
                    break;
            }
        }

        Console.WriteLine("👋 Exiting... Goodbye!");
    }

    // ✅ Helper functions for validation
    static int GetValidInt(string message)
    {
        int value;
        while (true)
        {
            Console.Write(message);
            string? input = Console.ReadLine();
            if (int.TryParse(input, out value))
                return value;
            Console.WriteLine("⚠ Please enter a valid number!");
        }
    }

    static string GetValidString(string message)
    {
        string? input;
        do
        {
            Console.Write(message);
            input = Console.ReadLine();
        } while (string.IsNullOrWhiteSpace(input));
        return input;
    }
}
