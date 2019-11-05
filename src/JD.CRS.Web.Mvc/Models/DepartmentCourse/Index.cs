using System;
using System.Collections.Generic;
using System.Linq;
using Abp.Localization;
using JD.CRS.Course.Dto;
using JD.CRS.Department.Dto;
using JD.CRS.DepartmentCourse.Dto;
using JD.CRS.Entitys;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JD.CRS.Web.Models.DepartmentCourse
{

    public class Index
    {
        public IReadOnlyList<DepartmentCourseReadDto> DepartmentCourses { get; set; }

        public IReadOnlyList<DepartmentReadDto> Departments { get; set; }
        public IReadOnlyList<CourseReadDto> Courses { get; set; }
        public Index(IReadOnlyList<DepartmentCourseReadDto> departmentCourses, IReadOnlyList<DepartmentReadDto> departments, IReadOnlyList<CourseReadDto> courses)
        {
            DepartmentCourses = departmentCourses;
            Departments = departments;
            Courses = courses;
        }

        public StatusCode? Status { get; set; }
        public string DepartmentCode { get; set; }
        public string CourseCode { get; set; }

        public List<SelectListItem> GetStatusList(ILocalizationManager localizationManager)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = localizationManager.GetString(CRSConsts.LocalizationSourceName, "PleaseSelect"),
                    Value = "",
                    Selected = Status == null
                }
            };

            list.AddRange(Enum.GetValues(typeof(StatusCode))
                .Cast<StatusCode>()
                .Select(status =>
                    new SelectListItem
                    {
                        Text = localizationManager.GetString(CRSConsts.LocalizationSourceName, $"StatusCode_{status}"),
                        Value = status.ToString(),
                        Selected = status == Status
                    })
            );

            return list;
        }
        public List<SelectListItem> GetDepartmentList(ILocalizationManager localizationManager)
        {
            var list = new List<SelectListItem>
            {

            };
            var departmentList = Departments.ToList();
            list.AddRange(departmentList
                .Select(department =>
                    new SelectListItem
                    {
                        Text = department.Name.ToString(),
                        Value = department.Code.ToString(),
                        Selected = department.Equals(DepartmentCode)
                    })
            );

            return list;
        }
        public List<SelectListItem> GetCourseList(ILocalizationManager localizationManager)
        {
            var list = new List<SelectListItem>
            {

            };
            var courseList = Courses.ToList();
            list.AddRange(courseList
                .Select(course =>
                    new SelectListItem
                    {
                        Text = course.Name.ToString(),
                        Value = course.Code.ToString(),
                        Selected = course.Equals(CourseCode)
                    })
            );

            return list;
        }
    }
}