using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using JD.CRS.InstructorCourse.Dto;

namespace JD.CRS.InstructorCourse
{
    public interface IInstructorCourseAppService : IAsyncCrudAppService<//定义了CRUD方法
             InstructorCourseReadDto, //用来展示课程
             int, //InstructorCourse实体的主键
             PagedResultRequestDto, //获取课程的时候用于分页
             //GetAllInstructorCoursesInput, //获取课程的时候用于分页
             InstructorCourseWriteDto, //用于创建课程
             InstructorCourseWriteDto> //用于更新课程
    {
        
    }
}