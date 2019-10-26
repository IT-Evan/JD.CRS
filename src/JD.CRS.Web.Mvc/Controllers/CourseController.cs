using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using JD.CRS.Authorization;
using JD.CRS.Controllers;
using JD.CRS.Course;
using JD.CRS.Course.Dto;
using JD.CRS.Web.Models.Course;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JD.CRS.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Course)]
    public class CourseController : CRSControllerBase
    {
        private readonly ICourseAppService _courseAppService;
        public CourseController(ICourseAppService courseAppService)
        {
            _courseAppService = courseAppService;
        }

        // GET: /<controller>/
        public async Task<ActionResult> Index(PagedResultRequestDto input)//(GetAllCoursesInput input)
        {
            IReadOnlyList<CourseReadDto> courseList = (await _courseAppService.GetAll(new PagedResultRequestDto { })).Items;
            var model = new Index(courseList)
            {
                
            };
            return View(model);
            //IReadOnlyList<CourseDto> course = (await _courseAppService.GetAll(new GetAllCoursesInput { Status = input.Status, Keyword = input.Keyword })).Items;
            //var model = new Index(output)
            //{
            //    Status = input.Status,
            //    Keyword = input.Keyword
            //};
            //return View(model);
        }
        public async Task<ActionResult> Edit(int courseId)
        {
            var course = await _courseAppService.Get(new EntityDto<int>(courseId));
            var model = new Edit
            {
                Course = course,
                Status = course.Status
            };
            return View("Edit", model);
        }
    }
}