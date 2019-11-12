using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using JD.CRS.InstructorCourse.Dto;

namespace JD.CRS.InstructorCourse
{
    public interface IInstructorCourseAppService : IAsyncCrudAppService<//定义了CRUD方法
             InstructorCourseReadDto, //用来展示实体
             int, //实体的主键
             PagedResultRequestDto, //用于分页
             InstructorCourseWriteDto, //用于创建实体
             InstructorCourseWriteDto> //用于更新实体
    {
        
    }
}