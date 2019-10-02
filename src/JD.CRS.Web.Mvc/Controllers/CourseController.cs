using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using JD.CRS.Authorization;
using JD.CRS.Controllers;
using JD.CRS.Course;
using JD.CRS.Course.Dto;
using JD.CRS.Web.Models.Course;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace JD.CRS.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Course)]
    public class CourseController : CRSControllerBase
    {
        private readonly ICourseAppService _customerAppService;
        const int MaxNum = 10;
        public CourseController(ICourseAppService customerAppService)
        {
            _customerAppService = customerAppService;

        }
        // GET: /<controller>/
        public async Task<ActionResult> Index()
        {
            var customers = (await _customerAppService.GetAll(new PagedResultRequestDto { MaxResultCount = MaxNum })).Items;
            // Paging not implemented yet
            //CourseDto cuModule = customers.FirstOrDefault();
            var model = new CourseListViewModel
            {
                //Course = cuModule,
                Courses = customers
            };
            return View(model);
        }

        public async Task<ActionResult> EditCourseModal(int customerId)
        {
            var customer = await _customerAppService.Get(new EntityDto<int>(customerId));
            //CreateUpdateCourseDto cuCourse = AutoMapper.Mapper.Map<CreateUpdateCourseDto>(customer);
            var model = new EditCourseModalViewModel
            {
                Course = customer
            };
            return View("_EditCourseModal", model);
        }
    }
}