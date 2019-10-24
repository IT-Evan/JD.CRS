using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using JD.CRS.Authorization;
using JD.CRS.Controllers;
using JD.CRS.Office;
using JD.CRS.Office.Dto;
using JD.CRS.Web.Models.Office;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JD.CRS.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Office)]
    public class OfficeController : CRSControllerBase
    {
        private readonly IOfficeAppService _officeAppService;
        public OfficeController(IOfficeAppService officeAppService)
        {
            _officeAppService = officeAppService;
        }

        // GET: /<controller>/
        public async Task<ActionResult> Index(PagedResultRequestDto input)
        {
            IReadOnlyList<OfficeReadDto> output = (await _officeAppService.GetAll(new PagedResultRequestDto { })).Items;
            var model = new Index(output)
            {
                
            };
            return View(model);
        }
        public async Task<ActionResult> Edit(int officeId)
        {
            var office = await _officeAppService.Get(new EntityDto<int>(officeId));
            var model = new Edit
            {
                Office = office,
                Status = office.Status
            };
            return View("Edit", model);
        }
    }
}