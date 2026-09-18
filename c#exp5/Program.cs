using System;
using System.Threading; class Program
{
static void Main(string[] args)
{
Console.WriteLine("=== Multi-Threading Input ==="); 
Console.Write("Enter the number of loops for the background threads: "); 
string input = Console.ReadLine();
if (!int.TryParse(input, out int loopCount) || loopCount <= 0)
{
Console.WriteLine("Invalid input. Please enter a positive integer next time."); 
return;
}
Console.WriteLine($"\n[Main Thread] Starting threads to run {loopCount} times...\n"); 
Thread threadA = new Thread(() => RunWorkerA(loopCount));
Thread threadB = new Thread(() => RunWorkerB(loopCount)); 
threadA.Start();
threadB.Start(); 
threadA.Join(); 
threadB.Join();
Console.WriteLine("\n=== Main Thread: All background tasks finished ===");
}
static void RunWorkerA(int count)
{
for (int i = 1; i <= count; i++)
{
Console.WriteLine($" --> [Thread A] Processing Item {i}/{count}");
 
Thread.Sleep(100);
}
}
static void RunWorkerB(int count)
{
for (int i = 1; i <= count; i++)
{
Console.WriteLine($" ==> [Thread B] Downloading Chunk {i}/{count}"); 
Thread.Sleep(150);
}
}
}
