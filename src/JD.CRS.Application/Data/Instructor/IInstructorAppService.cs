using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using JD.CRS.Instructor.Dto;

namespace JD.CRS.Instructor
{
    public interface IInstructorAppService : IAsyncCrudAppService<//定义了CRUD方法
             InstructorReadDto, //用来展示实体
             int, //实体的主键
             PagedResultRequestDto, //用于分页
             InstructorWriteDto, //用于创建实体
             InstructorWriteDto> //用于更新实体
    {
        
    }
}