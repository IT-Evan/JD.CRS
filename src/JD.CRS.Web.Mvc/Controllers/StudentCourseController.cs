using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using JD.CRS.Authorization;
using JD.CRS.Controllers;
using JD.CRS.Course;
using JD.CRS.Course.Dto;
using JD.CRS.Student;
using JD.CRS.Student.Dto;
using JD.CRS.StudentCourse;
using JD.CRS.StudentCourse.Dto;
using JD.CRS.Web.Models.StudentCourse;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JD.CRS.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_StudentCourse)]
    public class StudentCourseController : CRSControllerBase
    {
        private readonly IStudentCourseAppService _studentCourseAppService;
        private readonly IStudentAppService _studentAppService;
        private readonly ICourseAppService _courseAppService;
        public StudentCourseController(IStudentCourseAppService studentCourseAppService, IStudentAppService studentAppService, ICourseAppService courseAppService)
        {
            _studentCourseAppService = studentCourseAppService;
            _studentAppService = studentAppService;
            _courseAppService = courseAppService;
        }

        // GET: /<controller>/
        public async Task<ActionResult> Index(PagedResultRequestDto input)
        {
            IReadOnlyList<StudentCourseReadDto> studentCourseList = (await _studentCourseAppService.GetAll(new PagedResultRequestDto { })).Items;
            IReadOnlyList<StudentReadDto> studentList = (await _studentAppService.GetAll(new PagedResultRequestDto { })).Items;
            IReadOnlyList<CourseReadDto> courseList = (await _courseAppService.GetAll(new PagedResultRequestDto { })).Items;
            var model = new Index(studentCourseList, studentList, courseList)
            {

            };
            return View(model);
        }
        public async Task<ActionResult> Edit(int studentCourseId)
        {
            var studentCourse = await _studentCourseAppService.Get(new EntityDto<int>(studentCourseId));
            IReadOnlyList<StudentReadDto> studentList = (await _studentAppService.GetAll(new PagedResultRequestDto { })).Items;
            IReadOnlyList<CourseReadDto> courseList = (await _courseAppService.GetAll(new PagedResultRequestDto { })).Items;
            var model = new Edit(studentCourse, studentList, courseList)
            {
                StudentCourse = studentCourse,
                Status = studentCourse.Status,
                StudentCode = studentCourse.StudentCode,
                CourseCode = studentCourse.CourseCode
            };
            return View("Edit", model);
        }
    }
}