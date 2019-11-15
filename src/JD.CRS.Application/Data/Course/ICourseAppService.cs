using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using JD.CRS.Course.Dto;

namespace JD.CRS.Course
{
    public interface ICourseAppService : IAsyncCrudAppService<//定义了CRUD方法
             CourseReadDto, //用来展示实体
             int, //实体的主键
             PagedResultRequestDto, //用于分页
             CourseWriteDto, //用于创建实体
             CourseWriteDto> //用于更新实体
    {
        
    }
}