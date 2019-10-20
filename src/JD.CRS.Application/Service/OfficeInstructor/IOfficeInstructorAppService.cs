using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using JD.CRS.OfficeInstructor.Dto;

namespace JD.CRS.OfficeInstructor
{
    public interface IOfficeInstructorAppService : IAsyncCrudAppService<//定义了CRUD方法
             OfficeInstructorReadDto, //用来展示课程
             int, //OfficeInstructor实体的主键
             PagedResultRequestDto, //获取课程的时候用于分页
             //GetAllOfficeInstructorsInput, //获取课程的时候用于分页
             OfficeInstructorWriteDto, //用于创建课程
             OfficeInstructorWriteDto> //用于更新课程
    {
        
    }
}