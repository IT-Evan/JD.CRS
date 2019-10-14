using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using JD.CRS.Office.Dto;

namespace JD.CRS.Office
{
    public interface IOfficeAppService : IAsyncCrudAppService<//定义了CRUD方法
             OfficeDto, //用来展示课程
             int, //Office实体的主键
             PagedResultRequestDto, //获取课程的时候用于分页
             //GetAllOfficesInput, //获取课程的时候用于分页
             CreateUpdateOfficeDto, //用于创建课程
             CreateUpdateOfficeDto> //用于更新课程
    {
        
    }
}