using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using JD.CRS.DepartmentCourse.Dto;

namespace JD.CRS.DepartmentCourse
{
    public interface IDepartmentCourseAppService : IAsyncCrudAppService<//定义了CRUD方法
             DepartmentCourseReadDto, //用来展示实体
             int, //实体的主键
             PagedResultRequestDto, //用于分页
             DepartmentCourseWriteDto, //用于创建实体
             DepartmentCourseWriteDto> //用于更新实体
    {
        
    }
}