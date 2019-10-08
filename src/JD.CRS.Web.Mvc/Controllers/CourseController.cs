using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using JD.CRS.Authorization;
using JD.CRS.Controllers;
using JD.CRS.Course;
using JD.CRS.Course.Dto;
using JD.CRS.Web.Models.Course;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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

        //public async Task<ActionResult> Index(GetAllCoursesInput input)
        //{
        //    var output = await _courseAppService.GetAll(input);
        //    var model = new CourseListViewModel(output.Items)
        //    {
        //        SelectedStatus = input.Status
        //    };
        //    return View(model);
        //}

        // GET: /<controller>/
        public async Task<ActionResult> Index(GetAllCoursesInput input)
        {
            IReadOnlyList<CourseDto> courses = (await _courseAppService.GetAll(new GetAllCoursesInput { Status = input.Status })).Items;
            // Paging not implemented yet
            var model = new CourseListViewModel(courses);
            return View(model);
        }

        // GET: /<controller>/
        //public async Task<IActionResult> Index(string sortOrder, string currentFilter, string keyword, int? pageSize, int? pageNumber)
        //{
        //    ViewData["CurrentSort"] = sortOrder;

        //    if (keyword != null)
        //    {
        //        pageNumber = 1;
        //    }
        //    else
        //    {
        //        keyword = currentFilter;
        //    }

        //    ViewData["CurrentFilter"] = keyword;

        //    if (pageSize == null)
        //    {
        //        pageSize = AppConsts.DefaultPageSize;
        //    }

        //    if (pageNumber == null)
        //    {
        //        pageNumber = 1;
        //    }

        //    var skipCount = (int)(pageSize * (pageNumber - 1));

        //    var courses = (await _courseAppService.GetAll(new GetAllCoursesInput { SkipCount = skipCount, Keyword = keyword, MaxResultCount = MaxNum })).Items;

        //    var model = new CourseListViewModel
        //    {
        //        Courses = courses
        //    };
        //    return View(model);
        //}

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