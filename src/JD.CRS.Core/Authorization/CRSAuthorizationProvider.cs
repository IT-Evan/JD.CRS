using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace JD.CRS.Authorization
{
    public class CRSAuthorizationProvider : AuthorizationProvider
    {
        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, CRSConsts.LocalizationSourceName);
        }
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Course, L("Course"));
        }
    }
}
