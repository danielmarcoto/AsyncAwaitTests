
int[] items = Enumerable.Range(0, 500001).ToArray();

long total = 0;

for (int i = 0; i < items.Length; i++)
    total = total + items[i];

Console.WriteLine($"The total is: {total}");
Console.ReadLine();