using JD.CRS.Paged;
using System;
using System.Collections.Generic;
using System.Text;

namespace JD.CRS.Course.Dto
{
    public class GetCourseInput: PagedSortedAndFilteredInputDto
    {
        public string Name { get; set; }
        public string DepartmentCode { get; set; }
    }
}
