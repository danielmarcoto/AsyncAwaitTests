namespace DemoThree;

class ProgramDeadLock
{
    private static object lockOne = new();
    private static object lockTwo = new();

    static void MethodOne()
    {
        lock (lockOne)
        {
            Console.WriteLine("Method 1 got lock 1");
            Console.WriteLine("Method 1 waiting for lock 2");
            lock (lockTwo)
            {
                Console.WriteLine("Method 1 got lock 2");
            }
            Console.WriteLine("Method 1 released lock 2");
        }
        Console.WriteLine("Method 1 released lock 1");
    }

    static void MethodTwo()
    {
        lock (lockTwo)
        {
            Console.WriteLine("Method 2 got lock 2");
            Console.WriteLine("Method 2 waiting for lock 1");
            lock (lockOne)
            {
                Console.WriteLine("Method 2 got lock 1");
            }
            Console.WriteLine("Method 2 released lock 1");
        }
        Console.WriteLine("Method 2 released lock 2");
    }

    static void MainDeadLock(string[] args)
    {
        List<Task> tasks = new List<Task>
        {
            Task.Run(() => MethodOne()),
            Task.Run(() => MethodTwo())
        };
        Task.WaitAll(tasks.ToArray());
        Console.WriteLine("Methods complete. Press any key to exit");
        Console.ReadKey();
    }
}