using Abp.Application.Services;
using Abp.Application.Services.Dto;
using JD.CRS.Course.Dto;

namespace JD.CRS.Course
{
    public interface ICourseAppService : IAsyncCrudAppService<//定义了CRUD方法
             CourseDto, //用来展示课程
             int, //Course实体的主键
             GetAllCoursesInput, //获取课程的时候用于分页
             CreateUpdateCourseDto, //用于创建课程
             CreateUpdateCourseDto> //用于更新课程
    {
    }
}