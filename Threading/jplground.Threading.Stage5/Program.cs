
var counter = 0;
var numThreads = 8;
var totalToCompute = 1_000_000;

System.Console.WriteLine($"Before: Counter is not {counter}");

var completed = new System.Threading.ManualResetEvent[numThreads];
for(int i = 0; i < numThreads; ++i)
{
    var evt = new System.Threading.ManualResetEvent(false);
    completed[i] = evt;
    ThreadPool.QueueUserWorkItem((_) => ThreadRunner(evt));
}

// Wait for the thread to complete
WaitHandle.WaitAll(completed);

System.Console.WriteLine($"After: Counter is now {counter}");

// ---------------------------------------------------------------------------------------

void ThreadRunner(ManualResetEvent evt)
{
    for(int i = 0; i < totalToCompute / numThreads; ++i)
    {
        counter++;
    }
    evt.Set();
    //System.Console.WriteLine($"{threadId} Done");
}
