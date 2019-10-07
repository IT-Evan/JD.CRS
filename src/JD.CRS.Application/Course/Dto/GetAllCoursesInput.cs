using JD.CRS.Entitys;
using JD.CRS.Paged;
using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;

namespace JD.CRS.Course.Dto
{
    public class GetAllCoursesInput//: PagedResultRequestDto //PagedSortedAndFilteredInputDto
    {
        public StatusCode? Status { get; set; }
    }
}
