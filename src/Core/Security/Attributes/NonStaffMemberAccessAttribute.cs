namespace Core.Security.Attributes;

public class NonStaffMemberAccessAttribute : Attribute
{
    public bool HasAccess { get; set; }

    public NonStaffMemberAccessAttribute(bool canUserAccess)
    {
        HasAccess = canUserAccess;
    }
}