using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using JD.CRS.Authorization;
using JD.CRS.Controllers;
using JD.CRS.DepartmentInstructor;
using JD.CRS.DepartmentInstructor.Dto;
using JD.CRS.Instructor;
using JD.CRS.Instructor.Dto;
using JD.CRS.Web.Models.DepartmentInstructor;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JD.CRS.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_DepartmentInstructor)]
    public class DepartmentInstructorController : CRSControllerBase
    {
        private readonly IDepartmentInstructorAppService _departmentInstructorAppService;
        private readonly IInstructorAppService _instructorAppService;
        public DepartmentInstructorController(IDepartmentInstructorAppService departmentInstructorAppService, IInstructorAppService instructorAppService)
        {
            _departmentInstructorAppService = departmentInstructorAppService;
            _instructorAppService = instructorAppService;
        }

        // GET: /<controller>/
        public async Task<ActionResult> Index(PagedResultRequestDto input)
        {
            IReadOnlyList<DepartmentInstructorReadDto> departmentInstructorList = (await _departmentInstructorAppService.GetAll(new PagedResultRequestDto { })).Items;
            IReadOnlyList<InstructorReadDto> instructorList = (await _instructorAppService.GetAll(new PagedResultRequestDto { })).Items;
            var model = new Index(departmentInstructorList, instructorList)
            {

            };
            return View(model);
        }
        public async Task<ActionResult> Edit(int departmentInstructorId)
        {
            var departmentInstructor = await _departmentInstructorAppService.Get(new EntityDto<int>(departmentInstructorId));
            IReadOnlyList<InstructorReadDto> instructorList = (await _instructorAppService.GetAll(new PagedResultRequestDto { })).Items;
            var model = new Edit(departmentInstructor, instructorList)
            {
                DepartmentInstructor = departmentInstructor,
                Status = departmentInstructor.Status,
                InstructorCode = departmentInstructor.InstructorCode
            };
            return View("Edit", model);
        }
    }
}