namespace Domain.Exceptions
{
    public class InvalidClientTypeException : Exception
    {
        public InvalidClientTypeException(string message)
            : base(message)
        {
        }
    }
}
