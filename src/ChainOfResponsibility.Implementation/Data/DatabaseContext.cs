using ChainOfResponsibility.Implementation.Data.Interfaces;

namespace ChainOfResponsibility.Implementation.Data;

public class DatabaseContext : IDatabaseContext
{
    public string PrimaryConnectionString { get; init; }
    public string SubscriberConnectionString { get; init; }
}