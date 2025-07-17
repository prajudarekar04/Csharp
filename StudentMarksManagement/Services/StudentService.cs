using System;
using System.Collections.Generic;
using System.Linq;
using StudentMarksManagement.Models;
using StudentMarksManagement.Data;

namespace StudentMarksManagement.Services
{
    public class StudentService
    {
        private List<Student> students;

        public StudentService()
        {
            students = FileHandler.LoadFromFile();
        }

        public void AddStudent(int id, string name, int marks)
        {
            students.Add(new Student(id, name, marks));
            FileHandler.SaveToFile(students);
            Console.WriteLine("✅ Student added successfully!");
        }

        public void ViewAll()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("⚠ No records found.");
                return;
            }
            foreach (var s in students)
            {
                Console.WriteLine(s);
            }
        }

        public void SearchStudent(string keyword)
        {
            var result = students.Where(s => s.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase) 
                                          || s.Marks.ToString() == keyword).ToList();

            if (result.Count == 0)
                Console.WriteLine("⚠ No matching records found.");
            else
                result.ForEach(s => Console.WriteLine(s));
        }

        public void UpdateMarks(int id, int newMarks)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                student.Marks = newMarks;
                FileHandler.SaveToFile(students);
                Console.WriteLine("✅ Marks updated successfully!");
            }
            else
                Console.WriteLine("⚠ Student not found!");
        }

        public void DeleteStudent(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                students.Remove(student);
                FileHandler.SaveToFile(students);
                Console.WriteLine("✅ Student deleted successfully!");
            }
            else
                Console.WriteLine("⚠ Student not found!");
        }

        public void SortStudents(bool ascending = true)
        {
            var sorted = ascending ? students.OrderBy(s => s.Marks).ToList() : students.OrderByDescending(s => s.Marks).ToList();
            sorted.ForEach(s => Console.WriteLine(s));
        }
    }
}