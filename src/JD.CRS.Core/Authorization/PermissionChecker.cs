using Abp.Authorization;
using JD.CRS.Authorization.Roles;
using JD.CRS.Authorization.Users;

namespace JD.CRS.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
