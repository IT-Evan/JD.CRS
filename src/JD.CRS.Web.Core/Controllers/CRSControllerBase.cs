using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace JD.CRS.Controllers
{
    public abstract class CRSControllerBase: AbpController
    {
        protected CRSControllerBase()
        {
            LocalizationSourceName = CRSConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
