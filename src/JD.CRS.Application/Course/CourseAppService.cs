using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Castle.Core.Internal;
using JD.CRS.Course.Dto;
using JD.CRS.Paged;
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
            var query = base.CreateFilteredQuery(input).WhereIf(input.Status.HasValue, t => t.Status == input.Status.Value);
            //var query = _courseRepository.GetAll().WhereIf(input.Status.HasValue, t => t.Status == input.Status.Value);
            var coursecount = query.Count();
            var courselist = query.ToList();
            return new PagedResultDto<CourseDto>()
            {
                TotalCount = coursecount,
                Items = ObjectMapper.Map<List<CourseDto>>(courselist)
            };
        }
    }
}