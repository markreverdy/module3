using System;

namespace DelegateExample
{
    public class Class1
    {
        // Delegate that returns nothing but takes a bool.
        public delegate void ShowDelegate(bool result);

        // Multiply method
        public double Multiply(double a, double b)
        {
            return a * b;
        }
    }

    public class Class2
    {
        private double _storedResult;

        // Delegate for Multiply method
        public delegate double MultiplyDelegate(double a, double b);

        // Delegate for Result method
        public delegate bool ResultDelegate(double num);

        // Calc method
        public ResultDelegate Calc(MultiplyDelegate multiply, double a, double b)
        {
            _storedResult = multiply(a, b);
            return Result;
        }

        // Result method
        public bool Result(double num)
        {
            return _storedResult % num == 0;
        }
    }

    public class Program
    {
        public static void Show(bool isDivisible)
        {
            Console.WriteLine(isDivisible ? "The number is divisible without a remainder." : "The number has a remainder.");
        }

        public static void Main(string[] args)
        {
            Class1 class1 = new Class1();
            Class2 class2 = new Class2();

            Class1.ShowDelegate showDel = Show;
            Class2.MultiplyDelegate multiplyDel = class1.Multiply;

            var resultDelegate = class2.Calc(multiplyDel, 4, 5);  // For example 4*5 = 20

            showDel(resultDelegate(4)); // Check if 20 is divisible by 4
            showDel(resultDelegate(3)); // Check if 20 is divisible by 3
        }
    }
}