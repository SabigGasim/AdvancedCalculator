namespace AdvancedCalculator.Tests;

public class MathRegexTests
{
    [Theory]
    [InlineData("3+2*5.510")]
    [InlineData("-(2+3)")]
    [InlineData("42")]
    [InlineData("-123")]
    [InlineData("sin(90)")]
    [InlineData("cbrt(sqrt(81))")]
    [InlineData("3+((2*5)-7)+2")]
    [InlineData("-cbrt(27)*((tan(0.01)+2)*(3-sqrt(acot(9999991123456785234567420.699999999999999999999999999999))))^2.2/cos(5)")]
    public void ValidExpressions_ReturnTrue(string expr)
    {
        Assert.True(MathSyntaxValidator.IsSimpleExpression(expr));
    }

    [Theory]
    [InlineData("3++2")]       // duplicate +
    [InlineData("3--2")]       // duplicate -
    [InlineData("3**2")]       // duplicate *
    [InlineData("3//2")]       // duplicate /
    [InlineData("3^^2")]       // duplicate ^
    [InlineData("3..2")]       // duplicate .
    [InlineData("3.+(5)")]     // dot followed by operator 
    [InlineData("3.(5)")]      // dot followed by brackets
    [InlineData("3+.5")]       // dot peceeded by operator 
    [InlineData("2*/3")]       // invalid operator sequence
    [InlineData("123-")]       // trailing operator
    [InlineData("(1+2")]       // unbalanced parentheses
    [InlineData("1+2)")]       // unbalanced parentheses
    [InlineData(")1+2(")]      // balanced but starts with closing bracket
    [InlineData("()")]         // parentheses are empty
    [InlineData("( )")]        // parentheses are empty
    [InlineData("(  )")]       // parentheses are empty
    [InlineData("5+()")]       // parentheses are empty
    [InlineData("+5")]         // starts with +
    [InlineData("*5")]         // starts with *
    [InlineData("/5")]         // starts with /
    [InlineData("^5")]         // starts with ^
    [InlineData(".5")]         // starts with .
    [InlineData("5+")]         // ends with +
    [InlineData("5*")]         // ends with *
    [InlineData("5/")]         // ends with /
    [InlineData("5^")]         // ends with ^
    [InlineData("5.")]         // ends with .
    [InlineData("(*5)")]       // open bracket followed by operator
    [InlineData("abc")]        // invalid characters
    [InlineData("5%2")]        // invalid operators
    [InlineData("5@2")]        // invalid operators
    [InlineData("5#2")]        // invalid operators
    [InlineData("sin50")]      // trig function without brackets
    [InlineData("")]           // empty string
    [InlineData(null)]         // null
    public void InvalidExpressions_ReturnFalse(string? expr)
    {
        Assert.False(MathSyntaxValidator.IsSimpleExpression(expr));
    }
}

