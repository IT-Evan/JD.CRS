using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using JD.CRS.Authorization;
using JD.CRS.Controllers;
using JD.CRS.DepartmentCourse;
using JD.CRS.DepartmentCourse.Dto;
using JD.CRS.Web.Models.DepartmentCourse;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JD.CRS.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_DepartmentCourse)]
    public class DepartmentCourseController : CRSControllerBase
    {
        private readonly IDepartmentCourseAppService _departmentCourseAppService;
        public DepartmentCourseController(IDepartmentCourseAppService departmentCourseAppService)
        {
            _departmentCourseAppService = departmentCourseAppService;
        }

        // GET: /<controller>/
        public async Task<ActionResult> Index(PagedResultRequestDto input)
        {
            IReadOnlyList<DepartmentCourseReadDto> output = (await _departmentCourseAppService.GetAll(new PagedResultRequestDto { })).Items;
            var model = new Index(output)
            {

            };
            return View(model);
        }
        public async Task<ActionResult> Edit(int departmentCourseId)
        {
            var departmentCourse = await _departmentCourseAppService.Get(new EntityDto<int>(departmentCourseId));
            var model = new Edit
            {
                DepartmentCourse = departmentCourse,
                Status = departmentCourse.Status
            };
            return View("Edit", model);
        }
    }
}