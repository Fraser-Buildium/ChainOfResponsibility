namespace ChainOfResponsibility.Implementation.Data.Repositories.Exceptions;

public class UninitializedRepositoryException : Exception
{
    public UninitializedRepositoryException(string message)
        : base(message)
    {

    }
}