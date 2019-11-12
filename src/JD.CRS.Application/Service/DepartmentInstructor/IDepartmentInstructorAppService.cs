using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using JD.CRS.DepartmentInstructor.Dto;

namespace JD.CRS.DepartmentInstructor
{
    public interface IDepartmentInstructorAppService : IAsyncCrudAppService<//定义了CRUD方法
             DepartmentInstructorReadDto, //用来展示实体
             int, //实体的主键
             PagedResultRequestDto, //用于分页
             DepartmentInstructorWriteDto, //用于创建实体
             DepartmentInstructorWriteDto> //用于更新实体
    {
        
    }
}