using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using JD.CRS.Course.Dto;

namespace JD.CRS.Course
{
    public interface ICourseAppService : IAsyncCrudAppService<//定义了CRUD方法
             CourseReadDto, //用来展示课程
             int, //Course实体的主键
             PagedResultRequestDto, //获取课程的时候用于分页
            //GetAllCoursesInput, //获取课程的时候用于分页
             CourseWriteDto, //用于创建课程
             CourseWriteDto> //用于更新课程
    {
        
    }
}