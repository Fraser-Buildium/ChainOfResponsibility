namespace ChainOfResponsibility.Implementation.Data.Interfaces;

public interface IDatabaseContext
{
    string PrimaryConnectionString { get; }
    string SubscriberConnectionString { get; }
}