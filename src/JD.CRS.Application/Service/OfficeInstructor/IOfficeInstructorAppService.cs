using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using JD.CRS.OfficeInstructor.Dto;

namespace JD.CRS.OfficeInstructor
{
    public interface IOfficeInstructorAppService : IAsyncCrudAppService<//定义了CRUD方法
             OfficeInstructorReadDto, //用来展示实体
             int, //实体的主键
             PagedResultRequestDto, //用于分页
             OfficeInstructorWriteDto, //用于创建实体
             OfficeInstructorWriteDto> //用于更新实体
    {
        
    }
}