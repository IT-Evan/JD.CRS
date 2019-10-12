using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Castle.Core.Internal;
using JD.CRS.Course.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JD.CRS.Course
{
    public class CourseAppService : AsyncCrudAppService<Entitys.Course, CourseDto, int, GetAllCoursesInput,
                             CreateUpdateCourseDto, CreateUpdateCourseDto>, ICourseAppService

    {
        private readonly IRepository<Entitys.Course, int> _courseRepository;
        public CourseAppService(IRepository<Entitys.Course, int> courseRepository)
            : base(courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public override Task<CourseDto> Create(CreateUpdateCourseDto input)
        {
            return base.Create(input);
        }

        public override async Task<PagedResultDto<CourseDto>> GetAll(GetAllCoursesInput input)
        {
            //组合查询
            //var query = base.CreateFilteredQuery(input)
            //    .WhereIf(input.Status.HasValue, t => t.Status == input.Status.Value)
            //    .WhereIf(
            //    !input.Keyword.IsNullOrEmpty(), t =>
            //    t.Code.ToLower().Contains((input.Keyword ?? string.Empty).ToLower()) //按编号查询
            //    || t.DepartmentCode.ToLower().Contains((input.Keyword ?? string.Empty).ToLower()) //按院系编号查询
            //    || t.Name.ToLower().Contains((input.Keyword ?? string.Empty).ToLower()) //按名称查询
            //    || t.Credits.ToString().Contains((input.Keyword ?? string.Empty).ToLower()) //按学分查询
            //    || t.Remarks.ToLower().Contains((input.Keyword ?? string.Empty).ToLower()) //按备注查询
            //    );
            var query = base.CreateFilteredQuery(input);
            //获取总数
            var coursecount = query.Count();
            //获取清单
            var courselist = query.ToList();

            return new PagedResultDto<CourseDto>()
            {
                TotalCount = coursecount,
                Items = ObjectMapper.Map<List<CourseDto>>(courselist)
            };
            //return new PagedResultDto<CourseDto>(coursecount, courselist.MapTo<List<CourseDto>>());
        }
    }
}