using Microsoft.AspNetCore.Antiforgery;
using JD.CRS.Controllers;

namespace JD.CRS.Web.Host.Controllers
{
    public class AntiForgeryController : CRSControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
