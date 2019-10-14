using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using JD.CRS.Instructor.Dto;

namespace JD.CRS.Instructor
{
    public interface IInstructorAppService : IAsyncCrudAppService<//定义了CRUD方法
             InstructorReadDto, //用来展示课程
             int, //Instructor实体的主键
             PagedResultRequestDto, //获取课程的时候用于分页
             //GetAllInstructorsInput, //获取课程的时候用于分页
             InstructorWriteDto, //用于创建课程
             InstructorWriteDto> //用于更新课程
    {
        
    }
}