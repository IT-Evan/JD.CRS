using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using JD.CRS.StudentCourse.Dto;

namespace JD.CRS.StudentCourse
{
    public interface IStudentCourseAppService : IAsyncCrudAppService<//定义了CRUD方法
             StudentCourseReadDto, //用来展示课程
             int, //StudentCourse实体的主键
             PagedResultRequestDto, //获取课程的时候用于分页
             //GetAllStudentCoursesInput, //获取课程的时候用于分页
             StudentCourseWriteDto, //用于创建课程
             StudentCourseWriteDto> //用于更新课程
    {
        
    }
}