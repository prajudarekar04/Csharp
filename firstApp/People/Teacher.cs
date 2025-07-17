namespace MyApp.People
{
    public class Teacher
    {
        public string Name { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;

        public void Introduce()
        {
            Console.WriteLine($"Hello, I'm {Name} and I teach {Subject}.");
        }
    }
}