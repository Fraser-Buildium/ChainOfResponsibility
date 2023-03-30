namespace ChainOfResponsibility.Data.Abstractions;

public interface IDatabaseContext
{
    string PrimaryConnectionString { get; }
    string SubscriberConnectionString { get; }
}