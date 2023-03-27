using Core.Security;

namespace Core.Errors
{
    public class PermissionError : Error
    {
        public IEnumerable<PermissionAccessLevel> RequiredPermissionAccessLevels { get; }

        public PermissionError(string message,
            IEnumerable<PermissionAccessLevel> requiredPermissionAccessLevels = null) : base(message)
        {
            RequiredPermissionAccessLevels = requiredPermissionAccessLevels ??
                Enumerable.Empty<PermissionAccessLevel>();
        }
    }
}