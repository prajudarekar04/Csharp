// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");
using MyApp.People;

class Program
{
    static void Main()
    {
        Student student = new Student { Name = "Alice", Grade = 10 };
        Teacher teacher = new Teacher { Name = "Mr. Smith", Subject = "Math" };

        student.SayHello();
        teacher.Introduce();
    }
}