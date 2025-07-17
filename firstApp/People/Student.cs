namespace MyApp.People
{
    public class Student
    {
        public string Name { get; set; } = string.Empty;
        public int Grade { get; set; }

        public void SayHello()
        {
            Console.WriteLine($"Hi, I'm {Name} and I'm in grade {Grade}.");
        }
    }
}