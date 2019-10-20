using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using JD.CRS.Authorization;
using JD.CRS.Controllers;
using JD.CRS.OfficeInstructor;
using JD.CRS.OfficeInstructor.Dto;
using JD.CRS.Web.Models.OfficeInstructor;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JD.CRS.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_OfficeInstructor)]
    public class OfficeInstructorController : CRSControllerBase
    {
        private readonly IOfficeInstructorAppService _officeInstructorAppService;
        public OfficeInstructorController(IOfficeInstructorAppService officeInstructorAppService)
        {
            _officeInstructorAppService = officeInstructorAppService;
        }

        // GET: /<controller>/
        public async Task<ActionResult> Index(PagedResultRequestDto input)//(GetAllOfficeInstructorsInput input)
        {
            IReadOnlyList<OfficeInstructorReadDto> output = (await _officeInstructorAppService.GetAll(new PagedResultRequestDto { })).Items;
            var model = new Index(output)
            {

            };
            return View(model);
        }
        public async Task<ActionResult> Edit(int officeInstructorId)
        {
            var officeInstructor = await _officeInstructorAppService.Get(new EntityDto<int>(officeInstructorId));
            var model = new Edit
            {
                OfficeInstructor = officeInstructor,
                Status = officeInstructor.Status
            };
            return View("Edit", model);
        }
    }
}