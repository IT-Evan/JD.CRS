using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using JD.CRS.Authorization;
using JD.CRS.Controllers;
using JD.CRS.Course;
using JD.CRS.Course.Dto;
using JD.CRS.Department;
using JD.CRS.Department.Dto;
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
        private readonly IDepartmentAppService _departmentAppService;
        private readonly ICourseAppService _courseAppService;
        public DepartmentCourseController(IDepartmentCourseAppService departmentCourseAppService, IDepartmentAppService departmentAppService, ICourseAppService courseAppService)
        {
            _departmentCourseAppService = departmentCourseAppService;
            _departmentAppService = departmentAppService;
            _courseAppService = courseAppService;
        }

        // GET: /<controller>/
        public async Task<ActionResult> Index(PagedResultRequestDto input)
        {
            IReadOnlyList<DepartmentCourseReadDto> departmentCourseList = (await _departmentCourseAppService.GetAll(new PagedResultRequestDto { })).Items;
            IReadOnlyList<DepartmentReadDto> departmentList = (await _departmentAppService.GetAll(new PagedResultRequestDto { })).Items;
            IReadOnlyList<CourseReadDto> courseList = (await _courseAppService.GetAll(new PagedResultRequestDto { })).Items;
            var model = new Index(departmentCourseList, departmentList, courseList)
            {

            };
            return View(model);
        }
        public async Task<ActionResult> Edit(int departmentCourseId)
        {
            var departmentCourse = await _departmentCourseAppService.Get(new EntityDto<int>(departmentCourseId));
            IReadOnlyList<DepartmentReadDto> departmentList = (await _departmentAppService.GetAll(new PagedResultRequestDto { })).Items;
            IReadOnlyList<CourseReadDto> courseList = (await _courseAppService.GetAll(new PagedResultRequestDto { })).Items;
            var model = new Edit(departmentCourse, departmentList, courseList)
            {
                DepartmentCourse = departmentCourse,
                Status = departmentCourse.Status,
                DepartmentCode = departmentCourse.DepartmentCode,
                CourseCode = departmentCourse.CourseCode
            };
            return View("Edit", model);
        }
    }
}