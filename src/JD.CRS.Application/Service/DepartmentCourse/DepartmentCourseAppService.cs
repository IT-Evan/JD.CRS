using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Castle.Core.Internal;
using JD.CRS.DepartmentCourse.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JD.CRS.DepartmentCourse
{
    public class DepartmentCourseAppService : AsyncCrudAppService<Entitys.DepartmentCourse, DepartmentCourseReadDto, int, PagedResultRequestDto,// GetAllDepartmentCoursesInput,
                             DepartmentCourseWriteDto, DepartmentCourseWriteDto>, IDepartmentCourseAppService

    {
        private readonly IRepository<Entitys.DepartmentCourse, int> _DepartmentCourseRepository;
        public DepartmentCourseAppService(IRepository<Entitys.DepartmentCourse, int> DepartmentCourseRepository)
            : base(DepartmentCourseRepository)
        {
            _DepartmentCourseRepository = DepartmentCourseRepository;
        }

        public override Task<DepartmentCourseReadDto> Create(DepartmentCourseWriteDto input)
        {
            return base.Create(input);
        }

        public override async Task<PagedResultDto<DepartmentCourseReadDto>> GetAll(PagedResultRequestDto input)
        {
            //查询
            var query = base.CreateFilteredQuery(input);
            //获取总数
            var DepartmentCoursecount = query.Count();
            //获取清单
            var DepartmentCourselist = query.ToList();

            return new PagedResultDto<DepartmentCourseReadDto>()
            {
                TotalCount = DepartmentCoursecount,
                Items = ObjectMapper.Map<List<DepartmentCourseReadDto>>(DepartmentCourselist)
            };
        }
    }
}