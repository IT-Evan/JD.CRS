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
using X.PagedList;
using X.PagedList.Mvc.Core;

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
        public async Task<ActionResult> Index(GetAllCoursesInput input)
        {
            IReadOnlyList<CourseDto> output = (await _courseAppService.GetAll(new GetAllCoursesInput { Status = input.Status, Keyword = input.Keyword })).Items;
            var model = new CourseListViewModel(output)
            {
                Status = input.Status,
                Keyword = input.Keyword
            };
            return View(model);
        }

        public ActionResult PagedList(int? page)
        {
            //每页行数
            var pageSize = 5;
            var pageNumber = page ?? 1;//第几页

            var filter = new GetAllCoursesInput
            {
                SkipCount = (pageNumber - 1) * pageSize,//忽略个数
                MaxResultCount = pageSize
            };
            var result = _courseAppService.GetAll(filter).Result;

            //已经在应用服务层手动完成了分页逻辑，所以需手动构造分页结果
            var onePageOfTasks = new StaticPagedList<CourseDto>(result.Items, pageNumber, pageSize, result.TotalCount);
            //将分页结果放入ViewBag供View使用
            ViewBag.OnePageOfTasks = onePageOfTasks;

            return View();
        }

        //public async Task<ActionResult> Index(GetAllCoursesInput input)
        //{
        //    //每页行数
        //    var pageSize = 5;
        //    var pageNumber = 2; //input.PageNumber;//第几页

        //    var filter = new GetAllCoursesInput
        //    {
        //        SkipCount = (pageNumber - 1) * pageSize,//忽略个数
        //        MaxResultCount = pageSize,
        //        Status = input.Status,
        //        Keyword = input.Keyword
        //    };
        //    IReadOnlyList<CourseDto> result = (await _courseAppService.GetAll(filter)).Items;
        //    //var result = _courseAppService.GetAll(filter).Result;

        //    //已经在应用服务层手动完成了分页逻辑，所以需手动构造分页结果
        //    var onePageOfCourses = new StaticPagedList<CourseDto>(result, pageNumber, pageSize, result.Count);
        //    //将分页结果放入ViewBag供View使用
        //    ViewBag.OnePageOfCourses = onePageOfCourses;

        //    var model = new CourseListViewModel(result)
        //    {
        //        Status = input.Status,
        //        Keyword = input.Keyword,
        //        PageNumber = input.PageNumber
        //    };
        //    return View(model);
        //}

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