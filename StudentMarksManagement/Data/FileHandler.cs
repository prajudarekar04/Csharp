using System;
using System.Collections.Generic;
using System.IO;
using StudentMarksManagement.Models;

namespace StudentMarksManagement.Data
{
    public static class FileHandler
    {
        private static string filePath = "students.txt";

        public static void SaveToFile(List<Student> students)
        {
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                foreach (var s in students)
                {
                    sw.WriteLine($"{s.Id},{s.Name},{s.Marks}");
                }
            }
        }

        public static List<Student> LoadFromFile()
        {
            List<Student> students = new List<Student>();
            if (!File.Exists(filePath))
                return students;

            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                while ((line = sr.ReadLine()) != null)
                {
                    var data = line.Split(',');
                    students.Add(new Student(
                        int.Parse(data[0]),
                        data[1],
                        int.Parse(data[2])
                    ));
                }
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            }
            return students;
        }
    }
}