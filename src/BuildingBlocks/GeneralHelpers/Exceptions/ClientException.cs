namespace GeneralHelpers.Exceptions;

public class ClientException : ApplicationException
{
    public ClientException(string message) : base(message)
    {
    }
}
