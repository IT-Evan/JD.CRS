using Abp.Application.Services.Dto;
using JD.CRS.Entitys;
using JD.CRS.Paged;

namespace JD.CRS.Course.Dto
{
    public class GetAllCoursesInput: PagedSortedAndFilteredInputDto//PagedResultRequestDto
    {
        public StatusCode? Status { get; set; }        
        public string Keyword { get; set; }
        public int PageNumber { get; set; }
    }
}
