
var counter = 0;

System.Console.WriteLine($"Before: Counter is not {counter}");

var thread = new System.Threading.Thread(ThreadRunner);

thread.Start();

System.Console.WriteLine($"After: Counter is now {counter}");

// ---------------------------------------------------------------------------------------

void ThreadRunner()
{
    for(int i = 0; i < 1_000_000; ++i)
    {
        counter++;
    }
}

