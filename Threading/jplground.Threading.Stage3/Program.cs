
var counter = 0;

System.Console.WriteLine($"Before: Counter is not {counter}");

var completed = new System.Threading.ManualResetEvent(false);
var thread = new System.Threading.Thread(ThreadRunner);

thread.Start();
// Wait for the thread to complete
completed.WaitOne();

System.Console.WriteLine($"After: Counter is now {counter}");

// ---------------------------------------------------------------------------------------

void ThreadRunner()
{
    for(int i = 0; i < 1_000_000; ++i)
    {
        counter++;
    }
    completed.Set();
}
