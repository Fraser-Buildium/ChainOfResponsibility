namespace Core.Security;

public enum RoleAccessLevel
{
    /// <summary>
    /// Access level none
    /// </summary>
    None = 1,
    /// <summary>
    /// Access level read only
    /// </summary>
    ReadOnly = 2,
    /// <summary>
    /// Access level add, edit
    /// </summary>
    AddEdit = 3,
    /// <summary>
    /// Access level add, edit, delete
    /// </summary>
    AddEditDelete = 4
}