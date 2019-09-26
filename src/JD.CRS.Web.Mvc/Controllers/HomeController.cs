using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using JD.CRS.Controllers;

namespace JD.CRS.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : CRSControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
