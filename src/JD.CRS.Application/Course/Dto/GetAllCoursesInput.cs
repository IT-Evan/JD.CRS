using Abp.Application.Services.Dto;
using JD.CRS.Entitys;

namespace JD.CRS.Course.Dto
{
    public class GetAllCoursesInput: PagedResultRequestDto
    {
        public StatusCode? Status { get; set; }
        public string Keyword { get; set; }
    }
}
