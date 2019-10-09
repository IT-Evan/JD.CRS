using Abp.Application.Services.Dto;
using JD.CRS.Entitys;

namespace JD.CRS.Course.Dto
{
    public class GetAllCoursesInput: PagedResultRequestDto //PagedSortedAndFilteredInputDto
    {
        public StatusCode? Status { get; set; }
    }
}
