Action<object> action = (object obj) =>
{
    Console.WriteLine("Task={0}, obj={1}, Thread={2}",
        Task.CurrentId, obj,
        Thread.CurrentThread.ManagedThreadId);
};

Task t1 = new Task(action, "alpha");

Task t2 = Task.Factory.StartNew(action, "beta");

// Launch t1 
t1.Start();

Console.WriteLine("t1 has been launched. (Main Thread={0})",
    Thread.CurrentThread.ManagedThreadId);
// Wait for the task to finish.
t1.Wait();

// Construct a started task using Task.Run.
string taskData = "delta";
Task t3 = Task.Run(() => {
    Console.WriteLine("Task={0}, obj={1}, Thread={2}",
        Task.CurrentId, taskData,
        Thread.CurrentThread.ManagedThreadId);
});
// Wait for the task to finish.

// Construct an unstarted task
Task t4 = new Task(action, "gamma");
// Run it synchronously
t4.RunSynchronously();
// Although the task was run synchronously, it is a good practice
// to wait for it in the event exceptions were thrown by the task.
t4.Wait();
t2.Wait();
t3.Wait();