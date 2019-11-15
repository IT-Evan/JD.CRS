using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using JD.CRS.Office.Dto;

namespace JD.CRS.Office
{
    public interface IOfficeAppService : IAsyncCrudAppService<//定义了CRUD方法
             OfficeReadDto, //用来展示实体
             int, //实体的主键
             PagedResultRequestDto, //用于分页
             OfficeWriteDto, //用于创建实体
             OfficeWriteDto> //用于更新实体
    {
        
    }
}