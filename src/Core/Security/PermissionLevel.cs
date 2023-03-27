namespace Core.Security;

[Serializable]
public class PermissionAccessLevel : IEquatable<PermissionAccessLevel>
{
    public Permission Permission { get; }
    public RoleAccessLevel AccessLevel { get; }

    public PermissionAccessLevel(Permission permission, RoleAccessLevel accessLevel = RoleAccessLevel.AddEdit)
    {
        Permission = permission;
        AccessLevel = accessLevel;
    }

    public override bool Equals(object obj)
    {
        return (PermissionAccessLevel)obj != null && Equals((PermissionAccessLevel)obj);
    }

    public bool Equals(PermissionAccessLevel other)
    {
        return Permission == other?.Permission &&
               AccessLevel == other.AccessLevel;
    }

    public override int GetHashCode()
    {
        return Hashcode.Start
            .Hash(Permission)
            .Hash(AccessLevel);
    }

    public override string ToString()
    {
        return $"{Permission}|{AccessLevel}";
    }
}