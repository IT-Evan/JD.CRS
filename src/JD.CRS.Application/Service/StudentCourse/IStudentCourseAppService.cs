using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using JD.CRS.StudentCourse.Dto;

namespace JD.CRS.StudentCourse
{
    public interface IStudentCourseAppService : IAsyncCrudAppService<//定义了CRUD方法
             StudentCourseReadDto, //用来展示实体
             int, //实体的主键
             PagedResultRequestDto, //用于分页
             StudentCourseWriteDto, //用于创建实体
             StudentCourseWriteDto> //用于更新实体
    {
        
    }
}