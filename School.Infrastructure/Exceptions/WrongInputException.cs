namespace School.Infrastructure.Exceptions
{
    public class WrongInputException : Exception
    {
        public WrongInputException(string message) : base(message)
        {
        }
    }
}
