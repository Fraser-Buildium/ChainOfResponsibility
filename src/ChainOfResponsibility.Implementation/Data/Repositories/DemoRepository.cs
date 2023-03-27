using ChainOfResponsibility.Implementation.Data.Interfaces;
using ChainOfResponsibility.Implementation.Data.Models;
using Core.Interfaces;

namespace ChainOfResponsibility.Implementation.Data.Repositories;

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