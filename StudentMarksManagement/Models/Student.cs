using System;

namespace StudentMarksManagement.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Marks { get; set; }

        public Student(int id, string name, int marks)
        {
            Id = id;
            Name = name;
            Marks = marks;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Marks: {Marks}";
        }
    }
}