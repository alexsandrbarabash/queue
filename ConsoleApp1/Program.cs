using queue;


namespace MyApp // Note: actual namespace depends on the project name.
{
    class Program
    {
        static void Main(string[] args)
        {
            var example = new queue.Queue<int>();
            var main = new MainService();
            var secondService = new SecondService();
            example.Added += main.OnAdded;
            example.Added += secondService.OnAdded;
            example.Enqueue(3);
            example.Enqueue(2);
            example.Enqueue(1);
            Console.WriteLine(example.Dequeue());
            Console.WriteLine(example.Dequeue());
            Console.WriteLine(example.Dequeue());
            Console.WriteLine(example.Dequeue());
        }
    }

    public class MainService
    {
        public void OnAdded(int value)
        {
            Console.WriteLine("Add 1");
            Console.WriteLine(value);
        }
    }
    
    public class SecondService
    {
        public void OnAdded(int value)
        {
            Console.WriteLine("Add 2");
            Console.WriteLine(value);
        }
    }
}