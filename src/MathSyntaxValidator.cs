using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace AdvancedCalculator;

public partial class MathSyntaxValidator
{
    [GeneratedRegex(@"^-?(?:\d+(?:\.\d+)?|\((?:\d+(?:\.\d+)?|\([^()]*\))(?:[+\-/*^](?:\d+(?:\.\d+)?|\([^()]*\)))*\))(?:[+\-/*^](?:\d+(?:\.\d+)?|\((?:\d+(?:\.\d+)?|\([^()]*\))(?:[+\-/*^](?:\d+(?:\.\d+)?|\([^()]*\)))*\)))*$")]
    private static partial Regex SimpleMathExpression();

    public static bool IsSimpleExpression([NotNullWhen(true)] string? input)
    {
        return SimpleMathExpression().IsMatch(input ?? "")
            && AllOpenParenthesesAreClosed(input!)
            && AllNumbersAreValidDoubles(input!);
    }

    private static bool AllOpenParenthesesAreClosed(string input)
    {
        int openParanthesesNumber = 0;

        for (int i = 0; i < input!.Length; i++)
        {
            openParanthesesNumber += input[i] switch
            {
                '(' => 1,
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

    private static bool AllNumbersAreValidDoubles(string input)
    {
        var numbersList = input!.Split(['(', ')', '+', '-', '*', '^', '/'], StringSplitOptions.RemoveEmptyEntries);
        
        foreach (var number in numbersList)
        {
            if (!double.TryParse(number, out _))
            {
                return false;
            }
        }

        return true;
    }
}