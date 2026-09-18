using System;
namespace PayrollSystem
{
public class Employee
{
public int Id { get; set; }
public string Name { get; set; } 
public double BaseSalary { get; set; } 
public virtual void DisplayPayslip()
{
Console.WriteLine("\n====================================");
Console.WriteLine("	OFFICIAL PAYSLIP	"); 
Console.WriteLine("====================================");
Console.WriteLine($"Employee ID : {Id}"); 
Console.WriteLine($"Employee Name : {Name}"); 
Console.WriteLine($"Base Salary : INR {BaseSalary:F2}");
}
}
public class SalesEmployee : Employee
{
public double TotalSales { get; set; } 
public double CommissionRate { get; set; } 
public override void DisplayPayslip()
{
base.DisplayPayslip();
double commissionEarned = TotalSales * CommissionRate; 
double grossSalary = BaseSalary + commissionEarned;
 
Console.WriteLine($"Total Sales : INR {TotalSales:F2}");
Console.WriteLine($"Commission	: INR {commissionEarned:F2} ({(CommissionRate *100)}%)");
Console.WriteLine("		");
Console.WriteLine($"GROSS PAYOUT : INR {grossSalary:F2}"); 
Console.WriteLine("====================================");
}
}
class Program
{
static void Main(string[] args)
{
Console.WriteLine("=== EMPLOYEE DATA REGISTRATION SYSTEM ===");
SalesEmployee salesPerson = new SalesEmployee(); 
Console.Write("Enter Employee ID: "); 
salesPerson.Id = int.Parse(Console.ReadLine()); 
Console.Write("Enter Employee Name: "); 
salesPerson.Name = Console.ReadLine(); 
Console.Write("Enter Fixed Base Salary (INR): ");
salesPerson.BaseSalary = double.Parse(Console.ReadLine()); 
Console.Write("Enter Total Sales Achieved (INR): "); 
salesPerson.TotalSales = double.Parse(Console.ReadLine()); 
Console.Write("Enter Commission Percentage (e.g., 10 for 10%): "); 
double percentInput = double.Parse(Console.ReadLine()); 
salesPerson.CommissionRate = percentInput / 100.0; 
salesPerson.DisplayPayslip();
Console.WriteLine("\nPress Enter to exit the system..."); 
Console.ReadLine();
}
}
}
