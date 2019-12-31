using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Castle.Core.Internal;
using JD.CRS.StudentCourse.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JD.CRS.StudentCourse
{
    public class StudentCourseAppService : AsyncCrudAppService<Entitys.StudentCourse, StudentCourseReadDto, int, PagedResultRequestDto,// GetAllStudentCoursesInput,
                             StudentCourseWriteDto, StudentCourseWriteDto>, IStudentCourseAppService

    {
        private readonly IRepository<Entitys.StudentCourse, int> _StudentCourseRepository;
        public StudentCourseAppService(IRepository<Entitys.StudentCourse, int> StudentCourseRepository)
            : base(StudentCourseRepository)
        {
            _StudentCourseRepository = StudentCourseRepository;
        }

        public override Task<StudentCourseReadDto> Create(StudentCourseWriteDto input)
        {
            return base.Create(input);
        }

        public override async Task<PagedResultDto<StudentCourseReadDto>> GetAll(PagedResultRequestDto input)
        {
            //查询
            var query = base.CreateFilteredQuery(input);
            //获取总数
            var StudentCoursecount = query.Count();
            //获取清单
            var StudentCourselist = query.ToList();

            return new PagedResultDto<StudentCourseReadDto>()
            {
                TotalCount = StudentCoursecount,
                Items = ObjectMapper.Map<List<StudentCourseReadDto>>(StudentCourselist)
            };
        }
    }
}