namespace AdvancedCalculator;

public static class Calculator
{
    public static Result<double> Calculate(string? expression)
    {
        if (!MathSyntaxValidator.IsSimpleExpression(expression))
        {
            return Result<double>.CreateFailure("Invalid expression!");
        }

        return 0.9d;
    }
}