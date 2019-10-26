using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using JD.CRS.Authorization;
using JD.CRS.Controllers;
using JD.CRS.Instructor;
using JD.CRS.Instructor.Dto;
using JD.CRS.Office;
using JD.CRS.Office.Dto;
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
        private readonly IOfficeAppService _officeAppService;
        private readonly IInstructorAppService _instructorAppService;
        public OfficeInstructorController(IOfficeInstructorAppService officeInstructorAppService, IOfficeAppService officeAppService, IInstructorAppService instructorAppService)
        {
            _officeInstructorAppService = officeInstructorAppService;
            _officeAppService = officeAppService;
            _instructorAppService = instructorAppService;
        }

        // GET: /<controller>/
        public async Task<ActionResult> Index(PagedResultRequestDto input)
        {
            IReadOnlyList<OfficeInstructorReadDto> officeInstructorList = (await _officeInstructorAppService.GetAll(new PagedResultRequestDto { })).Items;
            IReadOnlyList<OfficeReadDto> officeList = (await _officeAppService.GetAll(new PagedResultRequestDto { })).Items;
            IReadOnlyList<InstructorReadDto> instructorList = (await _instructorAppService.GetAll(new PagedResultRequestDto { })).Items;
            var model = new Index(officeInstructorList, officeList, instructorList)
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
                Status = officeInstructor.Status,
                OfficeCode = officeInstructor.OfficeCode,
                InstructorCode = officeInstructor.InstructorCode
            };
            return View("Edit", model);
        }
    }
}