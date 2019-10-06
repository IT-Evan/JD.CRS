using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using JD.CRS.Authorization;
using JD.CRS.Controllers;
using JD.CRS.Course;
using JD.CRS.Course.Dto;
using JD.CRS.Web.Models.Course;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JD.CRS.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Course)]
    public class CourseController : CRSControllerBase
    {
        private readonly ICourseAppService _courseAppService;
        const int MaxNum = 10;
        public CourseController(ICourseAppService courseAppService)
        {
            _courseAppService = courseAppService;
        }
        // GET: /<controller>/
        public async Task<ActionResult> Index()
        {
            var courses = (await _courseAppService.GetAll(new PagedCourseResultRequestDto { MaxResultCount = MaxNum })).Items;
            // Paging not implemented yet
            var model = new CourseListViewModel
            {
                Courses = courses
            };
            return View(model);
        }

        public async Task<ActionResult> EditCourseModal(int courseId)
        {
            var course = await _courseAppService.Get(new EntityDto<int>(courseId));
            var model = new EditCourseModalViewModel
            {
                Course = course
            };
            return View("_EditCourseModal", model);
        }
    }
}