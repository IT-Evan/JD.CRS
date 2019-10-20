using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using JD.CRS.Authorization;
using JD.CRS.Controllers;
using JD.CRS.DepartmentInstructor;
using JD.CRS.DepartmentInstructor.Dto;
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
        public DepartmentInstructorController(IDepartmentInstructorAppService departmentInstructorAppService)
        {
            _departmentInstructorAppService = departmentInstructorAppService;
        }

        // GET: /<controller>/
        public async Task<ActionResult> Index(PagedResultRequestDto input)//(GetAllDepartmentInstructorsInput input)
        {
            IReadOnlyList<DepartmentInstructorReadDto> output = (await _departmentInstructorAppService.GetAll(new PagedResultRequestDto { })).Items;
            var model = new Index(output)
            {

            };
            return View(model);
        }
        public async Task<ActionResult> Edit(int departmentInstructorId)
        {
            var departmentInstructor = await _departmentInstructorAppService.Get(new EntityDto<int>(departmentInstructorId));
            var model = new Edit
            {
                DepartmentInstructor = departmentInstructor,
                Status = departmentInstructor.Status
            };
            return View("Edit", model);
        }
    }
}