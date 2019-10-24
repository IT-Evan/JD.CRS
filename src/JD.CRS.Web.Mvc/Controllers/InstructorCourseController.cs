using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using JD.CRS.Authorization;
using JD.CRS.Controllers;
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
        public InstructorCourseController(IInstructorCourseAppService instructorCourseAppService)
        {
            _instructorCourseAppService = instructorCourseAppService;
        }

        // GET: /<controller>/
        public async Task<ActionResult> Index(PagedResultRequestDto input)
        {
            IReadOnlyList<InstructorCourseReadDto> output = (await _instructorCourseAppService.GetAll(new PagedResultRequestDto { })).Items;
            var model = new Index(output)
            {

            };
            return View(model);
        }
        public async Task<ActionResult> Edit(int instructorCourseId)
        {
            var instructorCourse = await _instructorCourseAppService.Get(new EntityDto<int>(instructorCourseId));
            var model = new Edit
            {
                InstructorCourse = instructorCourse,
                Status = instructorCourse.Status
            };
            return View("Edit", model);
        }
    }
}