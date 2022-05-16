namespace CantinaUnitBV.Controllers.Base;

public class Envelope<T>
{
    public T Result { get; set; }
    public string ErrorMessage { get; set; }
    public DateTime TimeGenerated { get; set; }

    internal Envelope(T result, string errorMessage)
    {
        Result = result;
        ErrorMessage = errorMessage;
        TimeGenerated = DateTime.UtcNow;
    }
}

public sealed class Envelope : Envelope<string>
{
    private Envelope(string errorMessage) : base(null, errorMessage)
    {

    }

    public static Envelope Ok()
    {
        return new(null);
    }

    public static Envelope<T> Ok<T>(T result)
    {
        return new(result, null);
    }

    public static Envelope Error(string errorMessage)
    {
        return new(errorMessage);
    }
}