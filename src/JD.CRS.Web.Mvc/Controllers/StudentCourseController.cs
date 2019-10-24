using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using JD.CRS.Authorization;
using JD.CRS.Controllers;
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
        public StudentCourseController(IStudentCourseAppService studentCourseAppService)
        {
            _studentCourseAppService = studentCourseAppService;
        }

        // GET: /<controller>/
        public async Task<ActionResult> Index(PagedResultRequestDto input)
        {
            IReadOnlyList<StudentCourseReadDto> output = (await _studentCourseAppService.GetAll(new PagedResultRequestDto { })).Items;
            var model = new Index(output)
            {

            };
            return View(model);
        }
        public async Task<ActionResult> Edit(int studentCourseId)
        {
            var studentCourse = await _studentCourseAppService.Get(new EntityDto<int>(studentCourseId));
            var model = new Edit
            {
                StudentCourse = studentCourse,
                Status = studentCourse.Status
            };
            return View("Edit", model);
        }
    }
}