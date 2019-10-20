using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using JD.CRS.DepartmentCourse.Dto;

namespace JD.CRS.DepartmentCourse
{
    public interface IDepartmentCourseAppService : IAsyncCrudAppService<//定义了CRUD方法
             DepartmentCourseReadDto, //用来展示课程
             int, //DepartmentCourse实体的主键
             PagedResultRequestDto, //获取课程的时候用于分页
             //GetAllDepartmentCoursesInput, //获取课程的时候用于分页
             DepartmentCourseWriteDto, //用于创建课程
             DepartmentCourseWriteDto> //用于更新课程
    {
        
    }
}