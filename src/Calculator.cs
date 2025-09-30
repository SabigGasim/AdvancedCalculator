using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace AdvancedCalculator;

public static class Calculator
{
    public static Result<double> Calculate(string? expression)
    {
        if (!MathRegex.IsSimpleExpression(expression))
        {
            return Result<double>.CreateFailure("Invalid expression!");
        }

        return 0.9d;
    }
}

public partial class MathRegex
{
    [GeneratedRegex(@"^-?[0-9()]+(?:[+\-/*^][0-9()]+)*$")]
    private static partial Regex SimpleMathExpression();

    public static bool IsSimpleExpression([NotNullWhen(true)]string? input)
    {
        if(!SimpleMathExpression().IsMatch(input ?? ""))
        {
            return false;
        }

        int openParanthesesNumber = 0;

        for (int i = 0; i < input!.Length; i++)
        {
            openParanthesesNumber += input[i] switch
            {
                '(' =>  1,
                ')' => -1,
                _ => 0
            };

            if (openParanthesesNumber < 0)
            {
                return false;
            }
        }

        return openParanthesesNumber == 0;
    }
}