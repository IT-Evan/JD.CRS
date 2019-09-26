using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;

namespace JD.CRS.Web.Views
{
    public abstract class CRSRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected CRSRazorPage()
        {
            LocalizationSourceName = CRSConsts.LocalizationSourceName;
        }
    }
}
