namespace Core.Abstractions.Interfaces;

public interface IUserContext
{
    int AccountId { get; }
    int ActingUserId { get; }
    string ActingUserName { get; }
    Guid? ActingUserGuid { get; }
}