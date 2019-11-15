using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using JD.CRS.Student.Dto;

namespace JD.CRS.Student
{
    public interface IStudentAppService : IAsyncCrudAppService<//定义了CRUD方法
             StudentReadDto, //用来展示实体
             int, //实体的主键
             PagedResultRequestDto, //用于分页
             StudentWriteDto, //用于创建实体
             StudentWriteDto> //用于更新实体
    {
        
    }
}