public class ValidationException : Exception
{

    public ValidationException(List<string> messages) : base(string.Join(",", messages))
    {
        
    }
}
