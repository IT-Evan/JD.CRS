using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
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

        public new ListResultDto<CourseDto> GetAll(GetAllCoursesInput input)
        {
            var courses = _courseRepository
                .GetAll()
                .WhereIf(input.Status.HasValue, t => t.Status == input.Status.Value)
                .OrderByDescending(t => t.CreationTime)
                .ToList();

            return new ListResultDto<CourseDto>(
                ObjectMapper.Map<List<CourseDto>>(courses)
            );
        }
    }
}