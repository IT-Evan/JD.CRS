using JD.CRS.Entitys;
using JD.CRS.Paged;
using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;

namespace JD.CRS.Course.Dto
{
    public class PagedCourseResultRequestDto: PagedResultRequestDto //PagedSortedAndFilteredInputDto
    {
        public string Keyword { get; set; }
    }
}
