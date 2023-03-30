using ChainOfResponsibility.Data.Abstractions;
using Core.Abstractions.Interfaces;

namespace ChainOfResponsibility.Implementation.Data;

public class DatabaseContextBuilder : IDatabaseContextBuilder
{
    public IDatabaseContext Build(IUserContext userContext)
    {
        // TODO: Functionality to populate the database connection strings based on the user context.
        var databaseContext = new DatabaseContext
        {
            PrimaryConnectionString = "primary connection string",
            SubscriberConnectionString = "subscriber connection string"
        };
        
        return databaseContext;
    }
}