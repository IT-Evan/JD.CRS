using System;
using System.Collections.Generic;
using System.Linq;
using Abp.Localization;
using JD.CRS.StudentCourse.Dto;
using JD.CRS.Entitys;
using Microsoft.AspNetCore.Mvc.Rendering;
using JD.CRS.Student.Dto;
using JD.CRS.Course.Dto;

namespace JD.CRS.Web.Models.StudentCourse
{

    public class Index
    {
        public IReadOnlyList<StudentCourseReadDto> StudentCourses { get; set; }

        public IReadOnlyList<StudentReadDto> Students { get; set; }
        public IReadOnlyList<CourseReadDto> Courses { get; set; }
        public Index(IReadOnlyList<StudentCourseReadDto> studentCourses, IReadOnlyList<StudentReadDto> students, IReadOnlyList<CourseReadDto> courses)
        {
            StudentCourses = studentCourses;
            Students = students;
            Courses = courses;
        }

        public StatusCode? Status { get; set; }
        public string StudentCode { get; set; }
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
        public List<SelectListItem> GetStudentList(ILocalizationManager localizationManager)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = localizationManager.GetString(CRSConsts.LocalizationSourceName, "PleaseSelect"),
                    Value = "",
                    Selected = StudentCode == null
                }
            };
            var studentList = Students.ToList();
            list.AddRange(studentList
                .Select(student =>
                    new SelectListItem
                    {
                        Text = student.Name.ToString(),
                        Value = student.Code.ToString(),
                        Selected = student.Equals(StudentCode)
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