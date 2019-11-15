using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using JD.CRS.Department.Dto;

namespace JD.CRS.Department
{
    public interface IDepartmentAppService : IAsyncCrudAppService<//定义了CRUD方法
             DepartmentReadDto, //用来展示实体
             int, //实体的主键
             PagedResultRequestDto, //用于分页
             DepartmentWriteDto, //用于创建实体
             DepartmentWriteDto> //用于更新实体
    {
        
    }
}