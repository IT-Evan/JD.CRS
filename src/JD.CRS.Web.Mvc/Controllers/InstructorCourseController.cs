using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using JD.CRS.Authorization;
using JD.CRS.Controllers;
using JD.CRS.Course;
using JD.CRS.Course.Dto;
using JD.CRS.Instructor;
using JD.CRS.Instructor.Dto;
using JD.CRS.InstructorCourse;
using JD.CRS.InstructorCourse.Dto;
using JD.CRS.Web.Models.InstructorCourse;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JD.CRS.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_InstructorCourse)]
    public class InstructorCourseController : CRSControllerBase
    {
        private readonly IInstructorCourseAppService _instructorCourseAppService;
        private readonly IInstructorAppService _instructorAppService;
        private readonly ICourseAppService _courseAppService;
        public InstructorCourseController(IInstructorCourseAppService instructorCourseAppService, IInstructorAppService instructorAppService, ICourseAppService courseAppService)
        {
            _instructorCourseAppService = instructorCourseAppService;
            _instructorAppService = instructorAppService;
            _courseAppService = courseAppService;
        }

        // GET: /<controller>/
        public async Task<ActionResult> Index(PagedResultRequestDto input)
        {
            IReadOnlyList<InstructorCourseReadDto> instructorCourseList = (await _instructorCourseAppService.GetAll(new PagedResultRequestDto { })).Items;
            IReadOnlyList<InstructorReadDto> instructorList = (await _instructorAppService.GetAll(new PagedResultRequestDto { })).Items;
            IReadOnlyList<CourseReadDto> courseList = (await _courseAppService.GetAll(new PagedResultRequestDto { })).Items;
            var model = new Index(instructorCourseList, instructorList, courseList)
            {

            };
            return View(model);
        }
        public async Task<ActionResult> Edit(int instructorCourseId)
        {
            var instructorCourse = await _instructorCourseAppService.Get(new EntityDto<int>(instructorCourseId));
            IReadOnlyList<InstructorReadDto> instructorList = (await _instructorAppService.GetAll(new PagedResultRequestDto { })).Items;
            IReadOnlyList<CourseReadDto> courseList = (await _courseAppService.GetAll(new PagedResultRequestDto { })).Items;
            var model = new Edit(instructorCourse, instructorList, courseList)
            {
                InstructorCourse = instructorCourse,
                Status = instructorCourse.Status,
                InstructorCode = instructorCourse.InstructorCode,
                CourseCode = instructorCourse.CourseCode
            };
            return View("Edit", model);
        }
    }
}