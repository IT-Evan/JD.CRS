using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Castle.Core.Internal;
using JD.CRS.InstructorCourse.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JD.CRS.InstructorCourse
{
    public class InstructorCourseAppService : AsyncCrudAppService<Entitys.InstructorCourse, InstructorCourseReadDto, int, PagedResultRequestDto,
                             InstructorCourseWriteDto, InstructorCourseWriteDto>, IInstructorCourseAppService

    {
        private readonly IRepository<Entitys.InstructorCourse, int> _InstructorCourseRepository;
        public InstructorCourseAppService(IRepository<Entitys.InstructorCourse, int> InstructorCourseRepository)
            : base(InstructorCourseRepository)
        {
            _InstructorCourseRepository = InstructorCourseRepository;
        }

        public override Task<InstructorCourseReadDto> Create(InstructorCourseWriteDto input)
        {
            return base.Create(input);
        }

        public override async Task<PagedResultDto<InstructorCourseReadDto>> GetAll(PagedResultRequestDto input)
        {
            //查询
            var query = base.CreateFilteredQuery(input);
            //获取总数
            var InstructorCoursecount = query.Count();
            //获取清单
            var InstructorCourselist = query.ToList();

            return new PagedResultDto<InstructorCourseReadDto>()
            {
                TotalCount = InstructorCoursecount,
                Items = ObjectMapper.Map<List<InstructorCourseReadDto>>(InstructorCourselist)
            };
        }
    }
}