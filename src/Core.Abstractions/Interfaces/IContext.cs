namespace Core.Abstractions.Interfaces;

public interface IContext<out TUnitOfWork>
{
    IUserContext UserContext { get; }
    TUnitOfWork UnitOfWork { get; }
    Dictionary<string,object> LoggingContext { get; }
}