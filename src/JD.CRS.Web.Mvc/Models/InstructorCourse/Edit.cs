using Abp.Localization;
using JD.CRS.InstructorCourse.Dto;
using JD.CRS.Entitys;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using JD.CRS.Instructor.Dto;
using JD.CRS.Course.Dto;

namespace JD.CRS.Web.Models.InstructorCourse
{

    public class Edit
    {
        public InstructorCourseReadDto InstructorCourse { get; set; }

        public IReadOnlyList<InstructorReadDto> Instructors { get; set; }
        public IReadOnlyList<CourseReadDto> Courses { get; set; }
        public Edit(InstructorCourseReadDto instructorCourse, IReadOnlyList<InstructorReadDto> instructors, IReadOnlyList<CourseReadDto> courses)
        {
            InstructorCourse = instructorCourse;
            Instructors = instructors;
            Courses = courses;
        }

        public StatusCode? Status { get; set; }
        public string InstructorCode { get; set; }
        public string CourseCode { get; set; }
        public List<SelectListItem> GetStatusList(ILocalizationManager localizationManager)
        {
            var list = new List<SelectListItem>
            {

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
        public List<SelectListItem> GetInstructorList(ILocalizationManager localizationManager)
        {
            var list = new List<SelectListItem>
            {
                
            };
            var instructorList = Instructors.ToList();
            list.AddRange(instructorList
                .Select(instructor =>
                    new SelectListItem
                    {
                        Text = instructor.Name.ToString(),
                        Value = instructor.Code.ToString(),
                        Selected = instructor.Equals(InstructorCode)
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