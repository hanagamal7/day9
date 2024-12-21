using System;

namespace day9
{
    // Problem 1: Weekdays Enum
    public enum Weekdays
    {
        Monday = 1,
        Tuesday,
        Wednesday,
        Thursday,
        Friday
    }

    // Problem 2: Grades Enum with short underlying type
    public enum Grades : short
    {
        F = 1,
        D,
        C,
        B,
        A
    }

    // Problem 3: Person Class with Department
    public class Person
    {
        public string Name { get; set; }
        public virtual string Department { get; set; }
    }

    // Problem 4: Child Class with sealed property
    public class Parent
    {
        public virtual double Salary { get; set; }
    }

    public class Child : Parent
    {
        public sealed override double Salary { get; set; }

        public void DisplaySalary()
        {
            Console.WriteLine($"Salary: {Salary}");
        }
    }

    // Problem 5: Utility Class for Rectangle Perimeter
    public static class Utility
    {
        public static double CalculateRectanglePerimeter(double length, double width)
        {
            return 2 * (length + width);
        }

        // Problem 9: Temperature Conversion
        public static double ConvertToFahrenheit(double celsius)
        {
            return celsius * 9 / 5 + 32;
        }

        public static double ConvertToCelsius(double fahrenheit)
        {
            return (fahrenheit - 32) * 5 / 9;
        }
    }

    // Problem 6: ComplexNumber Class with Operator Overloading
    public class ComplexNumber
    {
        public double Real { get; set; }
        public double Imaginary { get; set; }

        public ComplexNumber(double real, double imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }

        public static ComplexNumber operator *(ComplexNumber c1, ComplexNumber c2)
        {
            double real = c1.Real * c2.Real - c1.Imaginary * c2.Imaginary;
            double imaginary = c1.Real * c2.Imaginary + c1.Imaginary * c2.Real;
            return new ComplexNumber(real, imaginary);
        }

        public override string ToString()
        {
            return $"{Real} + {Imaginary}i";
        }
    }

    // Problem 10: Gender Enum with byte underlying type
    public enum Gender : byte
    {
        Male = 0,
        Female = 1
    }

    // Problem 12: Employee Class with Equals Method
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is Employee other)
            {
                return Id == other.Id && Name == other.Name && Department == other.Department;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, Department);
        }

        public override string ToString()
        {
            return $"{Name}, {Department}";
        }
    }

    // Problem 15: Generic Helper Class
    public static class Helper
    {
        public static T Max<T>(T a, T b) where T : IComparable<T>
        {
            return a.CompareTo(b) > 0 ? a : b;
        }
    }

    public static class Helper2<T>
    {
        public static void ReplaceArray(T[] array, T oldValue, T newValue)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Equals(oldValue))
                {
                    array[i] = newValue;
                }
            }
        }
    }

    // Problem 18: Circle Struct
    public struct Circle
    {
        public double Radius { get; set; }
        public string Color { get; set; }

        public Circle(double radius, string color)
        {
            Radius = radius;
            Color = color;
        }

        public override bool Equals(object obj)
        {
            if (obj is Circle other)
            {
                return Radius == other.Radius && Color == other.Color;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Radius, Color);
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            // Problem 1: Enum Example
            foreach (Weekdays day in Enum.GetValues(typeof(Weekdays)))
            {
                Console.WriteLine($"{day} = {(int)day}");
            }

            // Problem 2: Grades Enum Example
            foreach (Grades grade in Enum.GetValues(typeof(Grades)))
            {
                Console.WriteLine($"{grade} = {(short)grade}");
            }

            // Problem 3: Person Example
            Person person1 = new Person { Name = "Alice", Department = "IT" };
            Person person2 = new Person { Name = "Bob", Department = "HR" };
            Console.WriteLine($"{person1.Name}, Department: {person1.Department}");
            Console.WriteLine($"{person2.Name}, Department: {person2.Department}");

            // Problem 5: Utility Static Method
            Console.WriteLine($"Perimeter: {Utility.CalculateRectanglePerimeter(5, 10)}");

            // Problem 6: ComplexNumber Multiplication
            ComplexNumber c1 = new ComplexNumber(2, 3);
            ComplexNumber c2 = new ComplexNumber(4, 5);
            ComplexNumber result = c1 * c2;
            Console.WriteLine($"Multiplication: {result}");

            // Problem 9: Temperature Conversion
            Console.WriteLine($"100C to F: {Utility.ConvertToFahrenheit(100)}");
            Console.WriteLine($"212F to C: {Utility.ConvertToCelsius(212)}");

            // Problem 12: Employee Equals Method
            Employee emp1 = new Employee { Id = 1, Name = "Alice", Department = "IT" };
            Employee emp2 = new Employee { Id = 1, Name = "Alice", Department = "IT" };
            Console.WriteLine($"Employees Equal: {emp1.Equals(emp2)}");

            // Problem 15: Generic Max
            Console.WriteLine($"Max of 3 and 5: {Helper.Max(3, 5)}");
            Console.WriteLine($"Max of 'Hello' and 'World': {Helper.Max("Hello", "World")}");

            // Problem 18: Circle Comparison
            Circle circle1 = new Circle(5, "Red");
            Circle circle2 = new Circle(5, "Red");
            Console.WriteLine($"Circles Equal: {circle1.Equals(circle2)}");
        }
    }
}

