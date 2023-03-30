namespace ChainOfResponsibility.Data.Repositories.Repositories.Exceptions;

public class UninitializedRepositoryException : Exception
{
    public UninitializedRepositoryException(string message)
        : base(message)
    {

    }
}