using Xunit;
using MyApp; // Assicurati di avere questo using per riferire al namespace dell'applicazione

public class CalculatorTests
{
    [Theory]
    [InlineData(5, 3, "+", 8)]
    [InlineData(10, 2, "-", 8)]
    public void TestSimpleOperations(double num1, double num2, string operation, double expected)
    {
        double result = Program.Calculate(num1, num2, operation); // Riferimento Program.Calculate
        Assert.Equal(expected, result);
    }
}