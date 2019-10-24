using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Castle.Core.Internal;
using JD.CRS.OfficeInstructor.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JD.CRS.OfficeInstructor
{
    public class OfficeInstructorAppService : AsyncCrudAppService<Entitys.OfficeInstructor, OfficeInstructorReadDto, int, PagedResultRequestDto,
                             OfficeInstructorWriteDto, OfficeInstructorWriteDto>, IOfficeInstructorAppService

    {
        private readonly IRepository<Entitys.OfficeInstructor, int> _OfficeInstructorRepository;
        public OfficeInstructorAppService(IRepository<Entitys.OfficeInstructor, int> OfficeInstructorRepository)
            : base(OfficeInstructorRepository)
        {
            _OfficeInstructorRepository = OfficeInstructorRepository;
        }

        public override Task<OfficeInstructorReadDto> Create(OfficeInstructorWriteDto input)
        {
            return base.Create(input);
        }

        public override async Task<PagedResultDto<OfficeInstructorReadDto>> GetAll(PagedResultRequestDto input)
        {
            //查询
            var query = base.CreateFilteredQuery(input);
            //获取总数
            var OfficeInstructorcount = query.Count();
            //获取清单
            var OfficeInstructorlist = query.ToList();

            //return new PagedResultDto<OfficeInstructorDto>(OfficeInstructorcount, OfficeInstructorlist.MapTo<List<OfficeInstructorDto>>());
            return new PagedResultDto<OfficeInstructorReadDto>()
            {
                TotalCount = OfficeInstructorcount,
                Items = ObjectMapper.Map<List<OfficeInstructorReadDto>>(OfficeInstructorlist)
            };
        }
    }
}