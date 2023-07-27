public class AccountAlreadyExistsException : Exception
{
    public AccountAlreadyExistsException()
    {
    }

    public AccountAlreadyExistsException(string message)
        : base(message)
    {
    }
}