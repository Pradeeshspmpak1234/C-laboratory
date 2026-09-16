using System;
namespace SimpleOopApp
{
public class Car
{
public string model; public string color; public void DisplayInfo()
{
Console.WriteLine($"Car Info: {year} {color} {model}");
}
}
class Program
{
static void Main(string[] args)
{
Car myFirstCar = new Car(); myFirstCar.model = "Toyota Corolla"; myFirstCar.color = "Red"; myFirstCar.year = 2024;
Car mySecondCar = new Car(); mySecondCar.model = "Tesla Model 3"; mySecondCar.color = "White"; mySecondCar.year = 2026;
Console.WriteLine("--- Executing Methods ---"); myFirstCar.DisplayInfo(); mySecondCar.DisplayInfo(); Console.ReadLine();
 
}
}
}
