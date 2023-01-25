
var counter = 0;
var numThreads = 8;
var totalToCompute = 1_000_000;

System.Console.WriteLine($"Before: Counter is not {counter}");

var completed = Enumerable.Range(0, numThreads).Select((i) => new System.Threading.ManualResetEvent(false)).ToArray();
var threads = Enumerable.Range(0, numThreads).Select((i) => new System.Threading.Thread(() => ThreadRunner(i))).ToArray();

threads.All((t) => {
    t.Start();
    return true;
    }
);
// Wait for the thread to complete
WaitHandle.WaitAll(completed);

System.Console.WriteLine($"After: Counter is now {counter}");

// ---------------------------------------------------------------------------------------

void ThreadRunner(int threadId)
{
    for(int i = 0; i < totalToCompute / numThreads; ++i)
    {
        counter++;
    }
    completed[threadId].Set();
    //System.Console.WriteLine($"{threadId} Done");
}
