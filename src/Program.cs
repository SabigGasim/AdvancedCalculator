using AdvancedCalculator;

do
{
    Console.Write("Write expression: ");
    var expression = Console.ReadLine();
    var result = Calculator.Calculate(expression);
    if (!result.Success)
    {
        Console.WriteLine($"An error occurred: {result.ErrorMessage}");
        continue;
    }

    Console.WriteLine($"Result is: {result.Payload:g}");
}
while (ShouldRestart());

Console.WriteLine("Press any key to exit...");
Console.ReadKey();

static bool ShouldRestart()
{
    Console.Write("Want to try again? (Y/N): ");
    return Console.ReadLine() is ("y" or "Y");
}
