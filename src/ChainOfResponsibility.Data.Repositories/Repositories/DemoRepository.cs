using ChainOfResponsibility.Data.Abstractions;
using ChainOfResponsibility.Data.Models.Subscriber;
using Core.Abstractions.Interfaces;

namespace ChainOfResponsibility.Data.Repositories.Repositories;

public class DemoRepository : SubscriberRepository<Demo>
{
    public DemoRepository(IUserContext userContext, IDatabaseContext databaseContext) 
        : base(userContext, databaseContext)
    {
    }
    
    public override Demo Create(Demo entity)
    {
        if (UserContext.ActingUserName == "winner")
        {
            return new Demo();
        }
        
        throw new InvalidOperationException("Only winners get demos.");
    }

    
}