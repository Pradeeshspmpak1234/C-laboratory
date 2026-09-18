using System;
namespace OperatorOverloadingDemo
{
public class Box
{
public double Length { get; set; } 
public double Width { get; set; } 
public double Height { get; set; }
public Box(double length, double width, double height)
{
Length = length;
Width = width;
Height = height;
}
public double Volume => Length * Width * Height; 
public static Box operator +(Box b1, Box b2)
{
return new Box( b1.Length + b2.Length, b1.Width + b2.Width, b1.Height + b2.Height);
}
public static bool operator ==(Box b1, Box b2)
{
if (ReferenceEquals(b1, null) || ReferenceEquals(b2, null)) return ReferenceEquals(b1, b2);
 
return b1.Volume == b2.Volume;
}
public static bool operator !=(Box b1, Box b2)
{
return !(b1 == b2);
}
public override bool Equals(object obj)
{
if (obj is Box otherBox)
{
return this == otherBox;
}
return false;
}
public override int GetHashCode()
{
return Volume.GetHashCode();
}
public override string ToString()
{
return $"Box({Length}x{Width}x{Height}) [Volume: {Volume}]";
}
}
class Program
{
static void Main(string[] args)
{
Console.WriteLine("=== C# Operator Overloading Demo ===\n"); 
Box box1 = new Box(2.0, 3.0, 4.0);
Box box2 = new Box(5.0, 2.0, 3.0);
 
Console.WriteLine($"Box 1: {box1}");
Console.WriteLine($"Box 2: {box2}"); Box box3 = box1 + box2;
Console.WriteLine($"\nResult of Box 1 + Box 2: {box3}"); 
Box box4 = new Box(1.0, 4.0, 6.0); 
Console.WriteLine($"Box 4: {box4}");
Console.WriteLine($"\nIs Box 1 equal to Box 2? {box1 == box2}"); 
Console.WriteLine($"Is Box 1 equal to Box 4? {box1 == box4}");

Console.ReadKey();
}
}
}

