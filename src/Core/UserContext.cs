using Core.Abstractions.Interfaces;

namespace Core;

public class UserContext : IUserContext
{
    public UserContext(int accountId, int actingUserId, string actingUserName, Guid? actingUserGuid)
    {
        AccountId = accountId;
        ActingUserId = actingUserId;
        ActingUserName = actingUserName;
        ActingUserGuid = actingUserGuid;
    }
    
    public int AccountId { get; }
    public int ActingUserId { get; }
    public string ActingUserName { get; }
    public Guid? ActingUserGuid { get; }
}