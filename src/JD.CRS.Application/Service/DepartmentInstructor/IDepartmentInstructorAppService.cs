using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using JD.CRS.DepartmentInstructor.Dto;

namespace JD.CRS.DepartmentInstructor
{
    public interface IDepartmentInstructorAppService : IAsyncCrudAppService<//定义了CRUD方法
             DepartmentInstructorReadDto, //用来展示课程
             int, //DepartmentInstructor实体的主键
             PagedResultRequestDto, //获取课程的时候用于分页
             //GetAllDepartmentInstructorsInput, //获取课程的时候用于分页
             DepartmentInstructorWriteDto, //用于创建课程
             DepartmentInstructorWriteDto> //用于更新课程
    {
        
    }
}