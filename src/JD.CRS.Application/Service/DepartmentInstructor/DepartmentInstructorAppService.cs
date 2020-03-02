using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Castle.Core.Internal;
using JD.CRS.DepartmentInstructor.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JD.CRS.DepartmentInstructor
{
    public class DepartmentInstructorAppService : AsyncCrudAppService<Entitys.DepartmentInstructor, DepartmentInstructorReadDto, int, PagedResultRequestDto,
                             DepartmentInstructorWriteDto, DepartmentInstructorWriteDto>, IDepartmentInstructorAppService

    {
        private readonly IRepository<Entitys.DepartmentInstructor, int> _DepartmentInstructorRepository;
        public DepartmentInstructorAppService(IRepository<Entitys.DepartmentInstructor, int> DepartmentInstructorRepository)
            : base(DepartmentInstructorRepository)
        {
            _DepartmentInstructorRepository = DepartmentInstructorRepository;
        }

        public override Task<DepartmentInstructorReadDto> Create(DepartmentInstructorWriteDto input)
        {
            return base.Create(input);
        }

        public override async Task<PagedResultDto<DepartmentInstructorReadDto>> GetAll(PagedResultRequestDto input)
        {
            //查询
            var query = base.CreateFilteredQuery(input);
            //获取总数
            var DepartmentInstructorcount = query.Count();
            //获取清单
            var DepartmentInstructorlist = query.ToList();

            return new PagedResultDto<DepartmentInstructorReadDto>()
            {
                TotalCount = DepartmentInstructorcount,
                Items = ObjectMapper.Map<List<DepartmentInstructorReadDto>>(DepartmentInstructorlist)
            };
        }
    }
}