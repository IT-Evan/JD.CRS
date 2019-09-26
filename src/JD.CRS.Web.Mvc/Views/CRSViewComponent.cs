using Abp.AspNetCore.Mvc.ViewComponents;

namespace JD.CRS.Web.Views
{
    public abstract class CRSViewComponent : AbpViewComponent
    {
        protected CRSViewComponent()
        {
            LocalizationSourceName = CRSConsts.LocalizationSourceName;
        }
    }
}
