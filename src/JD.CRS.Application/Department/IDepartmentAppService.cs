using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using JD.CRS.Department.Dto;

namespace JD.CRS.Department
{
    public interface IDepartmentAppService : IAsyncCrudAppService<//定义了CRUD方法
             DepartmentDto, //用来展示课程
             int, //Department实体的主键
             PagedResultRequestDto, //获取课程的时候用于分页
             //GetAllDepartmentsInput, //获取课程的时候用于分页
             CreateUpdateDepartmentDto, //用于创建课程
             CreateUpdateDepartmentDto> //用于更新课程
    {
        
    }
}