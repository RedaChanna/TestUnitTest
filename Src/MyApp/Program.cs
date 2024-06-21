using System;

namespace MyApp
{
    public class Program // Rendi la classe public
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Simple Calculator");
            Console.Write("Enter the first number: ");
            double num1 = Convert.ToDouble(Console.ReadLine() ?? "0");

            Console.Write("Enter the second number: ");
            double num2 = Convert.ToDouble(Console.ReadLine() ?? "0");

            Console.WriteLine("Choose an operation (+, -): ");
            string operation = Console.ReadLine() ?? "";

            try
            {
                double result = Calculate(num1, num2, operation);
                Console.WriteLine($"Result: {result}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static double Calculate(double num1, double num2, string operation) // Cambia qui a public
        {
            if (string.IsNullOrEmpty(operation))
                throw new ArgumentException("Operation cannot be null or empty");

            switch (operation)
            {
                case "+":
                    return num1 + num2;
                case "-":
                    return num1 - num2;
                default:
                    throw new ArgumentException("Invalid operation");
            }
        }
    }
}