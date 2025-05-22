namespace Domain.Exceptions
{
    public class MissingRequiredInformation : Exception
    {
        public MissingRequiredInformation(string message)
            : base(message)
        {
        }
    }
}
