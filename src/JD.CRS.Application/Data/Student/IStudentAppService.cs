using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using JD.CRS.Student.Dto;

namespace JD.CRS.Student
{
    public interface IStudentAppService : IAsyncCrudAppService<//定义了CRUD方法
             StudentReadDto, //用来展示课程
             int, //Student实体的主键
             PagedResultRequestDto, //获取课程的时候用于分页
             //GetAllStudentsInput, //获取课程的时候用于分页
             StudentWriteDto, //用于创建课程
             StudentWriteDto> //用于更新课程
    {
        
    }
}