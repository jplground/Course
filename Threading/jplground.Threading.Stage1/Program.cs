
var counter = 0;

System.Console.WriteLine($"Before: Counter is not {counter}");

for(int i = 0; i < 1_000_000; ++i)
{
    counter++;
}

System.Console.WriteLine($"After: Counter is now {counter}");

