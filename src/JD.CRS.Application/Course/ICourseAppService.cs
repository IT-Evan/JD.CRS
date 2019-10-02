using Abp.Application.Services;
using Abp.Application.Services.Dto;
using JD.CRS.Course.Dto;

namespace JD.CRS.Course
{
    public interface ICourseAppService : IAsyncCrudAppService<//定义了CRUD方法
             CourseDto, //用来展示商品
             int, //Course实体的主键
             PagedResultRequestDto, //获取商品的时候用于分页
             CreateUpdateCourseDto, //用于创建商品
             CreateUpdateCourseDto> //用于更新商品
    {
    }
}