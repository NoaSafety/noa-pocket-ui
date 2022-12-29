public class MissingAccountConfirmationException : Exception
{
    public MissingAccountConfirmationException()
    {
    }

    public MissingAccountConfirmationException(string message)
        : base(message)
    {
    }
}