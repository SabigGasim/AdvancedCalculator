namespace AdvancedCalculator;

public class Result<T>
{
    private Result() { }

    public T Payload { get; init; } = default!;
    public bool Success { get; init;  }
    public string? ErrorMessage { get; init; }

    public static Result<T> CreateSuccess(T payload)
    {
        return new Result<T>
        {
            Payload = payload,
            Success = true,
        };
    }

    public static Result<T> CreateFailure(string? errorMessage)
    {
        return new Result<T>
        {
            ErrorMessage = errorMessage,
            Success = false,
        };
    }

    public static implicit operator Result<T>(T payload) => Result<T>.CreateSuccess(payload); 
}
