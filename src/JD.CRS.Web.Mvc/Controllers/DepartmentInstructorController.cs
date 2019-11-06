using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using JD.CRS.Authorization;
using JD.CRS.Controllers;
using JD.CRS.Department;
using JD.CRS.Department.Dto;
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
        private readonly IDepartmentAppService _departmentAppService;
        private readonly IInstructorAppService _instructorAppService;
        public DepartmentInstructorController(IDepartmentInstructorAppService departmentInstructorAppService, IDepartmentAppService departmentAppService, IInstructorAppService instructorAppService)
        {
            _departmentInstructorAppService = departmentInstructorAppService;
            _departmentAppService = departmentAppService;
            _instructorAppService = instructorAppService;
        }

        // GET: /<controller>/
        public async Task<ActionResult> Index(PagedResultRequestDto input)
        {
            IReadOnlyList<DepartmentInstructorReadDto> departmentInstructorList = (await _departmentInstructorAppService.GetAll(new PagedResultRequestDto { })).Items;
            IReadOnlyList<DepartmentReadDto> departmentList = (await _departmentAppService.GetAll(new PagedResultRequestDto { })).Items;
            IReadOnlyList<InstructorReadDto> instructorList = (await _instructorAppService.GetAll(new PagedResultRequestDto { })).Items;
            var model = new Index(departmentInstructorList, departmentList, instructorList)
            {

            };
            return View(model);
        }
        public async Task<ActionResult> Edit(int departmentInstructorId)
        {
            var departmentInstructor = await _departmentInstructorAppService.Get(new EntityDto<int>(departmentInstructorId));
            IReadOnlyList<DepartmentReadDto> departmentList = (await _departmentAppService.GetAll(new PagedResultRequestDto { })).Items;
            IReadOnlyList<InstructorReadDto> instructorList = (await _instructorAppService.GetAll(new PagedResultRequestDto { })).Items;
            var model = new Edit(departmentInstructor, departmentList, instructorList)
            {
                DepartmentInstructor = departmentInstructor,
                Status = departmentInstructor.Status,
                DepartmentCode = departmentInstructor.DepartmentCode,
                InstructorCode = departmentInstructor.InstructorCode
            };
            return View("Edit", model);
        }
    }
}