using System;
namespace InputDelegateEventDemo
{
public delegate void ProcessHandler(string processName, bool isSuccessful); 
public class ProcessManager
{
public event ProcessHandler ProcessFinished; 
public void ExecuteTask(string name, string choice)
{
Console.WriteLine($"\nRunning '{name}'..."); 
System.Threading.Thread.Sleep(1000); // Simulate execution time bool success = choice.Trim().ToLower() == "y"; OnProcessFinished(name, success);
}
protected virtual void OnProcessFinished(string name, bool success)
{
ProcessFinished?.Invoke(name, success);
}
}
public class NotificationSystem
{
public void DisplayResult(string taskName, bool isSuccess)
{
if (isSuccess)
{
Console.ForegroundColor = ConsoleColor.Green; 
Console.WriteLine($"[ALERT] Task '{taskName}' executed flawlessly!");
}
 
else
{
Console.ForegroundColor = ConsoleColor.Red; 
Console.WriteLine($"[ALERT] Task '{taskName}' failed during execution.");
}
Console.ResetColor();
}
}
class Program
{
static void Main(string[] args)
{
ProcessManager manager = new ProcessManager(); 
NotificationSystem notifier = new NotificationSystem(); 
manager.ProcessFinished += notifier.DisplayResult; 
Console.Write("Enter the name of the process/task: "); 
string inputName = Console.ReadLine(); 
Console.Write("Should the process succeed? (y/n): "); 
string inputChoice = Console.ReadLine(); 
manager.ExecuteTask(inputName, inputChoice); 
Console.WriteLine("\nPress Enter to exit."); 
Console.ReadLine();
}
}
}
