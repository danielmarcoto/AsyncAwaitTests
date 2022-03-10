namespace DemoTwo;
class DemoTwo04
{
    private static object _sharedTotalLock = new();
    private static long _sharedTotal;
    private static readonly int[] Items = Enumerable.Range(0, 500001).ToArray();

    static void AddRangeOfValues(int start, int end)
    {
        long subTotal = 0;

        while (start < end)
        {
            subTotal += Items[start];
            start++;
        }

		// #1
        Monitor.Enter(_sharedTotalLock);
        _sharedTotal += subTotal;
        Monitor.Exit(_sharedTotalLock);
    }

    static void Main04(string[] args)
    {
        List<Task> tasks = new List<Task>();

        int rangeSize = 1000;
        int rangeStart = 0;

        while (rangeStart < Items.Length)
        {
            int rangedEnd = rangeStart + rangeSize;

            if (rangedEnd > Items.Length)
                rangedEnd = Items.Length;

            // create local copies of the parameters
            int rs = rangeStart;
            int re = rangedEnd;

            tasks.Add(Task.Run(() => AddRangeOfValues(rs, re)));
            rangeStart = rangedEnd;
        }

        Task.WaitAll(tasks.ToArray());

        Console.WriteLine($"The local is: {_sharedTotal}");
        Console.ReadKey();
    }
}