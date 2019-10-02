using System.Collections.Generic;
using JD.CRS.Course.Dto;

namespace JD.CRS.Web.Models.Course
{

    public class CourseListViewModel
    {
        //public CourseDto Course { get; set; }
        public IReadOnlyList<CourseDto> Courses { get; set; }
    }
}